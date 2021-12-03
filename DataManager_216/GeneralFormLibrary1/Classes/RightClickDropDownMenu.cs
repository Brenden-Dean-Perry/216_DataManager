using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralFormLibrary1
{
    public class RightClickDropDownMenu
    {
        private ContextMenuStrip contextMenuStrip { get; set; }
        private DataGridView currentDataGridView { get; set; }
        private int currentMouseOverRowIndex { get; set; }
        private int currentMouseOverColumnIndex { get; set; }
        Dictionary<string, string> specialValueDictionary { get; set; } = new Dictionary<string, string>();
        private string filterValue { get; set; }
        private TypeCode filterValueDataType { get; set; }
        private List<GeneralFormLibrary1.DataModels.Model_DataGridViewFilter> dataGridViewFilters { get; set; }

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


        public enum MenuOption
        {
            DefaultMenu,
            ClearAllFiltersOnly,
            DefaultMenuWithFilters,
        }

        public RightClickDropDownMenu(ContextMenuStrip contextMenu, DataGridView dataGridView, List<DataModels.Model_DataGridViewFilter> gridViewFilters)
        {
            currentDataGridView = dataGridView;
            dataGridViewFilters = gridViewFilters;
            contextMenuStrip = contextMenu;
        }

        public void Show(RightClickDropDownMenu.MenuOption menuOption, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                SetIntialValues(e);
                Load_RightClickMenuItems(menuOption);
                SetRightClickMenuPropertiesAndShow(e);
            }
        }

        private static List<string> GetRightClickMenuItems(MenuOption rightClickMenu, DataGridView dataGridView)
        {
            List<string> menuItems = new List<string>();
            bool ValueIsNumeric = false;

            if(dataGridView.CurrentCell != null)
            {
                if (DataTypes.TypeCodeIsNumeric(Type.GetTypeCode(dataGridView.CurrentCell.Value.GetType())))
                {
                    ValueIsNumeric = true;
                }
            }

            if (rightClickMenu == MenuOption.DefaultMenu)
            {
                menuItems.Add(item_Copy);
                menuItems.Add(item_Seperator);
                menuItems.Add(item_ClearColumnFilters);
                menuItems.Add(item_ClearAllFilters);
            }
            else if(rightClickMenu == MenuOption.DefaultMenuWithFilters)
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

                menuItems.Add(item_Seperator);
                menuItems.Add(item_ClearColumnFilters);
                menuItems.Add(item_ClearAllFilters);
            }
            else
            {
                menuItems.Add(item_ClearAllFilters);
            }

            return menuItems;
        }

        private void Load_RightClickMenuItems(MenuOption rightClickMenu = MenuOption.DefaultMenu)
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
                        MessageBox.Show(null, "Error while building drop down. You cannot add a drop down item to a line seperator item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        contextMenuStrip.Items.Clear();
                        return;
                    }
                }
            }
        }

        private void Item_Click(object sender, EventArgs e)
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
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Operator.Equals, filterValue, filterValueDataType);
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
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Operator.DoNotEqual, filterValue, filterValueDataType);
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
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Operator.GreaterThan, filterValue, filterValueDataType);
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
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Operator.GreaterThanOrEqualTo, filterValue, filterValueDataType);
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
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Operator.LessThan, filterValue, filterValueDataType);
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
                DataModels.Model_DataGridViewFilter gridViewFilter = new DataModels.Model_DataGridViewFilter(currentDataGridView, currentMouseOverColumnIndex, ComparisonOperator.Operator.LessThanOrEqualTo, filterValue, filterValueDataType);
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
            else
            {
                MessageBox.Show(null, "A corresponding method has not yet been configured for this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.Load_RightClickMenuItems(MenuOption.ClearAllFiltersOnly);
                contextMenuStrip.Show(currentDataGridView, new System.Drawing.Point(e.X, e.Y));
                return;
            }

            if (currentDataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0 )
            {
                //Show context menu at click point
                contextMenuStrip.Show(currentDataGridView, new System.Drawing.Point(e.X, e.Y));

                //Store filter value & data type
                filterValue = currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex].Value.ToString();
                filterValueDataType = Type.GetTypeCode(currentDataGridView[currentMouseOverColumnIndex, currentMouseOverRowIndex].Value.GetType());

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
