using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralFormLibrary1
{
    public partial class RightClickDropDownMenu<T> where T: class, new()
    {
        private ContextMenuStrip contextMenuStrip { get; set; }
        private DataGridView currentDataGridView { get; set; }
        private int currentMouseOverRowIndex { get; set; }
        private int currentMouseOverColumnIndex { get; set; }

        private Dictionary<string,string> Credentials { get; set; }
        private string AppName {get; set;}
        private string NameForExcelExport { get; set; }
        private string TableNameForExport { get; set; }
        Dictionary<string, string> specialValueDictionary { get; set; } = new Dictionary<string, string>();
        private string filterValue { get; set; }
        private TypeCode filterValueDataType { get; set; }
        private List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter> dataGridViewFilters { get; set; }
        public static string Directroy_Downloads { get; } = @"C:\Users\" + Environment.UserName + @"\Downloads";

        //Menu items
        private static string item_Seperator { get; } = "-";
        private static string item_SubMenuStart { get; } = "[";
        private static string item_SubMenuEnd { get; } = "]";
        private static string item_Copy { get; } = "Copy";
        private static string item_Equals { get; } = "Equals";
        private static string item_DoesNotEqual { get; } = "Does not Equal";
        private static string item_Contains { get; } = "Contains";
        private static string item_GreaterThan { get; } = "Greater Than";
        private static string item_LessThan { get; } = "Less Than";
        private static string item_GreaterThanOrEqualTo { get; } = "Greater Than Or Equal To";
        private static string item_LessThanOrEqualTo { get; } = "Less Than Or Equal To";
        private static string item_ClearAllFilters { get; } = "Clear All Filters";
        private static string item_ClearColumnFilters { get; } = "Clear Column Filters";
        private static string item_URLSearch { get; } = "Search in Web browser...";
        private static string item_Export { get; } = "Export Grid to Excel";
        private static string item_DeleteEntry { get; } = "Delete Record From Database";
        private static string item_Action { get; } = "Action";

        public RightClickDropDownMenu(ContextMenuStrip contextMenu, DataGridView dataGridView, List<DataModels.Model_DataGridViewFilter> gridViewFilters, string appName, string tableNameForExport, Dictionary<string, string> credentials) 
        {
            currentDataGridView = dataGridView;
            dataGridViewFilters = gridViewFilters;
            contextMenuStrip = contextMenu;
            AppName = appName;
            TableNameForExport = tableNameForExport;
            Credentials = credentials;
        }

        public void Show(CustomRightClickMenu menuOption, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                SetIntialValues(e);
                Load_RightClickMenuItems(menuOption);
                SetRightClickMenuPropertiesAndShow(e);
            }
        }

        private static List<string> GetRightClickMenuItems(CustomRightClickMenu rightClickMenu, DataGridView dataGridView)
        {
            List<string> menuItems = new List<string>();
            bool ValueIsNumeric = false;

            if(dataGridView.CurrentCell != null)
            {

                if (dataGridView.CurrentCell.Value != null && DataTypes.TypeCodeIsNumeric(Type.GetTypeCode(dataGridView.CurrentCell.Value.GetType())))
                {
                    ValueIsNumeric = true;
                }
                
            }

            //Add primary options
            if(rightClickMenu == CustomRightClickMenu.ClearAllFiltersOnly)
            {
                menuItems.Add(item_ClearAllFilters);
                return menuItems;
            }
            else
            {
                menuItems.Add(item_Copy);
                menuItems.Add(item_Seperator);
                menuItems.Add(item_Equals);
                menuItems.Add(item_DoesNotEqual);

                if (ValueIsNumeric)
                {
                    menuItems.Add(item_GreaterThan);
                    menuItems.Add(item_GreaterThanOrEqualTo);
                    menuItems.Add(item_LessThan);
                    menuItems.Add(item_LessThanOrEqualTo);
                }
            }

            //Add intermediate values
            if(rightClickMenu == CustomRightClickMenu.DefaultMenu_URL || rightClickMenu == CustomRightClickMenu.DefaultMenu_URL_Delete)
            {
                menuItems.Add(item_Seperator);
                menuItems.Add(item_URLSearch);
            }

            if(rightClickMenu == CustomRightClickMenu.DefaultMenu_Delete || rightClickMenu == CustomRightClickMenu.DefaultMenu_URL_Delete)
            {
                menuItems.Add(item_Seperator);
                menuItems.Add(item_Action);
                menuItems.Add(item_SubMenuStart);
                menuItems.Add(item_DeleteEntry);
                menuItems.Add(item_SubMenuEnd);
            }

            //Add final items
            menuItems.Add(item_Seperator);
            menuItems.Add(item_Export);
            menuItems.Add(item_Seperator);
            menuItems.Add(item_ClearColumnFilters);
            menuItems.Add(item_ClearAllFilters);

            return menuItems;
        }

        private void Load_RightClickMenuItems(CustomRightClickMenu rightClickMenu = CustomRightClickMenu.DefaultMenu)
        {
            bool nextItemIsSubMenu = false;
            bool nextItemIsSub_Sub_Menu = false;
            int itemIndex = -1;
            int itemIndex_SubMenu = -1;
            contextMenuStrip.Items.Clear();

            foreach(string item in GetRightClickMenuItems(rightClickMenu, currentDataGridView))
            {
                if(item == item_SubMenuEnd && nextItemIsSub_Sub_Menu == false)
                {
                    nextItemIsSubMenu = false;
                }
                else if (nextItemIsSubMenu == true)
                {
                    if(nextItemIsSub_Sub_Menu == true)
                    {
                        if(item == item_Seperator)
                        {
                            ((contextMenuStrip.Items[itemIndex] as ToolStripMenuItem).DropDownItems[itemIndex_SubMenu] as ToolStripMenuItem).DropDownItems.Add(item_Seperator);
                        }
                        else if (item == item_SubMenuEnd)
                        {
                            nextItemIsSub_Sub_Menu = false;
                        }
                        else if(item == item_SubMenuStart)
                        {
                            throw new Exception("Sorry, third level drop downs have not been configured yet");
                        }
                        else
                        {
                            ((contextMenuStrip.Items[itemIndex] as ToolStripMenuItem).DropDownItems[itemIndex_SubMenu] as ToolStripMenuItem).DropDownItems.Add(item, null, Item_Click);
                        }
                    }
                    else if (item == item_Seperator)
                    {
                        (contextMenuStrip.Items[itemIndex] as ToolStripMenuItem).DropDownItems.Add(item);
                        itemIndex_SubMenu++;
                    }
                    else if(item == item_SubMenuStart)
                    {
                        nextItemIsSub_Sub_Menu = true;
                    }
                    else
                    {
                        (contextMenuStrip.Items[itemIndex] as ToolStripMenuItem).DropDownItems.Add(item, null, Item_Click);
                        itemIndex_SubMenu++;
                    }
                }
                else if(item == item_SubMenuStart)
                {
                    nextItemIsSubMenu = true;
                }
                else if (item == item_Seperator)
                {
                    contextMenuStrip.Items.Add(item);
                    itemIndex++;
                }
                else
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(item);
                    contextMenuStrip.Items.Add(item,null, Item_Click);
                    itemIndex++;
                }

                //Validation
                if(nextItemIsSubMenu == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append((string)contextMenuStrip.Items[itemIndex].Text);

                    if(sb.ToString() == "")
                    {
                        MessageBox.Show(null, "Error while building drop down. You cannot add a drop down item to a line seperator item.", AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        contextMenuStrip.Items.Clear();
                        return;
                    }
                }
            }
        }

        private async void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if(item.Text == item_Copy)
            {
                currentDataGridView.CurrentCell = currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex];
                Clipboard.SetText(currentDataGridView.CurrentCell.Value.ToString());
            }
            else if (item.Text == item_Equals)
            {
                //Add filter to filter list
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Equals, filterValue, filterValueDataType);
                dataGridViewFilters.Add(gridViewFilter);

                //Filter Value
                if(!(currentDataGridView.Rows.Count == 0))
                {
                    FormControls.FilterDataGridView(gridViewFilter.DataGridViewObj, dataGridViewFilters);
                }
            }
            else if (item.Text == item_DoesNotEqual)
            {
                //Add filter to filter list
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.DoNotEqual, filterValue, filterValueDataType);
                dataGridViewFilters.Add(gridViewFilter);

                //Filter Value
                if (!(currentDataGridView.Rows.Count == 0))
                {
                    FormControls.FilterDataGridView(gridViewFilter.DataGridViewObj, dataGridViewFilters);
                }
            }
            else if (item.Text == item_GreaterThan)
            {
                //Add filter to filter list
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.GreaterThan, filterValue, filterValueDataType);
                dataGridViewFilters.Add(gridViewFilter);

                //Filter Value
                if (!(currentDataGridView.Rows.Count == 0))
                {
                    FormControls.FilterDataGridView(gridViewFilter.DataGridViewObj, dataGridViewFilters);
                }
            }
            else if (item.Text == item_GreaterThanOrEqualTo)
            {
                //Add filter to filter list
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.GreaterThanOrEqualTo, filterValue, filterValueDataType);
                dataGridViewFilters.Add(gridViewFilter);

                //Filter Value
                if (!(currentDataGridView.Rows.Count == 0))
                {
                    FormControls.FilterDataGridView(gridViewFilter.DataGridViewObj, dataGridViewFilters);
                }
            }
            else if (item.Text == item_LessThan)
            {
                //Add filter to filter list
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.LessThan, filterValue, filterValueDataType);
                dataGridViewFilters.Add(gridViewFilter);

                //Filter Value
                if (!(currentDataGridView.Rows.Count == 0))
                {
                    FormControls.FilterDataGridView(gridViewFilter.DataGridViewObj, dataGridViewFilters);
                }
            }
            else if (item.Text == item_LessThanOrEqualTo)
            {
                //Add filter to filter list
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.LessThanOrEqualTo, filterValue, filterValueDataType);
                dataGridViewFilters.Add(gridViewFilter);

                //Filter Value
                if (!(currentDataGridView.Rows.Count == 0))
                {
                    FormControls.FilterDataGridView(gridViewFilter.DataGridViewObj, dataGridViewFilters);
                }
            }
            else if(item.Text == item_ClearAllFilters)
            {
                dataGridViewFilters = ClearFilters(dataGridViewFilters, currentDataGridView);
                FormControls.UnfilterDataGridView(currentDataGridView);
                FormControls.FilterDataGridView(currentDataGridView, dataGridViewFilters);
            }
            else if (item.Text == item_ClearColumnFilters)
            {
                dataGridViewFilters = ClearFilters(dataGridViewFilters, currentDataGridView, currentMouseOverColumnIndex);
                FormControls.UnfilterDataGridView(currentDataGridView);
                FormControls.FilterDataGridView(currentDataGridView, dataGridViewFilters);
            }
            else if (item.Text == item_URLSearch)
            {
                currentDataGridView.CurrentCell = currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex];
                if (currentDataGridView.CurrentCell.Value.ToString().StartsWith("http") || currentDataGridView.CurrentCell.Value.ToString().StartsWith("www."))
                {
                    GeneralFormLibrary1.WebAPI.LaunchURL(currentDataGridView.CurrentCell.Value.ToString());
                }
                else
                {
                    GeneralFormLibrary1.WebAPI.Search(currentDataGridView.CurrentCell.Value.ToString());
                }
            }
            else if (item.Text == item_Export)
            {
                GeneralFormLibrary1.FormControls.DataGridViewExportToExcel(currentDataGridView, AppName, TableNameForExport, Directroy_Downloads, true);
            }
            else if (item.Text == item_Action)
            {
                //Do nothing
            }
            else if (item.Text == item_DeleteEntry)
            {
                T model = FormControls.DataGridViewToObject<T>(currentDataGridView, currentMouseOverRowIndex);
                dynamic dynamicModel = model;
                int Id = dynamicModel.Id;
                DialogResult result = MessageBox.Show(null, "You are about to delete a record (Id: " + Id.ToString() + ") from database. Are you sure you want to continue?"  , AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    DataAccess<T> dataAccess = new DataAccess<T>(Credentials);
                    if (await dataAccess.Delete(model) == true)
                    {
                        MessageBox.Show(null, "Record deleted from database", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(null, "Record failed to be deleted from database", AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(null, "A corresponding method has not yet been configured for this item.", AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static List<DataModels.Model_DataGridViewFilter> ClearFilters(List<DataModels.Model_DataGridViewFilter> dataGridViewFilters, DataGridView dataGridView, int ColumnIndexToClear = -1)
        {
            for (int i = 0; i < dataGridViewFilters.Count; i++)
            {
                //If datagrid view and column index are provided, clear those associated filters.
                if (ColumnIndexToClear >= 0)
                {
                    if (dataGridViewFilters[i].DataGridViewObj == dataGridView && dataGridViewFilters[i].ColumnIndexToFilter == ColumnIndexToClear)
                    {
                        dataGridViewFilters.RemoveAt(i);
                        i--; //Decrement
                    }
                }
                //If datagridview is provided, clear associated filters.
                else
                {
                    if (dataGridViewFilters[i].DataGridViewObj == dataGridView)
                    {
                        dataGridViewFilters.RemoveAt(i);
                        i--; //Decrement
                    }
                }
            }

            return dataGridViewFilters;
        }

        private void SetIntialValues(MouseEventArgs e)
        {
            currentMouseOverColumnIndex = currentDataGridView.HitTest(e.X, e.Y).ColumnIndex;
            currentMouseOverRowIndex = currentDataGridView.HitTest(e.X, e.Y).RowIndex;
            
            if(currentMouseOverColumnIndex > 0 || currentMouseOverRowIndex > 0)
            {
                currentDataGridView.CurrentCell = currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex];

            }
        }

        private void SetRightClickMenuPropertiesAndShow(MouseEventArgs e, string[] specialValueColumnNames = null)
        {
            //If the right click is not on the data grid view. Return nothing
            if (currentMouseOverRowIndex == -1 || currentMouseOverColumnIndex == -1)
            {
                //Clear loaded items, reload with only the clear filter menu and show
                contextMenuStrip.Items.Clear();
                this.Load_RightClickMenuItems(CustomRightClickMenu.ClearAllFiltersOnly);
                contextMenuStrip.Show(currentDataGridView, new System.Drawing.Point(e.X, e.Y));
                return;
            }

            if (currentDataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                //Show context menu at click point
                contextMenuStrip.Show(currentDataGridView, new System.Drawing.Point(e.X, e.Y));

                //Store filter value & data type
                if(currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex].Value is null)
                {
                    filterValue = String.Empty;
                    filterValueDataType = Type.GetTypeCode(TypeCode.String.GetType());
                }
                else
                {
                    filterValue = currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex].Value.ToString();
                    filterValueDataType = Type.GetTypeCode(currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex].Value.GetType());
                }
                

                //Set special value dictionary if available
                specialValueDictionary.Clear();
                if (specialValueColumnNames == null || specialValueColumnNames.Length == 0)
                {
                    specialValueDictionary = null;
                }
                else
                {
                    //Find the column name matching you special value argument, use that to store the data in a dictionary for later use
                    int columnNumberOfSpecialValue;
                    foreach (string item in specialValueColumnNames)
                    {
                        try
                        {
                            columnNumberOfSpecialValue = currentDataGridView.Columns[item].Index;

                            if (columnNumberOfSpecialValue >= 0)
                            {
                                specialValueDictionary.Add(item, currentDataGridView[columnNumberOfSpecialValue, currentMouseOverRowIndex].Value.ToString());
                            }
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
