using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class LoadABHelper
{
    static public void DownLoad(string uri, Action<AssetBundle> onCompleted)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();
        asyncOperation.completed += (ao) =>
        {
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                return;
            }
            using (www)
            {
                onCompleted(DownloadHandlerAssetBundle.GetContent(www));
            }   
        };
    }

    static public void DumpAllAssetNamesInThisAB(AssetBundle ab)
    {
        StringBuilder sb = new StringBuilder() ;
        string[] abNames = ab.GetAllAssetNames();
        foreach (string name in abNames)
        {
            sb.Append(name).Append(",");
        }
        Debug.Log(sb.ToString());
    }
}
