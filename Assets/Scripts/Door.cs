using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string[] scenes = new string[] {"Level 1", "Level 2", "Level 3", "Level 4", "Level 5"};
    public int level;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(scenes[level]);
        }
    }
}
