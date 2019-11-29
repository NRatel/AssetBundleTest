using UnityEditor;
using UnityEngine;

public class BuildAB1_1 : Editor
{
    [MenuItem("NRatel/BuildAB/Test1_1")]
    static public void Build()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = BuildABHelper.PrepareOutputFolder("Test1_1", buildTarget);

        //清理旧的ABName
        BuildABHelper.ClearAllABNames();

        //设置新的ABName
        BuildABHelper.SetABName("Assets/Test1/Prefabs/RawImageA.prefab", "RawImageA.ab", "");
        BuildABHelper.SetABName("Assets/Test1/Prefabs/RawImageB.prefab", "RawImageB.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }
}
