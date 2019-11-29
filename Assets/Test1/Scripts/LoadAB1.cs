using UnityEngine;

public class LoadAB1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string assetPath1_1A = @"E:\GitHub\AssetTest\Assets\StreamingAssets\AssetBundles\Test1_1\Windows64\" + "RawImageA.ab";
        //string assetPath1_2A = @"E:\GitHub\AssetTest\Assets\StreamingAssets\AssetBundles\Test1_1\Windows64\" + "RawImageA.ab";

        LoadABHelper.DownLoad(assetPath1_1A, (AssetBundle ab) => {
            LoadABHelper.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>("RawImageA");
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });

        LoadABHelper.DownLoad(assetPath1_1A, (AssetBundle ab) => {
            LoadABHelper.DumpAllAssetNamesInThisAB(ab);

            GameObject asset = ab.LoadAsset<GameObject>("RawImageA");
            GameObject go = Instantiate(asset);
            go.transform.SetParent(transform, false);
        });
    }
}
