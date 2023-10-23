using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool speaking = true;
    public TextMeshProUGUI [] text;
    void Start()
    {
        InvokeRepeating("Dialogue",1f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dialogue()
    {
        float rnd;
        rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
