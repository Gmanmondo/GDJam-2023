using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using System;

public class SceneCollideChanger : MonoBehaviour
{
    public string targetScene;

    PlayerController playerController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Console.WriteLine("The footsteps should stop!");
            PlayerSingleton._pRef.pCont.playerFootsteps.stop(STOP_MODE.IMMEDIATE);
            
            SceneManager.LoadScene(targetScene);
        }
    }
}