using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    public bool speaking = false;
    public TextMeshProUGUI text1;
    public TextMeshPro text2;
    public TypeWriter [] writer;
    void Start()
    {
        InvokeRepeating("Dialogue",1f,10f);
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
        float rnd;
        rnd = Random.Range(0, 4);
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
}
