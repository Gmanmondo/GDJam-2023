using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    public BedEndingCheck bed;
    public bool brick;
    public bool speaking = false;
    public bool eyeDefeat;
    public TextMeshProUGUI text1;
    public TextMeshPro text2;
    public TypeWriter [] writer;
    void Start()
    {
        InvokeRepeating("Dialogue",0f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        speaking = false;
    }

    void Dialogue()
    {
        //Note for Ethan, these are the lines ruining everything for me
        /*
        for (int i = 0; i < 2; i++)
        {
            writer[i].StartCoroutine("TypeWriterText");
            writer[i].StartCoroutine("TypeWriterTMP");

        }
        */
        speaking = true;
        int rnd;
        rnd = Random.Range(1, 4);
        Debug.Log(rnd);
        if (!bed.blockedIn && !brick)
        {
            switch (rnd)
            {
                case 1:
                    text1.text = "It's your time to leave";
                    text2.text = "It's your time to leave";
                    break;
                case 2:
                    text1.text = "Why are you still here, can't you see the door?";
                    text2.text = "Why are you still here, can't you see the door?";
                    break;
                case 3:
                    text1.text = "There's only one way out of here";
                    text2.text = "There's only one way out of here";
                    break;
            }
        }

        if (brick)
        {
            text1.text = "You idiot, look what you've done to yourself";
            text2.text = "You idiot, look what you've done to yourself";
        }

        if (bed.blockedIn)
        {
            text1.text = "Coward! This could have all been over";
            text2.text = "Coward! This could have all been over";
        }
        
        

    }
}
