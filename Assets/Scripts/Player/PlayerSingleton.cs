using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton _pRef;


    public Transform pTrans { get; protected set; }
    public CapsuleCollider pCollide { get; protected set; }
    public Rigidbody pRB { get; protected set; }
   

    public void Awake()
    {
        if (_pRef == null)
        {
            _pRef = this;
        }

        pTrans = GetComponent<Transform>();

        pRB = GetComponent<Rigidbody>();

        pCollide = GetComponentInChildren<CapsuleCollider>();
    }
}
