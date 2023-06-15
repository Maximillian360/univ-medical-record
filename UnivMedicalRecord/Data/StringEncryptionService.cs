﻿using System.Text;

namespace UniversityMedicalRecord.Data;
using System.Security.Cryptography;
public class StringEncryptionService
{
    private byte[] IV =
    {
        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
    };
    private byte[] DeriveKeyFromPassword(string password)
    {
        var emptySalt = Array.Empty<byte>();
        var iterations = 1000;
        var desiredKeyLength = 16; // 16 bytes equal 128 bits.
        var hashMethod = HashAlgorithmName.SHA384;
        return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
            emptySalt,
            iterations,
            hashMethod,
            desiredKeyLength);
    }
    public byte[] Encrypt(string clearText, string passphrase)
    {
        using Aes aes = Aes.Create();
        aes.Key = DeriveKeyFromPassword(passphrase);
        aes.IV = IV;
        
        using MemoryStream output = new();
        using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
        cryptoStream.FlushFinalBlockAsync();
        return output.ToArray();
    }  
    public string Decrypt(byte[] encrypted, string passphrase)
    {
        using Aes aes = Aes.Create();
        aes.Key = DeriveKeyFromPassword(passphrase);
        aes.IV = IV;
        
        using MemoryStream input = new(encrypted);
        using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using MemoryStream output = new();
        cryptoStream.CopyToAsync(output);
        return Encoding.Unicode.GetString(output.ToArray());
    }
}