using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystems : MonoBehaviour {

    //Shared Scripts
    GameManager gm;
    UIManager um;

    //Game Countdown
    public int GameCountdown = 3;
    public string CountdownDisp;
    
    //Timer Countdown
    public float TimerCountdown;
    public float MaxTimer;

	void Start () {

        gm = GetComponent<GameManager>();
        um = GetComponent<UIManager>();

        StartCoroutine(StartCountdown());
	}
	
    //Timer
    IEnumerator DadMeter()
    {
        while (TimerCountdown < MaxTimer)
        {
            yield return new WaitForSeconds(0.1f);

            TimerCountdown += 2f * Time.deltaTime;

            um.Timer_slider.value = TimerCountdown;
            um.Timer_slider.maxValue = MaxTimer;

        }

        gm.EndGame();
    }

    //Countdown to start game
    public IEnumerator StartCountdown()
    {
        um.GameCountdown_txt[0].gameObject.SetActive(true);

        while (GameCountdown > -1f)
        {
            yield return new WaitForSeconds(1f);
            GameCountdown -= 1;

            CountdownDisp = "" + GameCountdown;

            if(GameCountdown == 0)
            {
                CountdownDisp = "BUY!";
                gm.PlayHit(2);
            }

            if(GameCountdown < 0)
            {
                um.GameCountdown_txt[0].gameObject.SetActive(false);

                gm.StartGame();
                StartCoroutine(DadMeter());
            }
            um.AssignText(um.GameCountdown_txt, CountdownDisp);
        }
    }
	
	void Update () {
		
	}
}
