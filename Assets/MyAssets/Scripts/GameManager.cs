using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    //build player functionality in first person, ideally wow movement and camera controls.
    //build button to swap between overhead setup mode and third person battle mode, which also ques the round to start with enemy spawning etc. 
    //build a button which swaps you to a differant platform for offense, and a button over there to xfer you back and to transfer your main character over
    //build UI in general, make it look good or barebones
    //build ally class(inherit from building)
    //give enemies attacks*
    //give spells on 1234
    //building placement functionality and button ui
    //make an offense map*
    //make a way to transition between setup and battle mode
    //setup for selecting spell deck in the build mode and displaying them on UI in battle mode
    //models and animations
    //possibly make way to give men orders
    //you have to decide wether you want sick items and artifacts bases from adventuring or to build up your economy and infrastructure by defending your base better/investing in base/interest on rescources.
    //when offense starts the square you are on determines the dungeon you do, which becomes the new offense map until the round finishes. 


    public bool timer = true;
    private Vector3 spawnPoint = new Vector3(10f, 2.4f, 10f);
    public GameObject enemy;
    public GameObject building;
    public GameObject mainCamera;
    private float mapZoomInput;
    private float mouseXInput;
    private float mouseYInput;
    private int cameraZoomSpeed = 5000;
    private int cameraPanSpeed = 250;
    private bool cameraOffsetSet = false;
    void Start()
    {
        GameObject buildingCreated = PrefabUtility.InstantiatePrefab(building) as GameObject;
        buildingCreated.transform.Translate(new Vector3(15, 2, -18)); 
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 2.4f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    }
    void Update()
    {
        RegisterCameraMovement();
    }
    void RegisterCameraMovement()
    {
        mapZoomInput = Input.GetAxis("Mouse ScrollWheel");
        if (15 <= mainCamera.transform.position.y && mainCamera.transform.position.y <= 47)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraZoomSpeed * mapZoomInput, Space.World);
        }
        else if(15 > mainCamera.transform.position.y && mapZoomInput < 0)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraZoomSpeed * mapZoomInput, Space.World);
        }
        else if (mainCamera.transform.position.y > 47 && mapZoomInput > 0)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraZoomSpeed * mapZoomInput, Space.World);
        }
        if (Input.GetMouseButton(1))
        {
            mouseXInput = Input.GetAxis("Mouse X");
            mouseYInput = Input.GetAxis("Mouse Y");
            if (mouseXInput > 0 && mainCamera.transform.position.x > -20)
            {
                mainCamera.transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraPanSpeed, 0f, 0f);
            }
            if (mouseXInput < 0 && mainCamera.transform.position.x < 20)
            {
                mainCamera.transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraPanSpeed, 0f, 0f);
            }
            if (mouseYInput > 0 && mainCamera.transform.position.z > -45)
            {
                mainCamera.transform.position += new Vector3(0f, 0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraPanSpeed);
            }
            if (mouseYInput < 0 && mainCamera.transform.position.z < -5)
            {
                mainCamera.transform.position += new Vector3(0f, 0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraPanSpeed);
            }
        }
    }
}
