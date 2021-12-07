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

        public static byte[] HashFile(HashAlgorithm hashAlgorithm, string path)
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

        public static string HashStringReturnHexadecimal(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

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

        // Display the byte array in a readable format.
        public static string ByteArrayToHexadecimal(byte[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append($"{array[i]:x2}");
            }
            return sb.ToString();
        }
    }
}
