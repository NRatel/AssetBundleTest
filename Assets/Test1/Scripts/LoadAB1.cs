using System;
using UnityEngine;

public class LoadAB1 : MonoBehaviour
{
    void Start()
    {
        //TestIndependent();
        //TestDependent_NotPreLoadDependency();
        TestDependent_PreLoadedDependency();
    }
    
    //测试，独立ab的加载（没有依赖其他ab，其依赖的资源被直接打入）
    //结果：加载成功，显示正常
    private void TestIndependent()
    {
        string fileName = "rawimagea.ab";
        string assetName = "assets/test1/prefabs/rawimagea.prefab";

        string filePath = Application.streamingAssetsPath + "/AssetBundles/Test1_1/Windows64/" + fileName;

        LoadABHelper.DownLoadAB(filePath, (AssetBundle ab) => {
            LoadABHelper.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>(assetName);
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });
    }

    //测试，加载依赖了其他ab的ab (未预加载依赖的ab
    //结果：加载成功，但依赖的贴图显示Missing。原因是依赖的贴图所在的ab文件没有提前加载。
    private void TestDependent_NotPreLoadDependency()
    {
        string fileName = "rawimagea.ab";
        string assetName = "assets/test1/prefabs/rawimagea.prefab";

        string filePath = Application.streamingAssetsPath + "/AssetBundles/Test1_2/Windows64/" + fileName;

        LoadABHelper.DownLoadAB(filePath, (AssetBundle ab) => {
            LoadABHelper.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>(assetName);
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });
    }

    //测试，加载依赖了其他ab的ab (加载清单、再加载依赖的ab、最后加载目标ab
    //结果：加载成功，显示成功。
    private void TestDependent_PreLoadedDependency()
    {
        //注意，清单ab文件无后缀。因为它是自动生成的，与ab输出根目录同名，且不可自定义后缀。
        string manifestName = "Windows64";  
        string manifestPath = Application.streamingAssetsPath + "/AssetBundles/Test1_2/Windows64/" + manifestName;

        string fileName = "rawimagea.ab";
        string assetName = "assets/test1/prefabs/rawimagea.prefab";
        string filePath = Application.streamingAssetsPath + "/AssetBundles/Test1_2/Windows64/" + fileName;

        //加载清单
        LoadABHelper.DownLoadAB(manifestPath, (AssetBundle manifestAB) => {
            LoadABHelper.DumpAllAssetNamesInThisAB(manifestAB);

            //注意："AssetbundleManifest" 固定名称。即：清单ab文件中固定包含一个名为"AssetbundleManifest"的资源。
            AssetBundleManifest assetBundleManifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetbundleManifest");
            Debug.Log(assetBundleManifest);

            //获得依赖的ab
            string[] dependentNames = assetBundleManifest.GetAllDependencies(fileName);
            string[] dependentPaths = Array.ConvertAll<string, string>(dependentNames, (t) => { return Application.streamingAssetsPath + "/AssetBundles/Test1_2/Windows64/" + t; });

            //加载所有依赖
            LoadABHelper.DownLoadABs(dependentPaths, (abs) => {
                //加载目标ab
                LoadABHelper.DownLoadAB(filePath, (AssetBundle ab) =>
                {
                    LoadABHelper.DumpAllAssetNamesInThisAB(ab);
                    GameObject asset = ab.LoadAsset<GameObject>(assetName);
                    GameObject go = Instantiate(asset);
                    go.transform.SetParent(transform, false);
                });
            });
        });
    }
}
