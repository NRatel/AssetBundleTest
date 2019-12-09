using UnityEditor;
using UnityEngine;
using System.IO;

static public class ABBuildHelper
{
    static public void ClearAllABNames()
    {
        string[] allABNames = AssetDatabase.GetAllAssetBundleNames();
        for (int i = 0; i < allABNames.Length; i++)
        {
            AssetDatabase.RemoveAssetBundleName(allABNames[i], true);
        }
    }

    static public void SetABName(string assetPath, string abName, string abVariant)
    {
        AssetImporter importer = AssetImporter.GetAtPath(assetPath);
        Debug.Assert(importer != null, "资源不存在！assetPath: " + assetPath);

        importer.assetBundleName = abName;
        importer.assetBundleVariant = abVariant;
    }

    //准备输出目录
    static public string PrepareOutputFolder(string testName, BuildTarget buildTarget, bool clear = false)
    {
        string outputPath = Application.streamingAssetsPath + "/AssetBundles/" + testName + "/" + GetFolderByPlatform(buildTarget);
        
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        if (clear)
        {
            FileUtil.DeleteFileOrDirectory(outputPath);
        }
        
        return outputPath;
    }

    static public string GetFolderByPlatform(BuildTarget buildTarget)
    {
        switch (buildTarget)
        {
            case BuildTarget.Android:
                return "Android";
            case BuildTarget.iOS:
                return "IOS";
            case BuildTarget.WebGL:
                return "WebGL";
            case BuildTarget.StandaloneWindows:
                return "Windows32";
            case BuildTarget.StandaloneWindows64:
                return "Windows64";
            default:
                return null;
        }
    }
}
