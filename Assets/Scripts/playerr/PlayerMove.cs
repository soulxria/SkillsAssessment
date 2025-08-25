using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerMove : MonoBehaviour
{
    private CharacterController  playerController;
    public TextMeshProUGUI objText;
    public TextMeshProUGUI nameText;
    public Transform spawnPoint;



    public float movementSpeed = 5f, jumpForce = 10f, gravityVal = -30f;
    private float verticalVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        Transform spawnPoint = this.gameObject.transform;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (objText.gameObject.activeSelf == true)
            {
                objText.gameObject.SetActive(false);
            }
            else
            {
                objText.gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (nameText.gameObject.activeSelf == true)
            {
                nameText.gameObject.SetActive(false);
            }
            else
            {
                nameText.gameObject.SetActive(true);
            }
        }
    }

    
 
}
