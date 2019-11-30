using UnityEditor;
using UnityEngine;

public class BuildAB1_1 : Editor
{
    // 关系：RawImageA.prefab 和 RawImageB.prefab 都依赖 TextureX.png。
    // 打包：分别打包 RawImageA.prefab 和 RawImageB.prefab。不单独打包 TextureX.png。
    // 结果：TextureX.png 被分别打入了 RawImageA.ab 和 RawImageB.ab中，造成资源冗余。
    [MenuItem("NRatel/BuildAB/Test1_1")]
    static public void Build1_1()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = ABBuildHelper.PrepareOutputFolder("Test1_1", buildTarget);

        //清理所有的ABName
        ABBuildHelper.ClearAllABNames();

        //设置新的ABName
        ABBuildHelper.SetABName("Assets/Test1/Prefabs/RawImageA.prefab", "RawImageA.ab", "");
        ABBuildHelper.SetABName("Assets/Test1/Prefabs/RawImageB.prefab", "RawImageB.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }

    // 关系：RawImageA.prefab 和 RawImageB.prefab 都依赖 TextureX.png。
    // 打包：分别打包 RawImageA.prefab 和 RawImageB.prefab。单独打包 TextureX.png。
    // 结果：RawImageA.ab 和 RawImageB.ab 都依赖了 TextureX.ab，资源不冗余，但加载 RawImageA.ab 或 RawImageB.ab 前，必须保证TextureX.ab 已加载。
    [MenuItem("NRatel/BuildAB/Test1_2")]
    static public void Build1_2()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = ABBuildHelper.PrepareOutputFolder("Test1_2", buildTarget);

        //清理所有的ABName
        ABBuildHelper.ClearAllABNames();

        //设置新的ABName
        ABBuildHelper.SetABName("Assets/Test1/Prefabs/RawImageA.prefab", "RawImageA.ab", "");
        ABBuildHelper.SetABName("Assets/Test1/Prefabs/RawImageB.prefab", "RawImageB.ab", "");
        ABBuildHelper.SetABName("Assets/Test1/Textures/TextureX.png", "TextureX.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }
}
