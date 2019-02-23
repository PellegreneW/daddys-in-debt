using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //Countdowns
    public Text[] GameCountdown_txt;

    //Balance
    public Text[] Balance_txt;
    public Text Spent_txt;

    //Timer
    public Slider Timer_slider;

    //End Card
    public Text[] EndTitle_txt;
    public Text EndDesc_txt;

	void Start () {
		
	}
	
    public void AssignText(Text[] texts, string message)
    {
        foreach (Text t in texts)
        {
            t.text = message;
        }
    }

    public void AssignText(Text text, string message)
    {
        text.text = message;
    }
	

	void Update () {
		
	}
}
