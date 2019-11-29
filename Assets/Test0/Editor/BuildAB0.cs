using UnityEditor;
using UnityEngine;

public class BuildAB0 : Editor
{
    [MenuItem("NRatel/BuildAB/Test0_1")]
    static public void Build0_1()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = BuildABHelper.PrepareOutputFolder("Test0_1", buildTarget);

        //清理所有的ABName
        BuildABHelper.ClearAllABNames();

        //设置新的ABName
        BuildABHelper.SetABName("Assets/Test0/Prefabs/Cube.prefab", "Cube.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }

    [MenuItem("NRatel/BuildAB/Test0_2")]
    static public void Build0_2()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = BuildABHelper.PrepareOutputFolder("Test0_2", buildTarget);

        //清理所有的ABName
        BuildABHelper.ClearAllABNames();

        //设置新的ABName
        //将几个不同文件夹下的 Sphere 打入同一个AB文件中
        BuildABHelper.SetABName("Assets/Test0/Prefabs/X/Sphere.png", "Sphere.ab", "");
        BuildABHelper.SetABName("Assets/Test0/Prefabs/Y/Sphere.prefab", "Sphere.ab", "");
        BuildABHelper.SetABName("Assets/Test0/Prefabs/Z/Sphere.prefab", "Sphere.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }
}
