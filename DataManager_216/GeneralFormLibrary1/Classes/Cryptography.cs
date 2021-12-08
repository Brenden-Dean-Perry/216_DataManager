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
    public static class Cryptography
    {
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
        public static string ByteArrayToHexadecimal(byte[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append($"{array[i]:x2}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts a string into a byte array
        /// </summary>
        /// <param name="value">String to convert to byte array</param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        /// <summary>
        /// Converts a byte array to an ascii string
        /// </summary>
        /// <param name="value">Byte array to convert</param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }

        /// <summary>
        /// Encrypts a string using AES encryption
        /// </summary>
        /// <param name="plainText">The message you want to encrypt</param>
        /// <param name="Key">The shared secret password</param>
        /// <param name="IV">Initialization vector used to inject randomness into the encyption algorithim. Warning: this should be different with each message you send. Do not reuse IVs!</param>
        /// <returns></returns>
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
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
        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
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

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
