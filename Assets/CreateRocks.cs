using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRocks : MonoBehaviour {
    public GameObject rock;
    // Use this for initialization
    Transform test; 
    int count = 0; 
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        count++;

        if (count % 120 == 0)
        {
           
            for (int i = 0; i < 20; i++)
            {
                Instantiate(rock, new Vector3(320.0f, 1.0f, 150.0f), Quaternion.identity);
            }
        }
    }
}
