using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManagerScript : MonoBehaviour
{


    public GameObject brickBlood;
    public GameObject Eye;
    public GameObject bars;
    public GameObject playerEye;
    public GameObject Door;
    public GameObject WinDoor;

    public GameObject FMS;
    private void Start()
    {
        Eye.SetActive(false);
        bars.SetActive(true);


    }
    public void BrickBroken()
    {
        brickBlood.SetActive(true);
        bars.SetActive(false);
        Eye.SetActive(true);
        Door.GetComponent<HandleScript>().eyeAngry = true;
        Door.GetComponent<ObjectDetails>().description = "You are denied exit";
        PlayerSingleton._pRef.pCont.moveSpeed = 4;
    }

    public void EyeDefeated()
    {
        Eye.SetActive(false);
        Door.GetComponent<HandleScript>().eyeAngry = false;
        Door.GetComponent<ObjectDetails>().description = "Press [E] to be Free";
        FMS.GetComponent<FallManagerScript>().badEnd = false;
        PlayerSingleton._pRef.pCont.moveSpeed = 2;
        WinDoor.SetActive(true);
        playerEye.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.eyeGouge, this.transform.position);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.hurt, this.transform.position);
    }
}
