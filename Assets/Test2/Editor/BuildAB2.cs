using UnityEditor;
using UnityEngine;

//探究 图集（SpriteAtlas）对 AssetBundle打包的影响
public class BuildAB2 : Editor
{
    //环境：
    // 图集不打ab。
    // UINotPack.prefab 引用的 3个Sprite 没有在任何图集中。
    // UIPacked.prefab 引用的  3个Sprite 在 图集 Hero 中(Hero图集中有5个Sprite)。
    //结果：
    // UINotPack.ab 中 打入了 3个Sprite（含3个小Texture）。
    // UIPacked.ab 中 打入了 5个Sprite（含1个大Texture）, 相当于图集被打入ab。
    //结论：
    // 如果预设依赖了图集中的Sprite，且图集没打ab，则图集会被打入预设的ab中。
    [MenuItem("NRatel/BuildAB/Test2_1")]
    static public void Test2_1()
    {
        BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;

        string outputPath = ABBuildHelper.PrepareOutputFolder("Test2_1", buildTarget);

        //清理所有的ABName
        ABBuildHelper.ClearAllABNames();

        //设置新的ABName
        ABBuildHelper.SetABName("Assets/Test2/Prefabs/UINotPack.prefab", "UINotPack.ab", "");
        ABBuildHelper.SetABName("Assets/Test2/Prefabs/UIPacked.prefab", "UIPacked.ab", "");

        //开始构建
        AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, buildTarget);

        AssetDatabase.Refresh();
    }

    //一个图被多个图集引用？
    //待细测
}
