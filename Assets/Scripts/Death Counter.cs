using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public static int deathCounter;
    public TMP_Text text;
    public Player player;
    public int textDeathCounter;
    void Update()
    { 
        text.text = "Death Counter " + textDeathCounter;
    }
}
