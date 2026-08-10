using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public List<GameObject> upperShooters = new List<GameObject>();
    public List<GameObject> lowerShooters = new List<GameObject>();
    public bool inUpperZone = false;
    public bool inLowerZone = true;

    void Update()
    {
        if(inLowerZone == true)
        {
            for(int i = 0; i < upperShooters.Count; i++)
            {
                upperShooters[i].SetActive(false);
            }

            for(int i = 0; i < lowerShooters.Count; i++)
            {
                lowerShooters[i].SetActive(true);
            }
        }
        else if(inUpperZone == true)
        {
            for(int i = 0; i < upperShooters.Count; i++)
            {
                upperShooters[i].SetActive(true);
            }

            for(int i = 0; i < lowerShooters.Count; i++)
            {
                lowerShooters[i].SetActive(false);
            }
        }
    }


}
