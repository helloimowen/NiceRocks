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
    int verticalBump = 0;
    int leftBumpLevel = 0;
    int rightBumpLevel = 0;
    //public GameObject rock;


    int count; 
	// Use this for initialization
	void Start () {
        /*
        for (int i = 0; i < 10; i++)
        {
            Instantiate(rock);
        }
        */ 

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        Changes = mesh.vertices;
        History = new Vector3[vertices.Length];
        modify = Vector3.zero;

        SphereCollider collider = transform.GetComponent<SphereCollider>();

        //Random RandomSize = new Random();

        float Width = (Random.value * 700) * 0.001F;
        float Height = (Random.value * 800) * 0.001F;
        float Length = (Random.value * 600) * 0.001F;





            verticalBump = Mathf.CeilToInt((Random.value * 7));
        leftBumpLevel = Mathf.CeilToInt((Random.value * 10) + 5);
        rightBumpLevel =  Mathf.CeilToInt((Random.value * 20) + 5);
        bumpLevel = Mathf.CeilToInt((Random.value * 4) + 1);


        transform.localScale += new Vector3(-Width, -Height, -Length);

        if (Width >= Length && Width >= Height)
        {
            collider.radius = transform.localScale.x;

        }
        else if (Length >= Width && Length >= Height)
        {
            collider.radius = transform.localScale.z;
        }
        else
        {
            collider.radius = transform.localScale.y;
        }



        BumpMaker(1);
    }

    // Update is called once per frame
    void Update() {


      

    }

    void BumpMaker(int itter)
    {
        int i = 0;

        count++;



        //if (count < 8)
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


                if (i % verticalBump /*bump number*/ == 0 && !newPoint) // magical peak maker. 
                {
                    modify = Vector3.down * ((Random.value / 10) * vertices[i].y);

                    if (i % verticalBump * leftBumpLevel == 0)
                        modify += Vector3.left * ((Random.value / 20) * vertices[i].y); // sometimes goes to the left!

                    if (i % verticalBump * rightBumpLevel == 0)
                        modify += Vector3.left * ((Random.value / 20) * vertices[i].y); // sometimes goes to the right!!

                    History[i] = vertices[i];
                    vertices[i] += modify * bumpLevel;
                    Changes[i] = vertices[i];
                    newPoint = false;

                }
                else if (!newPoint) // magical slope do-er. 
                {
                    modify /= 3; // change this to modify the slope of neighbor verticies. 
                    History[i] = vertices[i];
                    vertices[i] += modify * bumpLevel;
                    Changes[i] = vertices[i];
                }



                i++;
            }
            mesh.vertices = vertices;
            mesh.RecalculateBounds();
        }
    }

    void DecideRockType()
    {


    }
}
