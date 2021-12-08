using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace DataManager_216
{
    public partial class frmHasher : Form
    {
        public frmHasher()
        {
            InitializeComponent();
        }

        private void frmHasher_Load(object sender, EventArgs e)
        {
            GeneralFormLibrary1.FormControls.AssignListToComboBox(comboBox_Hasher_HashAlgo, GeneralFormLibrary1.Cryptography.GetHashAlgorithmNames(), null);
        }

        private void btn_Hasher_Select_Click(object sender, EventArgs e)
        {
            tb_Hasher_File.Text = GeneralFormLibrary1.FormControls.GetPathFromFileDirectory();
        }

        private void btn_Hasher_HashText_Click(object sender, EventArgs e)
        {
            string selectedAlgo = comboBox_Hasher_HashAlgo.GetItemText(comboBox_Hasher_HashAlgo.SelectedItem);


            if (String.IsNullOrEmpty(selectedAlgo))
            {
                MessageBox.Show(null, "Please select a vaild hash algorithim", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tb_Hasher_HashedValue.Text = GeneralFormLibrary1.Cryptography.ByteArrayToHexadecimal(GeneralFormLibrary1.Cryptography.HashStringReturnByteArray(HashAlgorithm.Create(selectedAlgo), tb_Hasher_Text.Text));
            }



        }

        private void btn_Hasher_HashFile_Click(object sender, EventArgs e)
        {
            string selectedAlgo = comboBox_Hasher_HashAlgo.GetItemText(comboBox_Hasher_HashAlgo.SelectedItem);

            if (String.IsNullOrEmpty(selectedAlgo))
            {
                MessageBox.Show(null, "Please select a vaild hash algorithim", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (System.IO.File.Exists(tb_Hasher_File.Text))
                {
                    tb_Hasher_HashedValue.Text = GeneralFormLibrary1.Cryptography.ByteArrayToHexadecimal(GeneralFormLibrary1.Cryptography.HashFileReturnByteArray(HashAlgorithm.Create(selectedAlgo), tb_Hasher_File.Text));
                }
            }
        }
    }
}
