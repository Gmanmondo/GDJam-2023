using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScript : MonoBehaviour
{

    public bool eyeAngry;
    public bool doorOpen;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        eyeAngry = false;
        doorOpen = false;
        anim = GameObject.Find("Door").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoorAttempt()
    {
        if (!eyeAngry && !doorOpen)
        {
            anim.SetBool("OpenSignal", true);
            doorOpen = true;
        }


    }

    public void CloseDoor()
    {
        anim.SetBool("CloseSignal", true);
    }
}
