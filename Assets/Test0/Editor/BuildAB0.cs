﻿using UnityEditor;
using UnityEngine;

//探究基本打包 和 资源加载路径
//探究同名资源打包和加载
public class BuildAB0 : Editor
{
    [MenuItem("NRatel/BuildAB/Test0_1")]
    static public void Build0_1()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = ABBuildHelper.PrepareOutputFolder("Test0_1", buildTarget);

        //清理所有的ABName
        ABBuildHelper.ClearAllABNames();

        //设置新的ABName
        ABBuildHelper.SetABName("Assets/Test0/Prefabs/Cube.prefab", "Cube.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }

    [MenuItem("NRatel/BuildAB/Test0_2")]
    static public void Build0_2()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = ABBuildHelper.PrepareOutputFolder("Test0_2", buildTarget);

        //清理所有的ABName
        ABBuildHelper.ClearAllABNames();

        //设置新的ABName
        //将几个不同文件夹下的 Sphere 打入同一个AB文件中
        ABBuildHelper.SetABName("Assets/Test0/Prefabs/X/Sphere.png", "Sphere.ab", "");
        ABBuildHelper.SetABName("Assets/Test0/Prefabs/Y/Sphere.prefab", "Sphere.ab", "");
        ABBuildHelper.SetABName("Assets/Test0/Prefabs/Z/Sphere.prefab", "Sphere.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }
}
