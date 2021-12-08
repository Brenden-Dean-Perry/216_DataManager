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
        private string _privateKeyString;
        private string _publicKeyString;
        public frmRSAEncryption()
        {
            InitializeComponent();
        }

        private void btn_RSA_GenerateKeys_Click(object sender, EventArgs e)
        {
            using(RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                try
                {
                    // Do something with the key...
                    _publicKey = RSA.ExportParameters(false);
                    _privateKey = RSA.ExportParameters(true);
                    _publicKeyString = RSA.ToXmlString(false);
                    _privateKeyString = RSA.ToXmlString(true);
                }
                finally
                {
                    //Your computer stores a log of all keys you have ever generated. You need to set to false to avoid filling your disk
                    RSA.PersistKeyInCsp = false;
                }

                tb_RSA_PrivateKey.Text = _privateKeyString;
                tb_RSA_PublicKey.Text = _publicKeyString;

            }
        }
    }
}
