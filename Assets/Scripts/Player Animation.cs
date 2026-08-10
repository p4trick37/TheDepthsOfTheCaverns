using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAnimation : MonoBehaviour
{
    public Animator ani;
    public float runTime;
    public float delay;
    public bool jumping = false;
    public bool dropping = false;
    public Player player;
    
    public ParticleSystem dropParticles;
    private ParticleSystem dropParticlesInstance;


    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Start()
    {
        delay = runTime;    
    }
    void Update()
    {
        if(dropping == true)
        {
            ani.Play("Player Drop");
            delay = 1;
        }

        if(jumping == true)
        {
            delay-= Time.deltaTime;
            if(delay <= 0)
            {
                jumping = false;
                ani.Play("Player Run");
            }
            ani.Play("Player Jump");
        }
    }

    public void PlayDrop()
    {
        jumping = false;
        dropping = true;
        dropParticlesInstance = Instantiate(dropParticles, new Vector3(transform.position.x, transform.position.y - 0.3f, 0), Quaternion.Euler(0, 0, -118));
    }

    public void PlayJump()
    {
        jumping = true;
        delay = runTime;
    }

}
