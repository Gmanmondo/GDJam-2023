using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BucketCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
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