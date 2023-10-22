using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEventsEnding3 : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference heartRate {get; private set;}

    public static FMODEventsEnding3 instance {get; private set;}

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }
}
