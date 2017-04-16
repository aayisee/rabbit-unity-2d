using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zemin : MonoBehaviour {

    Karakter kr;
	void Start () {
        kr = transform.root.gameObject.GetComponent<Karakter>();//ayaklarına koydugumuz box collidorı biz oluştururken karaktere sag tıklamıştık  yani burda root ona diyoruz ve ona yönlendiriyoruz.

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void OnTriggerEnter2D()
    {
        kr.yerdemi = true;

    }
    
   void OnTriggerStay2D()
    {
        kr.yerdemi = true;
    }

   void OnTriggerExit2D()
    {
        kr.yerdemi = false;

    }
}
