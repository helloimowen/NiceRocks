using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinRock : MonoBehaviour {
    Mesh mesh;
    Vector3[] vertices;

    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        CapsuleCollider collider = transform.GetComponent<CapsuleCollider>();

        for (int i = 0; i < vertices.Length; i++)
        {
            float y = (i / 64) / 10; // beautiful int rounding
            float x = (i % 64) / 10; // mesh with (seemingly) 64 verticies. 

            Vector3 test = Vector3.left * (Mathf.PerlinNoise(x, y) / 10) * vertices[i].y;
            vertices[i] += test;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
