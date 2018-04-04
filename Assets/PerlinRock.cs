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
        SphereCollider collider = transform.GetComponent<SphereCollider>();

        for (int i = 0; i < vertices.Length; i++)
        {
            int y = i / 64; // beautiful int rounding
            int x = i % 64; // mesh with (seemingly) 64 verticies. 

            float test = Mathf.PerlinNoise(x, y);
            vertices[i] += Vector3.left * test;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
