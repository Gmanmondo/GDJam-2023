using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitFadeScript : MonoBehaviour
{
    public float timetoWait;
    public float timer;
    public bool fading;

    public string nextScene;
    public float modifier; //modify how fast it fades


    private void Awake()
    {
        timer = timetoWait;
    }

    private void Update()
    {
        timer -= Time.deltaTime ;
        if (timer <= 0.0)
        {
            if (!fading)
            {
                GetComponent<Animator>().SetBool("fadeout", true);
                fading = true;
                timer = 2;
            }
            else
            {
                SceneManager.LoadScene(nextScene);
            }

        }
      
            
    }

    
}
