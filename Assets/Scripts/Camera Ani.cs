using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAni : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public GameObject switchCameraLoc;
    public float lowerCameraPos;
    public float upperCameraPos;

    public bool shouldMove = false;

    void Update()
    {
        if(shouldMove == true)
        {
            if(player.transform.position.y > switchCameraLoc.transform.position.y)
            {
                CameraMovement("goUp");
            } 
            else if(player.transform.position.y < switchCameraLoc.transform.position.y)
            {
                CameraMovement("goDown");
            }
        }
    }


    public void CameraMovement(string location)
    {
        if (location.Equals("goDown"))
        {
            if(transform.position.y <= lowerCameraPos)
            {
                shouldMove = false;
                transform.position = new Vector3(transform.position.x, lowerCameraPos, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            }
        }
        else if(location.Equals("goUp"))
        {
            if(transform.position.y >= upperCameraPos)
            {
                shouldMove = false;
                transform.position = new Vector3(transform.position.x, upperCameraPos, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
        }
    }
}
