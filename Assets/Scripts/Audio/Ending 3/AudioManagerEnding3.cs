using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManagerEnding3 : MonoBehaviour
{
    private EventInstance heartRateEventInstance;

    public static AudioManagerEnding3 instance {get; private set;}

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
        InitializeHeartRateMonitor(FMODEventsEnding3.instance.heartRate);
    }

    //heart rate monitor
    private void InitializeHeartRateMonitor(EventReference heartRateEventReference)
    {
        heartRateEventInstance = CreateInstance(heartRateEventReference);
        heartRateEventInstance.start();
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
