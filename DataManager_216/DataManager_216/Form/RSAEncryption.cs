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
    public partial class frmRSAEncryption : Form
    {
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;
        public frmRSAEncryption()
        {
            InitializeComponent();
        }

        private void btn_RSA_GenerateKeys_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.Cryptography crypto = new GeneralFormLibrary1.Cryptography();
            crypto.GenerateKeys_RSA(512);
            tb_RSA_PrivateKey.Text = crypto.GetKeyInXMLFormat_RSA(true);
            tb_RSA_PublicKey.Text = crypto.GetKeyInXMLFormat_RSA(false);
        }

        private void btn_RSA_LoadKeys_Click(object sender, EventArgs e)
        {
            GeneralFormLibrary1.Cryptography crypto = new GeneralFormLibrary1.Cryptography();
            tb_RSA_PublicKey.Text = tb_RSA_PublicKey.Text.Trim();
            tb_RSA_PrivateKey.Text = tb_RSA_PrivateKey.Text.Trim();

            if (!String.IsNullOrEmpty(tb_RSA_PublicKey.Text))
            {
                _publicKey = crypto.LoadKeyFromXMLFormat_RSA(tb_RSA_PublicKey.Text, false);
            }

            if (!String.IsNullOrEmpty(tb_RSA_PrivateKey.Text))
            {
                _privateKey = crypto.LoadKeyFromXMLFormat_RSA(tb_RSA_PrivateKey.Text, true);
            }
        }

        private void btn_RSA_Encrypt_Click(object sender, EventArgs e)
        {
            byte[] message = GeneralFormLibrary1.Cryptography.ConvertStringToByteArray(tb_RSA_Message.Text);
            tb_RSA_CipherText.Text = GeneralFormLibrary1.Cryptography.ConvertByteArrayToHexadecimalString(GeneralFormLibrary1.Cryptography.RSAEncrypt(message, _publicKey, false));
        }

        private void btn_RSA_Decrypt_Click(object sender, EventArgs e)
        {
            byte[] encryptedMessage = GeneralFormLibrary1.Cryptography.ConvertHexadecimalStringToByteArray(tb_RSA_CipherText.Text);
            tb_RSA_DecryptedMessage.Text = GeneralFormLibrary1.Cryptography.ConvertByteArrayToString(GeneralFormLibrary1.Cryptography.RSADecrypt(encryptedMessage, _privateKey, false));
        }

        private void frmRSAEncryption_Load(object sender, EventArgs e)
        {

        }
    }
}
