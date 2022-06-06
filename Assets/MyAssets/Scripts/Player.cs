using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    public GameObject playerModel;
    private int direction;


    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RegisterMovement();
    }
    //registers wasd and moves character correspondingly
    private void RegisterMovement()
    {
        playerRb.velocity = new Vector3(0, 0, 0);
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        SetDirection();
    }
    //Faces the player model towards the moving direction and sets the direction variable to the corresponding number
    private void SetDirection()
    {
        if (verticalInput > 0 && horizontalInput == 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = 1;
        }
        if (verticalInput > 0 && horizontalInput > 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, 45, 0);
            direction = 2;
        }
        if (verticalInput == 0 && horizontalInput > 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, 90, 0);
            direction = 3;
        }
        if (verticalInput < 0 && horizontalInput > 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, 135, 0);
            direction = 4;
        }
        if (verticalInput < 0 && horizontalInput == 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, 180, 0);
            direction = 5;
        }
        if (verticalInput < 0 && horizontalInput < 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, -135, 0);
            direction = 6;
        }
        if (verticalInput == 0 && horizontalInput < 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, -90, 0);
            direction = 7;
        }
        if (verticalInput > 0 && horizontalInput < 0)
        {
            playerModel.transform.rotation = Quaternion.Euler(0, -45, 0);
            direction = 8;
        }
    }
}
