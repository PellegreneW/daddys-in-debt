using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour {

    //Shared Scripts
    GameManager gm;

    //Key Variables
    public string storeName;

    //UI Elements
    public Text txt_storeName;

    void Start () {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

	}

	public void CreateStore(string sName)
    {
        storeName = sName;
        txt_storeName.text = sName;
    }

    public void ShowItems()
    {
        gm.CreateItems(false);
    }
	
	void Update () {
		
	}
}
