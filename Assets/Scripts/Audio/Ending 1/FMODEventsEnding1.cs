using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEventsEnding1 : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference heartRateContinuous {get; private set;}

    public static FMODEventsEnding1 instance {get; private set;}

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }
}
