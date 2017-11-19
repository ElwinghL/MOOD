using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{

    public void DisableMeshes(List<GameObject> goList)
    {
        foreach (GameObject go in goList)
        {
            MeshRenderer renderer = go.GetComponent<MeshRenderer>();
            renderer.enabled = false;
        }
    }

    public void EnableMeshes(List<GameObject> goList)
    {
        Debug.Log("Renderer Enabled");
        foreach (GameObject go in goList)
        {
            Renderer renderer = go.GetComponent<Renderer>();
            renderer.enabled = true;
        }
    }

    public void Bake()
    {
        
    }
}
