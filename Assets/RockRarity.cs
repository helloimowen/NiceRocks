using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRarity : MonoBehaviour {
    string rockRarity = "";
    // Use this for initialization


	void Start () {
        Texture2D[] common = Resources.LoadAll<Texture2D>("Common");
        Texture2D[] uncommon = Resources.LoadAll<Texture2D>("Uncommon");
        Texture2D[] rare = Resources.LoadAll<Texture2D>("Rare");
        Texture2D[] legendary = Resources.LoadAll<Texture2D>("Legendary");

        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");

        float rarity = Random.value * 1000;

        if (rarity <= 285 && rarity > 58){ // hearthstone pack statistics, roughly. 
            //Uncommon Rocks
            rockRarity = "Uncommon"; 
            //rend.material.SetColor("_Color", Color.blue);
            Texture2D newTex = uncommon[Random.Range(0, uncommon.Length)];
            rend.material.SetTexture("_MainTex", newTex);
        }
        else if (rarity <= 58 && rarity > 12){
            //Rare Rocks
            rockRarity = "Rare";
            //rend.material.SetColor("_Color", Color.magenta);
            Texture2D newTex = rare[Random.Range(0, rare.Length)];
            rend.material.SetTexture("_MainTex", newTex);
        }
        else if (rarity <= 12){
            //Legendary Rocks  
            rockRarity = "Legendary";
            //rend.material.SetColor("_Color", Color.yellow);
            rend.material.SetColor("_EmissionColor", Color.yellow);
            Texture2D newTex = legendary[Random.Range(0, legendary.Length)];
            rend.material.SetTexture("_MainTex", newTex);
        }
        else{
            //common rocks. 
            rockRarity = "Common";
            //rend.material.SetColor("_Color", Color.grey);
            Texture2D newTex = common[Random.Range(0, common.Length)];
            rend.material.SetTexture("_MainTex", newTex);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
