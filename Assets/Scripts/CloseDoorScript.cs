using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorScript : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Door.GetComponent<HandleScript>().CloseDoor();
    }
}
