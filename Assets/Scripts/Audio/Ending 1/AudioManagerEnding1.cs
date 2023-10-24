using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManagerEnding1 : MonoBehaviour
{
    private EventInstance heartRateContinuousEventInstance;

    public static AudioManagerEnding1 instance {get; private set;}

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        InitializeHeartRateMonitor(FMODEventsEnding1.instance.heartRateContinuous);
    }

    //heart rate monitor
    private void InitializeHeartRateMonitor(EventReference heartRateContinuousEventReference)
    {
        heartRateContinuousEventInstance = CreateInstance(heartRateContinuousEventReference);
        heartRateContinuousEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}

