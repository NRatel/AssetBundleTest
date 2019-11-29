using UnityEngine;

public class LoadAB1 : MonoBehaviour
{
    void Start()
    {
        
    }

    //测试文件名 和 资源名
    //j：对大小写不敏感，只要字母正确，无论大小写如何都能正确加载。
    private void TestFileAndAssetName()
    {
        //string fileName = "rawimagea.ab";
        string fileName = "RAWIMAGEA.ab";
        //string fileName = "RawImageA.ab";
        //string fileName = "rawImageA.ab";

        //string assetName = "rawimagea";
        string assetName = "RAWIMAGEA";
        //string assetName = "RawImageA";
        //string assetName = "rawImageA";

        string filePath = Application.streamingAssetsPath + "/AssetBundles/Test1_1/Windows64/" + fileName;

        LoadABHelper.DownLoad(filePath, (AssetBundle ab) => {
            LoadABHelper.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>(assetName);
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });
    }
}
