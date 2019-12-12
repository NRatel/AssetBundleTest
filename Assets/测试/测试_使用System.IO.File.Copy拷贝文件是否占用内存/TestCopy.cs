using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestCopy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 50), "开始拷贝"))
        {
            string inputPath = @"C:\Users\Admin\Desktop\趣学Python编程\A\";
            string outputPath = @"C:\Users\Admin\Desktop\趣学Python编程\B\";

            DirectoryInfo di = new DirectoryInfo(inputPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                File.Copy(fi.FullName, outputPath + fi.Name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
