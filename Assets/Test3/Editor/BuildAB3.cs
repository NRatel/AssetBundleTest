using UnityEditor;
using UnityEngine;

//探究 AssetBundle 循环依赖问题

//结果： Manifest 中的依赖关系为空
//ManifestFileVersion: 0
//CRC: 1939429471
//AssetBundleManifest:
//  AssetBundleInfos:
//    Info_0:
//      Name: bundle1
//      Dependencies: {}
//    Info_1:
//      Name: bundle2
//      Dependencies: {}
public class BuildAB3 : Editor
{
    [MenuItem("NRatel/BuildAB/Test3")]
    static public void Build3()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = ABBuildHelper.PrepareOutputFolder("Test3", buildTarget);

        //清理所有的ABName
        ABBuildHelper.ClearAllABNames();

        //设置新的ABName
        ABBuildHelper.SetABName("Assets/Test3/Prefabs/RawImageA.prefab", "bundle1", ".ab");
        ABBuildHelper.SetABName("Assets/Test3/Textures/TextureY.png", "bundle1", ".ab");

        ABBuildHelper.SetABName("Assets/Test3/Prefabs/RawImageB.prefab", "bundle2", ".ab");
        ABBuildHelper.SetABName("Assets/Test3/Textures/TextureX.png", "bundle2", ".ab");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);
        
        AssetDatabase.Refresh();
    }
}
