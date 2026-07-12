using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    void Update()
    {
        if(transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 25 || transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().Death();
        }
    }
}
