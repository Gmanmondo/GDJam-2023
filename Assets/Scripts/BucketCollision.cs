using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Wall")
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.bucketWall, this.transform.position);
        }
    }
}
