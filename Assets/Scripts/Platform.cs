using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject leftEdge;
    public GameObject rightEdge;

    void OnCollisionEnter2D(Collision2D collision)
    {
        leftEdge.SetActive(false);
        rightEdge.SetActive(false);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        leftEdge.SetActive(true);
        rightEdge.SetActive(true);
    }

}
