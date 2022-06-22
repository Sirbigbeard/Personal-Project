using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    public GameObject GameManager;
    private GameManager gameManagerScript;
    public GameObject mainCamera;


    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameManagerScript = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (!Input.GetKey("tab"))
        {
            RegisterMovement();
        }
    }
    //registers wasd and moves character correspondingly
    private void RegisterMovement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (!gameManagerScript.roundBegun)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed, Space.World);
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed, Space.World);
            SetDirection();
        }
        if(gameManagerScript.roundBegun)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
        //playerRb.velocity = new Vector3(0, 0, 0);
    }
    //Faces the player model towards the moving direction and sets the direction variable to the corresponding number
    private void SetDirection()
    {
        if (verticalInput > 0 && horizontalInput == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (verticalInput > 0 && horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        if (verticalInput == 0 && horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (verticalInput < 0 && horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (verticalInput < 0 && horizontalInput == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (verticalInput < 0 && horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -135, 0);
        }
        if (verticalInput == 0 && horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (verticalInput > 0 && horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
}
