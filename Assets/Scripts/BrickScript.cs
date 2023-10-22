using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickScript : MonoBehaviour
{

    float damage = 0;

    public Mesh firstDamage;
    public Mesh secondDamage;
    public float timer;

    float remainingtimer;


    private void Start()
    {
        remainingtimer = 0.0f;
    }

    private void Update()
    {
        if (remainingtimer > 0.0f)
            remainingtimer -= Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Throwable")
        {
            if (remainingtimer <= 0.0f)
            {
                damage++;
                Debug.Log("Damage =" + damage);
                //Tell voice about it here

                //Put audio here or smth idk

                if (damage == 1)                   
                    GetComponent<MeshFilter>().mesh = firstDamage;
                if (damage == 2)
                    GetComponent<MeshFilter>().mesh = secondDamage;
                if (damage == 3)
                {
                    GameObject.Find("EyeManager").GetComponent<EyeManagerScript>().BrickBroken();
                    Destroy(this.gameObject);
                }


                remainingtimer = timer;
            }
        }
    }
}
