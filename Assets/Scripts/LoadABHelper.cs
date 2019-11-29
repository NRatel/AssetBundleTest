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
                Debug.Log(www.error + ", uri: " + uri);
                return;
            }
            using (www)
            {
                //不能多次加载重名的AssetBundle，否则会报错：
                //The AssetBundle 'XXX' can't be loaded because another AssetBundle with the same files is already loaded.
                //意味着需要自己取维护列表，已加载过的不要重新加载
                AssetBundle ab = DownloadHandlerAssetBundle.GetContent(www);
                onCompleted(ab);
            }   
        };
    }

    static public void DumpAllAssetNamesInThisAB(AssetBundle ab)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(ab.name).Append(" ").Append("内含资源：");
        string[] abNames = ab.GetAllAssetNames();
        foreach (string name in abNames)
        {
            sb.Append(name).Append("; ");
        }
        Debug.Log(sb.ToString());
    }
}
