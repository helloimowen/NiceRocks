using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRocks : MonoBehaviour {
    public GameObject rock;
    public int RockLocation;
    // Use this for initialization
    Transform test; 
    int count = 0; 
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        count++;

        if (count % 240 == 0)
        {
           
            for (int i = 0; i < 2; i++)
            {
                Instantiate(rock, new Vector3(RockLocation + 320.0f + (i * 3), 5.0f + (count / 120 * 2), 150.0f + (i * 3)), Quaternion.identity);
            }
        }
    }
}
