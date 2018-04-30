using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MeshRock : MonoBehaviour {
    Vector3[] splitVerticies;

    Vector3[] Changes;
    Vector3[] History;
    Vector3 now;
    Vector3 next;
    Vector3 between;

    bool newPoint = false;

    // Use this for initialization
    void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

       

        splitVerticies = mesh.vertices;

        Vector3[] newShape = new Vector3[splitVerticies.Length * 2];

        int count = 0;

        Changes = mesh.vertices;
        History = new Vector3[splitVerticies.Length];

        for (int i = 0; i < splitVerticies.Length; i++)
        {

            bool changed = false;
            for (int j = 0; j < i; j++) // magical seam closer
            {

                if (History[j] == splitVerticies[i])
                {
                    splitVerticies[i] = Changes[j];
                    newPoint = true;
                    changed = true;
                }
                else if (!changed)
                    newPoint = false;


            }
            changed = false;

            if (!newPoint)
            {

                now = splitVerticies[i];
                next = splitVerticies[(i + 1) % splitVerticies.Length];

                // Random.Range(0, 1);

                between = Vector3.Lerp(now, next, 0.5f);
                between += between; 


                if (count < newShape.Length - 3)
                {
                    // comments look weird here because I wanna swap these lines in and out. 

                    newShape[count] = now;
                    count++;
                    /*
                    newShape[count + splitVerticies.Length] = between;
                    /**/ 
                    newShape[count] = between;
                    count++;
                    //*/
                    //newShape[count] = next;
                    //count++;
                }
            }

        }


        mesh.vertices = newShape;
        mesh.RecalculateBounds();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
