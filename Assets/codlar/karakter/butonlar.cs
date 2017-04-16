using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butonlar : MonoBehaviour {

    Karakter kr;


	void Start () {

        kr = GetComponent<Karakter>();
        	
	}
	
	
	void Update () {
		
	}

 public  void sol()
    {
        kr.sol = true;

    }
     public void sag()
    {
        kr.sag = true;
         

    }
    public void solup()
    {
        kr.sol = false;
    }
    public void sagup()
    {
        kr.sag = false;
    }
    public void zipla()
    {
        if (kr.yerdemi)
        {
            kr.ziplama();
        }
    }
}



