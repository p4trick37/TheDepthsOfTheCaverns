using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    /*
        id 0 = upwards
        id 1 = downwards
        id 2 = rightwards
        id 3 = leftwards
    */

    public GameObject arrow;
    public GameObject spawnLocation;


    public float arrowSpeed;

    private GameObject spawnedArrow;

    public string[] travelDirections = new string[] {"upwards", "downwards", "rightwards", "leftwards"};
    public int idNumber;
    
    
    public void SpawnArrow()
    {
        if (idNumber == 0)
        {
            spawnedArrow = Instantiate(arrow, spawnLocation.transform.position, Quaternion.Euler(0, 0, 90f));
            spawnedArrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, arrowSpeed);
        }
        else if(idNumber == 1)
        {
            spawnedArrow = Instantiate(arrow, spawnLocation.transform.position, Quaternion.Euler(0, 0, -90f));
            spawnedArrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -arrowSpeed);
        }
        else if(idNumber == 2)
        {
            spawnedArrow = Instantiate(arrow, spawnLocation.transform.position, Quaternion.Euler(0, 0, 180f));
            spawnedArrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(arrowSpeed, 0);
        }
        else
        {
            spawnedArrow = Instantiate(arrow,spawnLocation.transform.position, Quaternion.identity);
            spawnedArrow.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-arrowSpeed, 0);
        }
    }
}
