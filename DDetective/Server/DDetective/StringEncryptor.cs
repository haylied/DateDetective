using System.Security.Cryptography;
using System.Text;

public class StringEncryptor
{
    private readonly string _encryptionKey = string.Empty;

    public StringEncryptor(string encryptionKey)
    {
        if (string.IsNullOrEmpty(encryptionKey) || (encryptionKe
        {
            throw new ArgumentException("The encryption key shou
        }
        _encryptionKey = encryptionKey;
    }

    public string Encrypt(string plainText)
    {
        using var aesAlg = Aes.Create();

        aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);
    
        aesAlg.GenerateIV();
        var iv = aesAlg.IV;

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);

        using var ms = new MemoryStream();

        ms.Write(iv, 0, iv.Length);

        using var cs = new CryptoStream(ms, encryptor, CryptoStr
        {
            using var sw = new StreamWriter(cs);
            {
                sw.Write(plainText);
            }
        }
        return Convert.ToBase64String(ms.ToArray());
    }
}