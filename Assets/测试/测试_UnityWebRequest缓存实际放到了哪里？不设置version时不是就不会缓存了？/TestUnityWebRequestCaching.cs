using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestUnityWebRequestCaching : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.streamingAssetsPath + "/AssetBundles/Test1_1/Windows64/rawimagea.ab";
        string assetName = "assets/test1/prefabs/rawimagea.prefab";

        //StartCoroutine(TestLoadWithNoVersion(filePath, assetName));

        //StartCoroutine(TestLoadWithVersion(filePath, assetName, 1));

        StartCoroutine(TestLoadWithVersion(filePath, assetName, 2));
    }

    IEnumerator TestLoadWithNoVersion(string uri, string assetName)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();
        yield return asyncOperation;
        if (www.isNetworkError || www.isHttpError) { Debug.LogWarning(www.error + ", uri: " + uri); yield break; }
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(www);
        GameObject asset = ab.LoadAsset<GameObject>(assetName);
        GameObject go = Instantiate(asset);
        go.transform.SetParent(transform, false);
        www.Dispose();
    }

    IEnumerator TestLoadWithVersion(string uri, string assetName, uint version)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(uri, version, 0);
        UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();
        yield return asyncOperation;
        if (www.isNetworkError || www.isHttpError) { Debug.LogWarning(www.error + ", uri: " + uri); yield break; }
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(www);
        GameObject asset = ab.LoadAsset<GameObject>(assetName);
        GameObject go = Instantiate(asset);
        go.transform.SetParent(transform, false);
        www.Dispose();
    }
}
