﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // public bool Button_kiri, Button_kanan, Button_lompat; //Variabel untuk Button
    Text info_Heart; // Variabel Heart
    Text info_Poin; // Variabel untuk Koin
    // Text info_Amo; // Variabel untuk Amo
    public int kecepatan; //kecepatan gerak
    // 
    public int kekuatanlompat; //variabel kekuatan lompat

    public bool balik;
    public int pindah;

    Rigidbody2D lompat; //lompat sebagai nama dari Rigidbody2D

    //Variabel sensor tanah
    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    public int Heart; // Variabel nyawa Player
    public int Poin; //Variabel Koin
    // public int Amo; //Variabel Amo

    // // Start is called before the first frame update
    // //Animasi
    Animator anim; //sebagai vaiabel Animator

    Vector2 play; //variabel vector untuk posisi start
    public bool play_again; //Variabel nilai play kembali

    public GameObject UI_Win,UI_Lose; //variabel untuk menang dan kalah
    

    void Start()
    {
        lompat=GetComponent<Rigidbody2D>(); //inisialisasi awal untuk lompat
        anim=GetComponent<Animator>(); //Inisialisasi Componen Animasi
        play=transform.position; //start sebagai object transform posisi
        info_Heart = GameObject.Find("UI_Heart").GetComponent<Text>(); // Pendefinisian UI Heart sebagai componen Text
        info_Poin = GameObject.Find("UI_Poin").GetComponent<Text>(); // Pendefinisian UI Coin sebagai componen Text
        // info_Amo = GameObject.Find("UI_Amo").GetComponent<Text>(); // Pendefinisian UI Amo sebagai Componen Text
        AudioManager.instance.Play("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        //Menampilkan Heart ke UI Heart
        info_Heart.text = "Heart : " + Heart.ToString(); //Heart yaitu Variabel di Atribut Player
        //Menampilkan Heart ke UI Coin
        info_Poin.text = "Poin : " + Poin.ToString(); //Coin yaitu Variabel di Atribut Player
    //     //Menampilkan Amo ke UI Amo
    //     info_Amo.text = "Amo : " + Amo.ToString(); //Amo Yaitu Variabel di Atribut Player

        //Logic Cek Point 1
        if(play_again == true)
        {
            transform.position = play;
            play_again=false; 
        }

        //Logik Heart 
        if(Heart <= 0)
        {
            Destroy(gameObject);
            UI_Lose.SetActive(true); // UI Kalah aktif
            Time.timeScale = 0;
        }
        else if (Poin >= 3)
        {
            UI_Win.SetActive(true); //UI Menang Aktif
            Time.timeScale = 0;
        }

        //Logik untuk Animasi
        if(tanah == false)
        {
            anim.SetBool("Lompat", true);
        }
        else
        {
            anim.SetBool("Lompat", false);
        }

        //sensor tanah
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);
    //     //control player
        if (Input.GetKey (KeyCode.D)) //Key D untuk bergerak ke kanan
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime); 
            pindah=1;
            anim.SetBool("Lari", true); //animasi lari
            
        }
        else if (Input.GetKey (KeyCode.A)) //key A untuk bergerak ke kiri
        {
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah=-1;
            anim.SetBool("Lari", true); //aimasi lari

        }
        else if(tanah==true && Input.GetKey(KeyCode.Mouse1)) //Mouse0 = klik kiri Mouse1=Klik Kanan
        {
            if(pindah==1)
            {
                transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            }
            else if(pindah==-1)
            {
                transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            }
            
            anim.SetBool("Sliding", true);
        }
        else
        {
            anim.SetBool("Lari", false); //Tidak Berlari
            anim.SetBool("Sliding", false);
        }


    //     //lompat dengan klik mouse kiri
        if(tanah==true && Input.GetKey(KeyCode.Mouse0)) //Mouse0 = klik kiri Mouse1=Klik Kanan
        {
            lompat.AddForce(new Vector2(0,kekuatanlompat));
        }
    //     //Lompat dengan Button Lompat
    //     if(tanah==true && (Button_lompat==true))
    //     {
    //         lompat.AddForce(new Vector2(0,kekuatanlompat));
    //     }
        
        //logik balik badan
        if(pindah > 0 && !balik)
        {
            flip();
        }
        else if(pindah < 0 && balik)
        {
            flip();
        }

    

    //fungsi balik badan
        void flip()
        {
            balik = !balik;
            Vector3 Player = transform.localScale;
            Player.x *= -1;
            transform.localScale = Player;
        }

    // //Fungsi Button kiri
    // public void Tekan_kiri()
    // {
    //     Button_kiri = true; //Ketika di Tekan
    // }
    // public void Lepas_kiri()
    // {
    //     Button_kiri = false; //Ketika dilepas
    // }

    // //fungsi Button Kanan
    // public void Tekan_kanan()
    // {
    //     Button_kanan=true;
    // }
    // public void Lepas_kanan()
    // {
    //     Button_kanan=false;
    // }

    // //fungsi Button Lompat
    // public void Tekan_lompat()
    // {
    //     Button_lompat=true;
    // }
    // public void Lepas_lompat()
    // {
    //     Button_lompat=false;
    }
}
