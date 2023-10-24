using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedEndingCheck : MonoBehaviour
{
    public GameObject check1;
    public GameObject check2;

    public GameObject FadeOut;
     

    public float maxTimer;
    public float remainingTimer;
    public int blockCount;
    public bool blockedIn = false;
    private void Update()
    {
        if (blockCount >= 2)    
        {
            blockedIn = true;
            FadeOut.GetComponent<WaitFadeScript>().shouldTime = true;
        }
        if (blockCount < 2)
        {
           
            FadeOut.GetComponent<WaitFadeScript>().ResetTimer();
            FadeOut.GetComponent<WaitFadeScript>().shouldTime = false;
        }
    }
}
