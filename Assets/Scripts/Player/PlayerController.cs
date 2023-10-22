using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;


    private void Start()
    {
        //player rigidbody reference from singleton. freezes rotation for less jank.
        PlayerSingleton._pRef.pRB.freezeRotation = true;

    }

    private void Update()
    {
       PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        PlayerSingleton._pRef.pRB.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force);
    }

    private void SpeedLimit()
    {
        Vector3 currentVel = new Vector3(PlayerSingleton._pRef.pRB.velocity.x, 0f, PlayerSingleton._pRef.pRB.velocity.y);
        if (currentVel.magnitude > moveSpeed)
        {
            Vector3 loweredVel = currentVel.normalized * moveSpeed;
            PlayerSingleton._pRef.pRB.velocity = new Vector3(loweredVel.x, 0, loweredVel.z);
        }
    }
}
