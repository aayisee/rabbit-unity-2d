using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void level(int levelid)
    {
       SceneManager.LoadScene("strong");

Application.LoadLevel(levelid);

    }
}
