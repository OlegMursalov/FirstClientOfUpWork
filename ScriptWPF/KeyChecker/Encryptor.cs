using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KeyChecker
{
    public class Encryptor
    {
        private string keyCrypt;
        
        public Encryptor(string keyCrypt) 
        {
            this.keyCrypt = keyCrypt;
        }

        public string Encrypt(string str)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(str)));
        }

        public string Decrypt(string str)
        {
            string Result;
            try
            {
                CryptoStream Cs = InternalDecrypt(Convert.FromBase64String(str));
                StreamReader Sr = new StreamReader(Cs);
                Result = Sr.ReadToEnd();
                Cs.Close();
                Cs.Dispose();
                Sr.Close();
                Sr.Dispose();
            }
            catch (CryptographicException)
            {
                return null;
            }
            return Result;
        }

        private byte[] Encrypt(byte[] key)
        {
            SymmetricAlgorithm Sa = Rijndael.Create();
            ICryptoTransform Ct = Sa.CreateEncryptor((new PasswordDeriveBytes(keyCrypt, null)).GetBytes(16), new byte[16]);
            MemoryStream Ms = new MemoryStream();
            CryptoStream Cs = new CryptoStream(Ms, Ct, CryptoStreamMode.Write);
            Cs.Write(key, 0, key.Length);
            Cs.FlushFinalBlock();
            byte[] Result = Ms.ToArray();
            Ms.Close();
            Ms.Dispose();
            Cs.Close();
            Cs.Dispose();
            Ct.Dispose();
            return Result;
        }

        private CryptoStream InternalDecrypt(byte[] key)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            ICryptoTransform ct = sa.CreateDecryptor((new PasswordDeriveBytes(keyCrypt, null)).GetBytes(16), new byte[16]);
            MemoryStream ms = new MemoryStream(key);
            return new CryptoStream(ms, ct, CryptoStreamMode.Read);
        }
    }
}