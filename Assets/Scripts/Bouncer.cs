using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;

    private bool bounce;

    public bool bounceToTheLeft = true;
    public float horizontalMag;
    public float verticalMag;
    public Animator ani;
  


    void OnTriggerEnter2D(Collider2D collision)
    {
        bounce = true;
    }

    


    void FixedUpdate()
    {
        if(bounce == true)
        {
            ani.SetBool("shouldBounce", true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<Player>().ableToJump = false;
            if(bounceToTheLeft == true)
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalMag, verticalMag));
                playerScript.GetComponent<Player>().isMovingRight = false;
            }
            else
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalMag, verticalMag));
                playerScript.GetComponent<Player>().isMovingRight = true;
            }
            bounce = false;
        } 
    }
}
