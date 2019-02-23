using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    //Shared Scripts
    GameManager gm;
    UIManager um;
    TimeSystems ts;

    //Variables
    public bool restocking;
    public string itemName;
    public int cost;
    public Sprite itemSprite;
    public int stock;

    //UI Elements
    public Text[] txt_Cost;
    public Text txt_ItemName;
    public Text txt_Stock;
    public Image img_ItemImage;
    public Button btn_Buy;

    //Restock Panel
    public GameObject RestockPanel;
    public Slider sld_Restock;

    //Mini DataBase
    public List<string> Names = new List<string>();
    public List<Sprite> Sprites = new List<Sprite>();

	void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        um = GameObject.Find("GameManager").GetComponent<UIManager>();
        ts = GameObject.Find("GameManager").GetComponent<TimeSystems>();

        CreateItem();
    }

	void Start () {
		
	}

    void CreateItem()
    {
        cost = (int)Random.Range(50000f, 4000000);
        stock = (int)Random.Range(6f, 18f);
        itemName = Names[Random.Range(0, Names.Count)];
        itemSprite = Sprites[Random.Range(0, Sprites.Count)];
        img_ItemImage.sprite = itemSprite;
    }

    public void BuyItem()
    {
        gm.Spend(cost);

        stock -= 1;

        if(stock <= 0)
        {
            restocking = true;
            StartCoroutine(Restock());
        }
    }
	
    //Restocking
    IEnumerator Restock()
    {
        float restockTime = 0f;
        float restockMax = 3f;

        RestockPanel.SetActive(true);

        while (restockTime < restockMax)
        {
            yield return new WaitForSeconds(0.1f);

            restockTime += 2f * Time.deltaTime;

            sld_Restock.value = restockTime;
            sld_Restock.maxValue = restockMax;
        }

        stock = (int)Random.Range(8f, 22f);

        RestockPanel.SetActive(false);
        restocking = false;
    }

    //Updating UI
    void UpdateUI()
    {
        um.AssignText(txt_Cost, "" + cost.ToString("N0"));
        um.AssignText(txt_Stock, "" + stock);
        um.AssignText(txt_ItemName, itemName.ToUpper());
    }

	void Update () {

        if (gm.inPlay)
        {
            btn_Buy.interactable = true;
        }
        else
        {
            btn_Buy.interactable = false;
        }

        UpdateUI();

	}
}
