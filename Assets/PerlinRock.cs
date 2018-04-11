using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinRock : MonoBehaviour {
    Mesh mesh;
    Vector3[] vertices;
    Vector3[] Changes;
    Vector3[] History;
    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        CapsuleCollider collider = transform.GetComponent<CapsuleCollider>();
        Changes = mesh.vertices;
        History = new Vector3[vertices.Length];
        bool newPoint = false;
        float randomModify = Random.value;

        for (int i = 0; i < vertices.Length; i++)
        {
            bool changed = false;
            for (int j = 0; j < i; j++) // magical seam closer
            {

                if (History[j] == vertices[i])
                {
                    vertices[i] = Changes[j];
                    newPoint = true;
                    changed = true;
                }
                else if (!changed)
                    newPoint = false;
                


            }
            Vector3 test = Vector3.zero;
            if (!changed)
            {

                float y = ((float)i / 1000);
                float x = ((float)i / 1000); // mesh with (seemingly) 64 verticies. 

                y += randomModify;
                x += randomModify; 

                test = Vector3.one * (Mathf.PerlinNoise(x, y)) * vertices[i].y;
            }

            // print(Mathf.PerlinNoise(x, y));
            History[i] = vertices[i];
            
            vertices[i] -= test;

            
            Changes[i] = vertices[i];

            changed = false; 
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
