using System.Security.Cryptography;
using System.Text;

namespace Sibintek.Common
{
    public class FileAssistant
    {
        static public string GethashMD5(byte[] Data)
        {
            var tmpHash = new MD5CryptoServiceProvider().ComputeHash(Data);
            int i;
            StringBuilder sOutput = new StringBuilder(tmpHash.Length);
            for (i = 0; i < tmpHash.Length; i++)
            {
                sOutput.Append(tmpHash[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
