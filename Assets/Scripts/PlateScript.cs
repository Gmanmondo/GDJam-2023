using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    bool beenGrabbed;
    public GameObject shards;


    private void Start()
    {
        beenGrabbed = false;
    }

    public void PickUp()
    {
        beenGrabbed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Throwable" && beenGrabbed)
            Shatter();

    }

    private void Shatter()
    {
        Instantiate(shards, transform.position,transform.rotation);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.plateBreak, this.transform.position);
        Destroy(this.gameObject);
    }
}
