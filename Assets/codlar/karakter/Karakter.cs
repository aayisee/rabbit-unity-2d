using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Karakter : MonoBehaviour {
    public float hiz, maxHiz, ziplamahizi;
    public bool yerdemi, ciftzipla, android, sag, sol;
    public int can, maxcan, havuc, altin, yonca;
    public Text altinmiktari, havucmiktari, yoncamiktari;
    public AudioClip[] sesler;//kare koyuncabircok sesler adam resmen dizi diyemedi ya :D
    Rigidbody2D agirlik;
    Animator anim;
    public GameObject androidpaneli;
    public GameObject[] canlar;


    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public float hiScoreCounter;
   // public float perSecond;
    public bool scoreIncreasing;

    void Start () {
        agirlik = GetComponent<Rigidbody2D> (); //burda agirliği eşitledik
        anim = GetComponent<Animator>(); //animatordeki ile burda kodda tanımlamış olduk
        can =maxcan;
        cansistemi();

	}
	
	
	void Update () {

        altinmiktari.text = "" + altin;//oyundaki text ulaşmak için kullandık kolay oldu noktadan sonra text dedik hemen.

        havucmiktari.text = "" + havuc;
        yoncamiktari.text = "" + yonca;
        if (scoreIncreasing)
        {
            scoreCount = havuc + yonca + altin;
        }
            if (scoreCount > hiScoreCounter)
        {
            hiScoreCounter = scoreCount;
        }

        scoreText.text = "Your score : " + scoreCount;
        hiScoreText.text = "HİGH score : " + hiScoreCounter;



        if (Input.GetKeyDown(KeyCode.R))//r tuşuna basınca oyunu yeniden başlatıyoruz.
        {
            Application.LoadLevel(Application.loadedLevel);
        }


        if (Input.GetKeyDown(KeyCode.Space) && yerdemi)//ikinci koşulu koymazsan yani yerdemiyi sürekli zıplama yapar havada bile ucar .
        {

            ziplama();

           
           
        }

    

          if (can <= 0)
            {
            notdie();

            }

      
    }




    private void FixedUpdate()  //bu normal update sınıfından daha cok kontrol ediyor
    {

        float h = Input.GetAxis("Horizontal"); // x eksenindeki hareketi ayarlamak için


       

        if (android)
        {

            if (sol)
            {

                anim.SetFloat("speed", Mathf.Abs(h));// yürürken hız ayarı

                anim.SetBool("yer", yerdemi);// normal oyundaki yerde ile animasyondaki yerdeyi eşitliyoz

                h = -1;
                transform.localScale = new Vector3(-1, 1);
                transform.Translate(-h * hiz * Time.deltaTime, 0, 0);
            }

            if (sag)
            {

                anim.SetFloat("speed", Mathf.Abs(h));// yürürken hız ayarı

                anim.SetBool("yer", yerdemi);// normal oyundaki yerde ile animasyondaki yerdeyi eşitliyoz

                h = 1;

                transform.localScale = new Vector3(1, 1, 1); //animeyi ters yöne yönlendiriyoz.

                transform.Translate(-h * hiz * Time.deltaTime, 0, 0);
              
            }
            if(!sol && !sag)
            {
                h = 0;
            }
        }
        else
        {

            anim.SetFloat("speed", Mathf.Abs(h));// yürürken hız ayarı

            anim.SetBool("yer", yerdemi);// normal oyundaki yerde ile animasyondaki yerdeyi eşitliyoz


            agirlik.AddForce(Vector3.right * h * hiz); //burda animasyondaki yürümeyi kontrol ediyoruz

            if (h > 0.1f)
            {

                transform.localScale = new Vector2(1, 1); //animeyi ters yöne yönlendiriyoz

            }

            if (h < -0.1f)
            {
                transform.localScale = new Vector2(-1, 1);

            }

            if (agirlik.velocity.x > maxHiz) // yürürken kaymayı durdurmak için ayarlıyoz
            {
                agirlik.velocity = new Vector2(maxHiz, agirlik.velocity.y);

            }

            if (agirlik.velocity.x < -maxHiz) //sola dogru gelirken kaymayı azaltmak için 
            {
                agirlik.velocity = new Vector2(-maxHiz, agirlik.velocity.y);

            }
        }
    }
    void notdie()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
    void OnCollisionEnter2D(Collision2D nesne)//degdiğimiz obje nesne oluyor
    {
        if (nesne.gameObject.tag == "kapi")
        {
            //Debug.Log("kapida");
            Application.LoadLevel("anamenu");
        }

        if (nesne.gameObject.tag == "tuzak")
        {

            can -= Random.Range(1, 3);//can eksilecek bir ile iki arasında bi eksilme
            GetComponent<AudioSource>().PlayOneShot(sesler[2]);
            agirlik.AddForce(Vector2.up * ziplamahizi); //tuzaga dokununca bizi yukarı iktirmasi için ayarlıyoruz.
            GetComponent<SpriteRenderer>().color = Color.yellow;//burda tuzaga dokundugunda kırmızı yapıyoruz.
            Invoke ("duzelt", 0.5f);//burda kırmızılıgın gecmesini sağlıyoruz. ama nasıl aşagıdaki voidli yazdıgımız function ile
            cansistemi();//daha sonradan da cansistemine gönderip azalma olucak
         
            
        }

    }
    void cansistemi()
    {
        for (int i =0; i<maxcan; i++)
        {
            canlar[i].SetActive(false);//uzakların kapanması için 

            
        }
        for(int a=0; a < can; a++)
        {
            canlar [a].SetActive(true);//kaçtane can varsa arttıkmak için

        }
    }
    private void OnTriggerEnter2D(Collider2D nesne)
    {

        
        if(nesne.gameObject.tag == "havuc")
        {
            havuc++;
            GetComponent<AudioSource>().PlayOneShot(sesler[0]);
            Destroy(nesne.gameObject);

        }


        if (nesne.gameObject.tag == "altin")
        {
            altin++;
            GetComponent<AudioSource>().PlayOneShot(sesler[1]);
            Destroy(nesne.gameObject);
        }



            if (nesne.gameObject.tag == "morlife")
            {
                if (can != maxcan)
                {
                can++;
                Destroy(nesne.gameObject);

                GetComponent<SpriteRenderer>().color = Color.red;
                Invoke("duzelt", 0.5f);
                cansistemi();
               
            }
            }

        if(nesne.gameObject.tag == "yonca")
        {
            yonca++;
            GetComponent<AudioSource>().PlayOneShot(sesler[3]);//ustaa:D

            Destroy(nesne.gameObject);
            GetComponent<SpriteRenderer>().color = Color.green;
            Invoke("duzelt", 0.5f);
        }
    }



    void duzelt()
    {
        GetComponent<SpriteRenderer>().color = Color.white;// tuzaktan uzaklaşınca geri b rengine dönmek için
    }



    public void ziplama()
    {
        if (yerdemi) { 

        agirlik.AddForce(Vector2.up * ziplamahizi); //yukarı basınc kuvvet yaptırıyoz.
        ciftzipla = true;

            if (ciftzipla)
            {
                agirlik.AddForce(Vector2.up * ziplamahizi);
                ciftzipla = false;
               
            }

        




        }
    }
}
