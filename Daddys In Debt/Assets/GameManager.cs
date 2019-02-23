using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Shared Scripts
    TimeSystems tms;
    UIManager um;

    //Game State
    public bool inPlay;
    public bool gameWon;

    //Variables
    public float Balance;
    public float StartingBalance;
    public float TotalSpent;

    //Scene
    public GameObject ItemsPanel;
    public GameObject TabsPanel;
    public GameObject EndPanel;
    public GameObject CardPanel;

    //Stock Item
    public GameObject Item;
    public List<GameObject> Items = new List<GameObject>(); 

    //Tab
    public GameObject Tab;
    public List<string> StoreNames = new List<string>();

    //Receipt Pop Up
    public GameObject popUp;

    //Audio Clips
    public AudioSource mainSource;
    public AudioSource hitSource;
    public List<AudioClip> hits = new List<AudioClip>();

	void Start () {

        um = GetComponent<UIManager>();
        tms = GetComponent<TimeSystems>();
	}
	
    //Starting a new game
    public void StartGame()
    {
        inPlay = true;

        CreateItems(true);
        CreateTabs();

    }
    //Creating Items
    public void CreateItems(bool newGame)
    {
        if (!newGame)
        {
            foreach(GameObject i in Items)
            {
                Destroy(i);
            }

            Items.Clear();
        }

        for (int i = 0; i < 9; i++)
        {
            GameObject newItem = Instantiate(Item, ItemsPanel.transform, false);
            Items.Add(newItem);
        }
    }
    //Creating Tabs
    public void CreateTabs()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject newTab = Instantiate(Tab, TabsPanel.transform, false);
            newTab.GetComponent<Tab>().CreateStore(StoreNames[i].ToUpper());
        }
    }

    public void Spend(float value)
    {
        Balance -= value;
        TotalSpent += value;

        //Sending Pop up
        GameObject newPop = Instantiate(popUp, CardPanel.transform, false);
        newPop.GetComponent<PopUp>().AssignPopup(value);

        //Audio Hit
        PlayHit(0);
    }

    //Audio Hits
    public void PlayHit(int clipNum)
    {
        hitSource.PlayOneShot(hits[clipNum]);
    }

    public void EndGame()
    {
        inPlay = false;

        EndPanel.SetActive(true);

        um.AssignText(um.Spent_txt, "$" + TotalSpent.ToString("N0"));

        mainSource.Stop();
        mainSource.PlayOneShot(hits[2]);

        if(Balance < 0)
        {
            gameWon = true;

            um.AssignText(um.EndTitle_txt, "DAD'S IN DEBT!");
            um.AssignText(um.EndDesc_txt, "CONGRATS! YOU CLICKED YOUR DAD INTO DEBT AND NOW HIS LIFE IS RUINED!");
        }
        else
        {
            gameWon = false;

            um.AssignText(um.EndTitle_txt, "CARD CANCELLED!");
            um.AssignText(um.EndDesc_txt, "YOU FAILED TO GET YOUR DAD INTO DEBT AND NOW YOU'RE GROUNDED.");
        }
    }


	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Spend(10f);
        }

        um.AssignText(um.Balance_txt, ("" + Balance.ToString("N0")));
    }
}
