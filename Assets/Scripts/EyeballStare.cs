using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballStare : MonoBehaviour
{
        void Update()
    {
        transform.LookAt(PlayerSingleton._pRef.pTrans);
    }
}
