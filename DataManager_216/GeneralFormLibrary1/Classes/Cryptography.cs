using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Reflection;

namespace GeneralFormLibrary1
{
    public class Cryptography
    {
        RSACryptoServiceProvider RSAConnection { get; set; }

        /// <summary>
        /// Hashes a file and returns the byte array of the hash output
        /// </summary>
        /// <param name="hashAlgorithm">Selected hash algorithim</param>
        /// <param name="path">Full path name of file you want to hash</param>
        /// <returns></returns>
        public static byte[] HashFileReturnByteArray(HashAlgorithm hashAlgorithm, string path)
        {
            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);

                using (hashAlgorithm)
                {
                    FileStream fileStream = fileInfo.Open(FileMode.Open);
                    // Be sure it's positioned to the beginning of the stream.
                    fileStream.Position = 0;
                    byte[] hashValue = hashAlgorithm.ComputeHash(fileStream);
                    fileStream.Close();
                    return hashValue;
                }
            }
            else
            {
                MessageBox.Show(null, "File does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                byte[] array = new byte[0]; //empty byte array
                return array;
            }
        }

        /// <summary>
        /// Returns a byte array of the hashed string using the selected hash algorithim
        /// </summary>
        /// <param name="hashAlgorithm">Selected hash algorithim</param>
        /// <param name="input">Text you want to hash</param>
        /// <returns></returns>
        public static byte[] HashStringReturnByteArray(HashAlgorithm hashAlgorithm, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            return hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        }

        /// <summary>
        /// Returns all hash algorithim name properties from the HashAlgorithmName struct (System.Security.Cryptography)
        /// </summary>
        /// <returns></returns>
        public static List<string> GetHashAlgorithmNames()
        {
            List<string> HashAlgos = new List<string>();

            PropertyInfo[] propertyInfo = typeof(HashAlgorithmName).GetProperties();
            foreach (PropertyInfo info in propertyInfo)
            {
                if(info.Name.ToLower() != "name")
                {
                    HashAlgos.Add(info.Name);
                }
            }

            return HashAlgos;
        }

