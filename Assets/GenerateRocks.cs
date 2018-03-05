using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRocks : MonoBehaviour {

    Vector3 modify;
    Mesh mesh;
    Vector3[] vertices;
    Vector3[] Changes;
    Vector3[] History;
    bool newPoint = false;

    int bumpLevel = 0;
    int leftBumpLevel = 0;
    int rightBumpLevel = 0; 


    int count; 
	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        Changes = mesh.vertices;
        History = new Vector3[vertices.Length];
        modify = Vector3.zero;

        //Random RandomSize = new Random();

        float Width = (Random.value * 300) * 0.001F;
        float Height = (Random.value * 700) * 0.001F;
        float Length = (Random.value * 500) * 0.001F;

        bumpLevel = Mathf.CeilToInt((Random.value * 5));

        leftBumpLevel = Mathf.CeilToInt((Random.value * 10) + 5);
        rightBumpLevel =  Mathf.CeilToInt((Random.value * 20) + 5);


        transform.localScale += new Vector3(-Width, -Height, -Length); 

    }

    // Update is called once per frame
    void Update() {


        int i = 0;

        count++; 



        if (count < 8)
        {

            //while (i < vertices.Length)
            //{
               // vertices[i] -= Changes[i];
                //i++;
           // }

            while (i < vertices.Length)
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
                changed = false; 


                if (i % bumpLevel /*bump number*/ == 0 && !newPoint) // magical peak maker. 
                {
                    modify = Vector3.down * ((Random.value / 10) * vertices[i].y);

                    if (i % bumpLevel * leftBumpLevel == 0)
                        modify = Vector3.left * ((Random.value / 20) * vertices[i].y); // sometimes goes to the left!

                    if (i % bumpLevel * rightBumpLevel == 0)
                        modify = Vector3.left * ((Random.value / 20) * vertices[i].y); // sometimes goes to the right!!

                    History[i] = vertices[i]; 
                    vertices[i] += modify;
                    Changes[i] = vertices[i];
                    newPoint = false; 

                }
                else if (!newPoint) // magical slope do-er. 
                {
                    modify /= 3; // change this to modify the slope of neighbor verticies. 
                    History[i] = vertices[i];
                    vertices[i] += modify; 
                    Changes[i] = vertices[i];
                }



                i++;
            }
            mesh.vertices = vertices;
            mesh.RecalculateBounds();
        }

    }

    void BumpMaker(int itter)
    {
        for (int k = 0; k < itter; k++)
        {
        }
    }

    void DecideRockType()
    {


    }
}
