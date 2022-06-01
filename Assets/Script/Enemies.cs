using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    Player KomponenPlayer; // Variabel gerak dan Semua komponennya di Script Gerak
    // Start is called before the first frame update

    //ranting
    
    void Start()
    {
        KomponenPlayer = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///Fungsi ketika menyentuh enemies
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Player")
        {
            KomponenPlayer.Heart--;//Mengurangi nilai Heart -1 dst
            KomponenPlayer.play_again=true; //player kembali start dari awal
            AudioManager.instance.Play("Hit");
        }
        // else if (other.transform.tag == "CheckPoint")
        // {
        //     KomponenPlayer.play_again = transform.position;

        // }
    }

    
}
