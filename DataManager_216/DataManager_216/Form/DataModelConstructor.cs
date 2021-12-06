using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralFormLibrary1.DataModels;

namespace DataManager_216
{
    public partial class frmDataModelConstructor : Form
    {
        public frmDataModelConstructor()
        {
            InitializeComponent();
        }

        private void frmDataModelConstructor_Load(object sender, EventArgs e)
        {
            GeneralFormLibrary1.DataAccess<GeneralFormLibrary1.DataModels.Model_TableName> dataAccess = new GeneralFormLibrary1.DataAccess<GeneralFormLibrary1.DataModels.Model_TableName>(GlobalAppProperties.GetCredentials());
            List<GeneralFormLibrary1.DataModels.Model_TableName> tables = dataAccess.GetDatabaseTableNames();
            GeneralFormLibrary1.FormControls.AssignListToComboBox<GeneralFormLibrary1.DataModels.Model_TableName>(comboBox_DataModelConstructor,tables,"TableName");
        }

        private void btn_DataModelConstructor_Generate_Click(object sender, EventArgs e)
        {
            tb_DataModelConstructor.Clear();
            GeneralFormLibrary1.DataModels.Model_TableName model_TableName = new GeneralFormLibrary1.DataModels.Model_TableName();
            model_TableName.TableName = comboBox_DataModelConstructor.GetItemText(comboBox_DataModelConstructor.SelectedItem).Trim().Replace(" ", ";");
            tb_DataModelConstructor.Text = GeneralFormLibrary1.DatabaseAPI.BuildImpliedDataModel(GeneralFormLibrary1.DatabaseAPI.ConnectionString("QuantDB", GlobalAppProperties.GetCredentials()), model_TableName);
        }
    }
}
