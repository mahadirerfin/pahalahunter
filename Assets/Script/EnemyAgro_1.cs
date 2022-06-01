using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro_1 : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private float agroRange;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;

    Vector2 play; //variabel vector untuk posisi start

    //public bool play_again; //Variabel nilai play kembali
    Player KomponenPlayer;
    

    void Start()
    {
        KomponenPlayer = GameObject.Find("Player").GetComponent<Player>();
        play=transform.position; //start sebagai object transform posisi
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {

        if(KomponenPlayer.play_again == true)
        {
            transform.position = play;
            //KomponenPlayer.play_again=false; 
        }

        float distant = Vector2.Distance(transform.position, Player.position);

        if(distant < agroRange)
        {
            ChasePlayer();
        }else
        {
            StopChasing();
        }

        Debug.Log(distant);
    }

    private void ChasePlayer()
    {
        if(transform.position.x < Player.position.x)
        {
            //-
            rb.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;

        }else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
    }

    private void StopChasing()
    {
        rb.velocity = Vector2.zero;
    }

}
