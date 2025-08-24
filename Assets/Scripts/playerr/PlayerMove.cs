using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController  playerController;

    public float movementSpeed = 5f, jumpForce = 10f, gravityVal = -30f;
    private float verticalVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * movementSpeed * Time.deltaTime;
        playerController.Move(move);

        verticalVelocity = verticalVelocity + gravityVal * Time.deltaTime;
        playerController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }

    // Update is called once per frame
    public void Jump() 
    {
        if (playerController.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
 
}
