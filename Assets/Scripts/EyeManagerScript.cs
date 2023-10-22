using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManagerScript : MonoBehaviour
{


    
    public GameObject Eye;
    public GameObject bars;

    public GameObject Door;
    private void Start()
    {
        Eye.SetActive(false);
        bars.SetActive(true);


    }
    public void BrickBroken()
    {
        bars.SetActive(false);
        Eye.SetActive(true);
        Door.GetComponent<HandleScript>().eyeAngry = true;
        Door.GetComponent<ObjectDetails>().description = "You are denied exit";
    }

    public void EyeDefeated()
    {
        Eye.SetActive(false);
        Door.GetComponent<HandleScript>().eyeAngry = false;
        Door.GetComponent<ObjectDetails>().description = "Press [E] to be Free";
    }
}
