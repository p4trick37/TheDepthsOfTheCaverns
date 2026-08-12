using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed;
    public bool isMovingRight = true;
    public bool ableToJump = false;
    public bool jump = false;
    public Rigidbody2D rb;
    public SpriteRenderer spr;

    public float jumpHeight;

    public bool allowToDrop;
    
    private bool collidedWithEdge = false;
    public bool isAlive;
    public GameObject spawnPoint;
    int count = 0;

    public GameObject playerCamera;

    public PlayerAnimation playerAni;
    public ShooterController shooterController;
    public GameObject runningAudio;
    private GameObject runAud;
    public static int deathCounter;
    public DeathCounter numberOfDeaths;
    public bool isLevel1;
    



    void Start()
    {
        allowToDrop = true;
        if(isLevel1 == true)
        {
            deathCounter = 0;
        }


    }


    void Update()
    {
        //Handle Jumping
        if(ableToJump == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                jump = true;
                ableToJump = false;
                playerAni.PlayJump();
            }
        }
        else if(ableToJump == false)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                allowToDrop = true;
                playerAni.PlayDrop();
            }
        }

        numberOfDeaths.textDeathCounter = deathCounter;
    }

    public void Movement(bool shouldMove)
    {
        if (shouldMove == true)
        {
            if(isMovingRight == true)
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                spr.flipX = false;
            }
            else
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
                spr.flipX = true;
            } 
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        
    }

    void FixedUpdate()
    {
        if(allowToDrop == false && collidedWithEdge == false)
        {
            Movement(true);
        }
        else
        {
            Movement(false);
            freezePosition();
        }

        Jump();
    }

    public void Jump()
    {
        if(jump == true)
        {
            rb.AddForce(new Vector2(0, 1) * jumpHeight);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Right Wall")
        {
            isMovingRight = false;
        } 
        if (collision.gameObject.name == "Left Wall")
        {
            isMovingRight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
           if(collision.gameObject.CompareTag("Jumpable Surface") || collision.gameObject.CompareTag("Bouncer"))
           {
                count = 0;
                ableToJump = true;
                allowToDrop = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
           }

           if(collision.gameObject.CompareTag("Jumpable Surface"))
           {
                playerAni.ani.Play("Player Run"); 
                playerAni.dropping = false;
                runAud = Instantiate(runningAudio, new Vector2(0, 0), Quaternion.identity);
           }

           if(collision.gameObject.CompareTag("Edge"))
           {
                collidedWithEdge = true;
           }

           if(collision.gameObject.name.Equals("HighZone"))
           {
                playerCamera.GetComponent<CameraAni>().shouldMove = true;
                shooterController.inUpperZone = true;
                shooterController.inLowerZone = false;
           }
           if(collision.gameObject.name.Equals("LowZone"))
           {
                playerCamera.GetComponent<CameraAni>().shouldMove = true;
                shooterController.inUpperZone = false;
                shooterController.inLowerZone = true;
           }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Jumpable Surface"))
        {
            ableToJump = false;
            if(runAud != null)
            {
                Destroy(runAud);
            }
        }

        if(collision.gameObject.CompareTag("Edge"))
        {
            collidedWithEdge = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("HighZone"))
        {
            playerCamera.GetComponent<CameraAni>().CameraMovement("goUP");
        }
    }

    public void Death()
    {
        transform.position = spawnPoint.transform.position;
        isMovingRight = true;
        allowToDrop = true;
        spr.flipX = false;
        playerCamera.transform.position = new Vector3(0, 0, -10);
        deathCounter++;
    }

    void freezePosition() 
    {
        count++;
        if(count == 1)
        {
            rb.linearVelocity = new Vector3(0,0);
        }
        
        if(count > 10) 
        {
            count = 1;
        }
    }
}
