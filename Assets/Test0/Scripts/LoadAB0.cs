using UnityEngine;

public class LoadAB0 : MonoBehaviour
{
    void Start()
    {
        TestPath();
        //TestDuplicateNameAsset();
    }

    //测试 文件名、资源名
    //结论：
    //  1、利用“UnityWebRequestAssetBundle.GetAssetBundle + www.SendWebRequest” 下载 AB 时，文件名后缀可有可无，且对大小写不敏感。
    //  2、利用“ab.LoadAsset” 加载AB中的资源时，可使用全路径（必须从Assets开始、必须带后缀）,也可直接使用文件名（可带后缀也可不带），对大小写不敏感。
    private void TestPath()
    {
        //string fileName = "cube";             //可以
        //string fileName = "cube.ab";          //可以
        //string fileName = "CUBE.ab";          //可以
        string fileName = "Cube.ab";          //可以
        //string fileName = "cUbE.ab";          //可以

        //string assetName = "cube";            //可以
        //string assetName = "CUBE";            //可以       
        //string assetName = "Cube";            //可以
        //string assetName = "cUbE";            //可以
        //string assetName = "cube.prefab";     //可以
        string assetName = "assets/test0/prefabs/cube.prefab";    //可以
        //string assetName = "Assets/test0/prefabs/CUBE.prEFab";    //可以
        //string assetName = "test0/prefabs/cube.prefab";           //不行
        //string assetName = "assets/test0/prefabs/cube";           //不行

        string filePath = Application.streamingAssetsPath + "/AssetBundles/test0_1/Windows64/" + fileName;

        ABDownloader.DownLoadAB(filePath, (AssetBundle ab) => {
            ABUtility.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>(assetName);
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });
    }

    //测试 将几个同名（不同类型、不同路径）的资源，打入同一个ab文件 时的加载
    //结论：
    //  1、使用资源名 或 资源全路径 仍然都可以加载。
    //  2、当使用 资源名时，会采用第一个与加载处类型匹配的资源（ab.LoadAsset<T>，可转为T类型的资源）。
    //  3、同一个ab包内，尽量不要存在同类型的重名资源。
    private void TestDuplicateNameAsset()
    {
        string fileName = "Sphere.ab";

        string assetName = "Sphere";                                  //可以，会采用 "Assets/test0/prefabs/Y/Sphere.prefab"
        //string assetName = "Assets/test0/prefabs/X/Sphere.png";       //不可以，在 ab.LoadAsset<GameObject> 处报错，因为类型不匹配
        //string assetName = "Assets/test0/prefabs/Y/Sphere.prefab";    //可以
        //string assetName = "Assets/test0/prefabs/Z/Sphere.prefab";    //可以

        string filePath = Application.streamingAssetsPath + "/AssetBundles/test0_2/Windows64/" + fileName;

        ABDownloader.DownLoadAB(filePath, (AssetBundle ab) => {
            ABUtility.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>(assetName);
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });
    }
}
