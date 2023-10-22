using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenDialogueBox : MonoBehaviour
{
    public GameObject camera;
    public float distance = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit seeDialogue;
        if (Physics.Raycast(transform.position, transform.forward, out seeDialogue, Mathf.Infinity))
        {
            
        }
    }
}
