using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

	
	void Awake()
    {
        StartCoroutine(kill());
    }
	
    public void AssignPopup(float val)
    {
        string newVal = "-$" + val.ToString("N0");

        Text newText = gameObject.GetComponent<Text>();

        newText.text = newVal;
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }

	void Update () {
		
	}
}
