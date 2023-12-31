using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PickUpScript : MonoBehaviour
{
    public Transform holdPos;
     
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 5f; //how far the player can pickup the object from

    public TMP_Text descriptionText;

    private string textHolder;
    //References to what we are holding
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    private bool canDrop = true; //to prevent accidents
    private int LayerNumber; //layer index

   
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("Hold Layer");
        Debug.Log(LayerNumber.ToString());
    }
    void Update()
    {
        RaycastHit onvisual;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out onvisual, pickUpRange))
        {
            if (onvisual.transform.tag == "Ground" || onvisual.transform.tag == "Wall")
            {
                descriptionText.SetText("");
            }
            if (onvisual.transform.gameObject.GetComponent("ObjectDetails") != null)
            {
                textHolder = onvisual.transform.GetComponent<ObjectDetails>().description;
                descriptionText.SetText(textHolder);

            }
        }
        else
        {
            descriptionText.SetText("");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (heldObj == null)
            {
                //man i hate raycasts
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {

                    //make sure pickup tag is attached
                    if (hit.transform.gameObject.tag == "Throwable")
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                MoveObject(); //keep object position at holdPos
                if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
                {
                    StopClipping();
                    ThrowObject();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                Debug.Log("E pressed, heldObj null");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    Debug.Log(hit.transform.name);
                    if (onvisual.transform.gameObject.GetComponent("HandleScript") != null)
                    {
                        Debug.Log("Handle seen");
                        //Attempt to open door

                        onvisual.transform.gameObject.GetComponent<HandleScript>().OpenDoorAttempt();
                    }
                }
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            var children = transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in children)
            {
                child.gameObject.layer = LayerNumber;
            }
            
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), PlayerSingleton._pRef.pCollide, true);


        }
    }
    void DropObject()
    {
        //re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), PlayerSingleton._pRef.pCollide, false);
        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
    }
    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }

    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), PlayerSingleton._pRef.pCollide, false);
        heldObj.layer = 0;
        var children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            child.gameObject.layer = 0;
        }
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        if (heldObj.GetComponent("PlateScript") != null)
            heldObj.GetComponent<PlateScript>().PickUp();
        heldObj = null;
    }
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the cliprange
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }
}
