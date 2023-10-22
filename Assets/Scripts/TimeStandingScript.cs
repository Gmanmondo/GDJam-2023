using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStandingScript : MonoBehaviour
{
    //This script will contact fallManager regarding how long you stand in the void, and fall manager will remove colliders to cause ending 3.
    public GameObject fmGO;

    FallManagerScript fms;
    
    public float timeToStand;

    float timeStanding;

    bool startTiming;
    private void Awake()
    {
        timeStanding = timeToStand;
        fms = fmGO.GetComponent<FallManagerScript>();
    }

    private void Update()
    {
        if (startTiming)
        {
            if (timeStanding > 0.0f)
            {
                timeStanding -= Time.deltaTime;
            }
        }
        if (timeStanding <= 0.0f)
        {
            fms.Drop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            startTiming = true;
        }
    }

    


}
