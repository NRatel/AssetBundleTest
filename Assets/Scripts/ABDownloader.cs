using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ABDownloader : MonoBehaviour
{
    static private ABDownloader sm_Instance;

    static ABDownloader()
    {
        sm_Instance = new GameObject("#ABDownloader#").AddComponent<ABDownloader>();
    }

    static public void DownLoadAB(string uri, Action<AssetBundle> onCompleted)
    {
        sm_Instance.StartCoroutine(DownLoadABCoroutine(uri, onCompleted));
    }

    static public void DownLoadABs(string[] uris, Action<AssetBundle[]> onCompleted)
    {
        sm_Instance.StartCoroutine(DownLoadABsCoroutine(uris, onCompleted));
    }

    static private IEnumerator DownLoadABCoroutine(string uri, Action<AssetBundle> onCompleted)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();

        yield return asyncOperation;

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogWarning(www.error + ", uri: " + uri);
            onCompleted?.Invoke(null);
            yield break;
        }

        using (www)
        {
            //不能多次加载重名的AssetBundle，否则会报错：
            //The AssetBundle 'XXX' can't be loaded because another AssetBundle with the same files is already loaded.
            //意味着需要自己取维护列表，已加载过的不要重新加载
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(www);
            onCompleted?.Invoke(ab);
        }
    }

    static private IEnumerator DownLoadABsCoroutine(string[] uris, Action<AssetBundle[]> onCompleted)
    {
        int count = uris.Length;
        AssetBundle[] assetBundles = new AssetBundle[uris.Length];
        foreach (string uri in uris)
        {
            DownLoadAB(uri, (ab) =>
            {
                int index = Array.IndexOf(uris, uri);
                assetBundles[index] = ab;
                count--;
                Debug.Log("uri: " + uri + ", index: " + index + ", count: " + count);
            });
        }
        yield return new WaitUntil(() => { return count <= 0; });

        onCompleted?.Invoke(assetBundles);
    }
}
