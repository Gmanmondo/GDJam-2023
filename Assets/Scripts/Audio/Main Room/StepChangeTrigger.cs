using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepChangeTrigger : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private Footsteps stepSpeed;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            AudioManager.instance.SetFootstepSpeed(stepSpeed);
        }
    }
}