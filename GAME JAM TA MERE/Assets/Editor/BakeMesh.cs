using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NavMeshManager))]
public class BakeMesh : Editor
{
    private Boolean _meshToggled;
    private List<GameObject> _goList;

    void OnEnable()
    {
        String goName = "unpathable";
        _goList = new List<GameObject>();
        _meshToggled = false;
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name == goName)
                _goList.Add(go);
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        NavMeshManager manager = (NavMeshManager) target;
        if (GUILayout.Button("Show Unpathable"))
        {
            manager.EnableMeshes(_goList);
        }

        if (GUILayout.Button("Hide Unpathable"))
        {
            manager.DisableMeshes(_goList);
        }
    }
}
