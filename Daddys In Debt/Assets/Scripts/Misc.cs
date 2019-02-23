using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misc : MonoBehaviour {
    
    //Variables for making my name rainbow colored
    public Text colorText;
    Color currentColor;
	
	void Start () {
		
	}
	
	void SkittlesText()
    {
        Color newCol;

        newCol = new Color(currentColor.r * 1f, currentColor.g * 1f, currentColor.b * 1f, 255f) * Time.deltaTime;

        currentColor = newCol;

        colorText.color = newCol;
    }



	void Update () {

	}
}
