using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCollision : MonoBehaviour
{
    private bool firstCollision = true;

    private void OnCollisionEnter(Collision other)
    {
        if (firstCollision)
        {
            firstCollision = false;
        }
        else
        {
            if (other.transform.tag == "Wall")
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.bucketWall, this.transform.position);
            }
            else if (other.transform.tag == "Ground")
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.bucketGround, this.transform.position);
            }
        }
    }
}