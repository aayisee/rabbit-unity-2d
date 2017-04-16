using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameratakip : MonoBehaviour {

    public Transform karakter;
    public int a, b;

   

	void Start () {
        karakter = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	
	void Update () {
        a = 4;
        b = 3;


        transform.position = new Vector3(karakter.position.x+a, karakter.position.y+b, -10);
		
	}
}
