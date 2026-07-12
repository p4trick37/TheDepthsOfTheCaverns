using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public Player player;
    public GameObject playerCamera;
    void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<Player>().Death();
        playerCamera.transform.position = new Vector3(0, 0, -10);
    }
}
