using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerAni : MonoBehaviour
{
    public Animator ani;
    public GameObject soundObject;
    private GameObject sound;

    public void SetShouldBounce()
    {
        ani.SetBool("shouldBounce", false);
    }

    public void TurnAudioOn() 
    {
        sound = Instantiate(soundObject, new Vector2(0, 0), Quaternion.identity);
    }
    public void TurnAudioOff()
    {
        Destroy(sound);
    }
}
