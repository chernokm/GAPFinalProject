﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFaceApple[] terrainFaces;

    private void OnValidate()
    {
        Initialize();
        GenerateMesh();
    }

    void Initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new TerrainFaceApple[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new TerrainFaceApple(meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void GenerateMesh()
    {
        foreach (TerrainFaceApple face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
    //[Range(2, 256)]
    //public int resolution = 10;

    //[SerializeField, HideInInspector]
    //MeshFilter[] meshFilters;
    //TerrainFaceApple[] terrainFaces;

    //private void OnValidate()
    //{
    //    Initialized();
    //    GenerateMesh();
    //}

    //void Initialized()
    //{
    //    if (meshFilters == null || meshFilters.Length == 0)
    //    {
    //        meshFilters = new MeshFilter[6];
    //    }

    //    terrainFaces = new TerrainFaceApple[6];

    //    Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

    //    for (int i = 0; i < 6; i++)
    //    {
    //        GameObject meshObj = new GameObject("mesh");
    //        meshObj.transform.parent = transform;

    //        meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
    //        meshFilters[i] = meshObj.AddComponent<MeshFilter>();
    //        meshFilters[i].sharedMesh = new Mesh();

    //        terrainFaces[i] = new TerrainFaceApple(meshFilters[i].sharedMesh, resolution, directions[i]);
    //    }
    //}

    //void GenerateMesh()
    //{
    //    foreach (TerrainFaceApple face in terrainFaces)
    //    {
    //        face.ConstructMesh();
    //    }
    //}
}
