using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRarity : MonoBehaviour {
    string rockRarity = ""; 
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");

        float rarity = Random.value * 1000;


        if (rarity <= 285 && rarity > 58){ // hearthstone pack statistics, roughly. 
            //Uncommon Rocks
            rockRarity = "Uncommon"; 
            rend.material.SetColor("_Color", Color.blue);
        }
        else if (rarity <= 58 && rarity > 12){
            //Rare Rocks
            rockRarity = "Rare";
            rend.material.SetColor("_Color", Color.magenta);
        }
        else if (rarity <= 12){
            //Legendary Rocks  
            rockRarity = "Legendary";
            rend.material.SetColor("_Color", Color.yellow);
            rend.material.SetColor("_EmissionColor", Color.yellow);
        }
        else{
            //common rocks. 
            rockRarity = "Common";
            rend.material.SetColor("_Color", Color.grey);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
