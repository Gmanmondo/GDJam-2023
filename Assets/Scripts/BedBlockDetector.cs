using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedBlockDetector : MonoBehaviour
{

    public GameObject EndingCheck;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.name == "Bed")
        {
            EndingCheck.GetComponent<BedEndingCheck>().blockCount += 1;
            Debug.Log(transform.name + "is triggered");
            
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.name == "Bed")
        {
            EndingCheck.GetComponent<BedEndingCheck>().blockCount -= 1;
            Debug.Log(transform.name + "is released");
        }
    }
}