        /// <summary>
        /// Converts a byte array into a hexadecimal string
        /// </summary>
        /// <param name="array">Byte array to convert</param>
        /// <returns></returns>
        public static string ConvertByteArrayToHexadecimalString(byte[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append($"{array[i]:x2}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts a hexadecimal string into a byte array
        /// </summary>
        /// <param name="hex">Hexadecimal string value</param>
        /// <returns></returns>
        public static byte[] ConvertHexadecimalStringToByteArray(string hexString)
        {
            return Enumerable.Range(0, hexString.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Converts a string into a byte array
        /// </summary>
        /// <param name="value">String to convert to byte array</param>
        /// <returns></returns>
        public static byte[] ConvertStringToByteArray(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// Converts a byte array to an ascii string
        /// </summary>
        /// <param name="value">Byte array to convert</param>
        /// <returns></returns>
        public static string ConvertByteArrayToString(byte[] value)
        {
            if(value is null || value.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return Encoding.UTF8.GetString(value);
            }
            
        }

        /// <summary>
        /// Encrypts a string using AES encryption
        /// </summary>
        /// <param name="plainText">The message you want to encrypt</param>
        /// <param name="Key">The shared secret password</param>
        /// <param name="IV">Initialization vector used to inject randomness into the encyption algorithim. Warning: this should be different with each message you send. Do not reuse IVs!</param>
        /// <returns></returns>
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV, int KeySizeInBits = 256)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.KeySize = KeySizeInBits;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.ISO10126;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Decrypts a byte array using AES encryption
        /// </summary>
        /// <param name="cipherText">The message you want to decrypt</param>
        /// <param name="Key">The shared secret password</param>
        /// <param name="IV">Initialization vector used to inject randomness into the encyption algorithim.</param>
        /// <returns></returns>
        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV, int KeySizeInBits)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold the decrypted text.
            string plaintext = null;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.KeySize = KeySizeInBits;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.ISO10126;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        /// <summary>
        /// Generate random key and returns the byte array
        /// </summary>
        /// <param name="KeySizeInBits">Key Size in bits</param>
        /// <returns></returns>
        public static byte[] GenerateRandomKeyByteArray_Aes(int KeySizeInBits)
        {
            using (Aes aesAlg = Aes.Create())
            {
                KeySizes[] ks = aesAlg.LegalKeySizes;
                int minSize = 0;
                int maxSize = 0;
                foreach(KeySizes k in ks)
                {
                    minSize = k.MinSize;
                    maxSize = k.MaxSize;
                }

                if (aesAlg.ValidKeySize(KeySizeInBits))
                {
                    aesAlg.KeySize = KeySizeInBits;
                }
                else
                {
                    MessageBox.Show(null, "Invalid key size. Min: " + minSize.ToString() + " | Max: " + maxSize.ToString() , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    byte[] byt = new byte[0];
                    return byt;
                }    

                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }

        /// <summary>
        /// Generates random Initialization vector and returns byte array
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRandomIVByteArray_Aes()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateIV();
                return aesAlg.IV;
            }
        }

        /// <summary>
        /// Encrypt a byte array using RSA
        /// </summary>
        /// <param name="DataToEncrypt">Data to Encrypt</param>
        /// <param name="RSAKeyInfo">RSA key</param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs to include the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding OAEP padding is only available on Microsoft Windows XP or later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException to the console.
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Decrypt a byte array using RSA
        /// </summary>
        /// <param name="DataToDecrypt">Data to decrypt</param>
        /// <param name="RSAKeyInfo">RSA key</param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding OAEP padding is only available on Microsoft Windows XP or later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException to the console.
            catch (CryptographicException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Generate instance of random RSA keys
        /// </summary>
        /// <param name="keySizeInBits">Specified key size in bits</param>
        public void GenerateKeys_RSA(int keySizeInBits)
        {
            //RSAConnection = null;
            //RSAConnection.Dispose();

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            try
            {
                KeySizes[] ks = RSA.LegalKeySizes;
                int minSize = 0;
                int maxSize = 0;
                foreach (KeySizes k in ks)
                {
                    minSize = k.MinSize;
                    maxSize = k.MaxSize;
                }

                if (keySizeInBits >= minSize && keySizeInBits <= maxSize)
                {
                    if(keySizeInBits % 8 == 0)
                    {
                        RSA.KeySize = keySizeInBits;
                    }
                    else
                    {
                        MessageBox.Show(null, "Invalid key size. Must be divisiable by 8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show(null, "Invalid key size. Min: " + minSize.ToString() + " | Max: " + maxSize.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RSAConnection = RSA;
            }
            finally
            {
                //Your computer stores a log of all keys you have ever generated. You need to set to false to avoid filling your disk
                RSAConnection.PersistKeyInCsp = false;
            }
        }

        /// <summary>
        /// Gets RSA key in XML format from instance of class
        /// </summary>
        /// <param name="includePrivateParamaters">True will include private key info. False will only return public key</param>
        /// <returns></returns>
        public string GetKeyInXMLFormat_RSA(bool includePrivateParamaters)
        {
            string key = string.Empty;
            try
            {
                key = RSAConnection.ToXmlString(includePrivateParamaters);
            }
            finally
            {
                //Your computer stores a log of all keys you have ever generated. You need to set to false to avoid filling your disk
                RSAConnection.PersistKeyInCsp = false;
            }

            return key;
        }

        /// <summary>
        /// Loads RSA key values into class instance from XML format
        /// </summary>
        /// <param name="xml_key">Key in XLM format</param>
        /// <param name="includePrivateParamaters">True will include private key info. False will only return public key</param>
        /// <returns></returns>
        public RSAParameters LoadKeyFromXMLFormat_RSA(string xml_key, bool includePrivateParamaters)
        {
            RSAConnection = null;
            //RSAConnection.Dispose();
            RSAConnection = new RSACryptoServiceProvider();

            try
            {
                RSAConnection.FromXmlString(xml_key);

                if (xml_key == RSAConnection.ToXmlString(includePrivateParamaters))
                {
                    MessageBox.Show("Key imported successfully");
                }
                else
                {
                    MessageBox.Show("Key failed to import");
                }
            }
            finally
            {
                //Your computer stores a log of all keys you have ever generated. You need to set to false to avoid filling your disk
                RSAConnection.PersistKeyInCsp = false;
            }

            return RSAConnection.ExportParameters(includePrivateParamaters);
        }

    }


}

