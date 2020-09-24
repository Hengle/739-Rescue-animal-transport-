using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class AdIconHandler : MonoBehaviour
{
    public List<AdIconsData> adIconData;
    [SerializeField] private int curAdIcon = 0;

    public int CurAdIcon { get => curAdIcon; set => curAdIcon = value; }

    private void Start()
    {
        adIconData = new List<AdIconsData>();
        StartCoroutine(GetOnlineData());
    }

    #region AdIcons

    public string GetCurAdIconIdentifier() {

        if (adIconData.Count <= 0)
            return null;

        if (adIconData[CurAdIcon].appIdentifier == Application.identifier)
            Inc_CurAdIconHandling();

        return adIconData[curAdIcon].appIdentifier;
    }

    public Texture Get_AdIconTexHandling()
    {
        if (adIconData.Count <= 0)
            return null;

        if (adIconData[CurAdIcon].appIdentifier == Application.identifier)
            Inc_CurAdIconHandling();

        return adIconData[curAdIcon].tex;
    }

    public void Inc_CurAdIconHandling()
    {
        if (adIconData.Count > 1)
        {
            CurAdIcon++;

            if (CurAdIcon >= adIconData.Count)
                CurAdIcon = 0;

            if (adIconData[CurAdIcon].appIdentifier == Application.identifier)
                Inc_CurAdIconHandling();
        }
    }

    IEnumerator GetOnlineData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Constants.link_AdIconFile))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                try
                {
                    string xmlData = Decrypt(www.downloadHandler.text, Constants.cipherPassword);
                    Read_N_LoadXML(xmlData);

                   // Toolbox.GameManager.Permanent_Log("Online XML Load Success");

                }
                catch (System.Exception ex)
                {
                 //   Toolbox.GameManager.Permanent_Log("ADFile_LoadError: " + www.downloadHandler.text);
                 //   Toolbox.GameManager.Permanent_Log("Loading Local File");

                    string xmlData = Decrypt(Constants.localAdIconFile, Constants.cipherPassword);
                    Read_N_LoadXML(xmlData);
                }
            }
        }
    }

    private void Read_N_LoadXML(string _xmlData)
    {

        var doc = XDocument.Parse(_xmlData);

        string field1 = "AppAds";
        string field2 = "IDs";
        string fieldName = "Package";

        for (int i = 1; i < 12; i++)
        {
            string curField = fieldName + i.ToString();
            XAttribute attr = doc.Element(field1).Element(field2).Attribute(curField);

            if (attr.Value != "")
            {

                AdIconsData data = new AdIconsData(attr.Value.ToString());
                adIconData.Add(data);
                StartCoroutine(GetTexFromLink(data.texLink, i - 1));
            }
        }
    }

    IEnumerator GetTexFromLink(string _link, int _iconID)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(_link);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            adIconData[_iconID].tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }


    public string Decrypt(string cipherText, string passPhrase)
    {

        int Keysize = 256;
        int DerivationIterations = 1000;

        // Get the complete stream of bytes that represent:
        // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
        try
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations);

            var keyBytes = password.GetBytes(Keysize / 8);
            var symmetricKey = new RijndaelManaged();

            symmetricKey.BlockSize = 256;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes);

            var memoryStream = new MemoryStream(cipherTextBytes);

            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            cipherText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
        catch (SystemException e)
        {
            cipherText = "";
        }

        return cipherText;
    }

    #endregion

}
