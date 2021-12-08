using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManager_216
{
    public partial class frmAESEncryption : Form
    {
        public frmAESEncryption()
        {
            InitializeComponent();
        }

        private void btn_AES_Encrypt_Click(object sender, EventArgs e)
        {
            byte[] key = GeneralFormLibrary1.Cryptography.ConvertHexadecimalStringToByteArray(tb_AES_Key.Text);
            byte[] IV = GeneralFormLibrary1.Cryptography.ConvertHexadecimalStringToByteArray(tb_AES_IV.Text);
            tb_AES_EncryptedMessage.Text = GeneralFormLibrary1.Cryptography.ConvertByteArrayToHexadecimalString(GeneralFormLibrary1.Cryptography.EncryptStringToBytes_Aes(tb_AES_Message.Text, key, IV, 256));
        }

        private void btn_AES_Decrypt_Click(object sender, EventArgs e)
        {
            byte[] key = GeneralFormLibrary1.Cryptography.ConvertHexadecimalStringToByteArray(tb_AES_Key.Text);
            byte[] IV = GeneralFormLibrary1.Cryptography.ConvertHexadecimalStringToByteArray(tb_AES_IV.Text);
            byte[] secretMessage = GeneralFormLibrary1.Cryptography.ConvertHexadecimalStringToByteArray(tb_AES_EncryptedMessage.Text);
            tb_AES_DecryptedMessage.Text = GeneralFormLibrary1.Cryptography.DecryptStringFromBytes_Aes(secretMessage, key, IV, 256);
        }

        private void btn_AES_GenerateKey_Click(object sender, EventArgs e)
        {
            tb_AES_Key.Text = GeneralFormLibrary1.Cryptography.ConvertByteArrayToHexadecimalString(GeneralFormLibrary1.Cryptography.GenerateRandomKeyByteArray_Aes(256));
        }

        private void btn_AES_GenerateIV_Click(object sender, EventArgs e)
        {
            tb_AES_IV.Text = GeneralFormLibrary1.Cryptography.ConvertByteArrayToHexadecimalString(GeneralFormLibrary1.Cryptography.GenerateRandomIVByteArray_Aes());
        }

        private void frmAESEncryption_Load(object sender, EventArgs e)
        {

        }
    }
}
