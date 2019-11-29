using UnityEditor;
using UnityEngine;

public class BuildAB1_1 : Editor
{
    [MenuItem("NRatel/BuildAB/Test1_1")]
    static public void Build1()
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

    [MenuItem("NRatel/BuildAB/Test1_2")]
    static public void Build2()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = BuildABHelper.PrepareOutputFolder("Test1_2", buildTarget);

        //清理旧的ABName
        BuildABHelper.ClearAllABNames();

        //设置新的ABName
        BuildABHelper.SetABName("Assets/Test1/Prefabs/RawImageA.prefab", "RawImageA.ab", "");
        BuildABHelper.SetABName("Assets/Test1/Prefabs/RawImageB.prefab", "RawImageB.ab", "");
        BuildABHelper.SetABName("Assets/Test1/Textures/TextureX.png", "TextureX.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }
}
