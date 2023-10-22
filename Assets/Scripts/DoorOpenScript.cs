using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    Animator anim;



    private void Start()
    {
        anim = GetComponent<Animator>();


    }


    public void Open()
    {
        anim.SetBool("OpenSignal", true);
    }
}
