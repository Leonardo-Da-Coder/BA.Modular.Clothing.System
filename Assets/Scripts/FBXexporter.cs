using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor.Formats.Fbx.Exporter;



public class FBXexporter : MonoBehaviour
{

    public UnityEngine.UI.Button exportButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        exportButton.onClick.AddListener(ExportGameObject);
    }

    public static void ExportGameObject()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Export");
        string filePath = Path.Combine(Application.dataPath, "MyObject.fbx");
        ModelExporter.ExportObject(filePath, gameObject);
    }
}
