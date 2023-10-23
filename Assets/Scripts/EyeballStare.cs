using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballStare : MonoBehaviour
{
    public GameObject ems;
    EyeManagerScript m_EMS;
    private void Awake()
    {
        m_EMS = ems.GetComponent<EyeManagerScript>();
    }
    void Update()
    {
        transform.LookAt(PlayerSingleton._pRef.pTrans);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent("ObjectDetails") != null)
        {
            if (collision.gameObject.GetComponent<ObjectDetails>().sharp)
                {
                    m_EMS.EyeDefeated();
                }
        }
    }
}
