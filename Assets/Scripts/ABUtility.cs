using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ABUtility
{
    static public void DumpAllAssetNamesInThisAB(AssetBundle ab)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(ab.name).Append(" ").Append("内含资源：");
        string[] abNames = ab.GetAllAssetNames();
        foreach (string name in abNames)
        {
            sb.Append(name).Append("; ");
        }
        Debug.Log(sb.ToString());
    }

    //static public void SaveFile(string savePath, string content)
    //{
    //    FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write);//创建写入文件 
    //    StreamWriter sw = new StreamWriter(fs);
    //    sw.Write(content);
    //    sw.Close();
    //    fs.Close();
    //}
}
