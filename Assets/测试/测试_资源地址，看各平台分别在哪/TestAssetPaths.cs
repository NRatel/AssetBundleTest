using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAssetPaths : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Application.dataPath: " + Application.dataPath);
        Debug.Log("Application.persistentDataPath: " + Application.persistentDataPath);
        Debug.Log("Application.streamingAssetsPath: " + Application.streamingAssetsPath);
        Debug.Log("Application.temporaryCachePath: " + Application.temporaryCachePath);
    }

    private void OnGUI()
    {
        GUILayout.TextArea("Application.dataPath: " + Application.dataPath);
        GUILayout.TextArea("Application.persistentDataPath: " + Application.persistentDataPath);
        GUILayout.TextArea("Application.streamingAssetsPath: " + Application.streamingAssetsPath);
        GUILayout.TextArea("Application.temporaryCachePath: " + Application.temporaryCachePath);
    }
}
