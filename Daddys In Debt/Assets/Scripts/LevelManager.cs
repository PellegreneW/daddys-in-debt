using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	
	void Start () {
		
	}
	
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
	
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

	void Update () {
		
	}
}
