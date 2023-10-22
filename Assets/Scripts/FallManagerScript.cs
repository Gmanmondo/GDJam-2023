using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManagerScript : MonoBehaviour
{
    public GameObject voidfloor;

    public bool badEnd;

    public void Drop()
    {
        if (badEnd)
        {
            Destroy(voidfloor);
            Debug.Log("Fall");
            PlayerSingleton._pRef.pRB.drag = 0;
            PlayerSingleton._pRef.pCont.moveSpeed = 10;
        }
        
    }
}
