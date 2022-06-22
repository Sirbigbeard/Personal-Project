using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //build button to swap character between each map
    //build ally class(inherit from building)
    //give enemies attacks
    //give spells on 1234
    //building placement functionality
    //spell choosing button which brings up spells, either click to replace ones in currently used or drag
    //building placement functionality and button ui
    //setup for selecting spell deck in the build mode and displaying them on UI in battle mode
    //models and animations
    //possibly make way to give men orders
    //you have to decide wether you want sick items and artifacts bases from adventuring or to build up your economy and infrastructure by defending your base better/investing in base/interest on rescources.
    //when offense starts the square you are on determines the dungeon you do, which becomes the new offense map until the round finishes. 
    //have a max number of buildings, which can be increased
    //make ZoomIn function place camera rotation and position correctly based upon player direction, and zooming out places player rotation at the angle based upon the direction set based upon the current rotation of the player

    public bool roundBegun = false;
    private bool defenseMap = true;
    public GameObject player;
    public GameObject enemy;
    public GameObject building;
    public GameObject mainCamera;
    public GameObject offenseMapButtonObject;
    public GameObject defenseMapButtonObject;
    public GameObject beginRoundButtonObject;
    private Button offenseMapButton;
    private Button defenseMapButton;
    private Button beginRoundButton;
    private float mapZoomInput;
    private float mouseXInput;
    private float mouseYInput;
    private int cameraZoomSpeed = 5000;
    private int cameraPanSpeed = 250;
    private int cameraPanLowerBound = -45;
    private int cameraPanUpperBound = -5;
    private int cameraPanLeftBound = -20;
    private int cameraPanRightBound = 20;
    private int roundDuration = 1500;
    private Vector3 offenseCameraPosition = new Vector3(500f, 47f, -23.3f);
    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    private Vector3 defenseCameraPosition = new Vector3(0f, 47f, -23.3f);
    private Vector3 spawnPoint = new Vector3(10f, 3f, 10f);
    private Vector3 cameraOffset = new Vector3(0, 7, -10);
    public Vector3 cameraDistance;
    void Start()
    {
        offenseMapButton = offenseMapButtonObject.GetComponent<Button>();
        defenseMapButton = defenseMapButtonObject.GetComponent<Button>();
        beginRoundButton = beginRoundButtonObject.GetComponent<Button>();
        offenseMapButton.onClick.AddListener(SetOffenseMap);
        defenseMapButton.onClick.AddListener(SetDefenseMap);
        beginRoundButton.onClick.AddListener(BeginRound);

        GameObject buildingCreated = PrefabUtility.InstantiatePrefab(building) as GameObject;
        buildingCreated.transform.Translate(new Vector3(15, 2, -18)); 
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 3f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 3f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 3f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 3f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
        spawnPoint = new Vector3(Random.Range(-30, 30), 3f, Random.Range(-30, 30));
        Instantiate(enemy, spawnPoint, enemy.transform.rotation);
    }
    void Update()
    {
        if (!roundBegun)
        {
            RegisterCameraMovementOverhead();
        }
        if (roundBegun)
        {
            RegisterCameraMovementInRound();
        }
    }
    void RegisterCameraMovementOverhead()
    {
        mapZoomInput = Input.GetAxis("Mouse ScrollWheel");
        if (15 <= mainCamera.transform.position.y && mainCamera.transform.position.y <= 47)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraZoomSpeed * mapZoomInput, Space.World);
        }
        else if (15 > mainCamera.transform.position.y && mapZoomInput < 0)
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
            if (mouseXInput > 0 && mainCamera.transform.position.x > cameraPanLeftBound)
            {
                mainCamera.transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraPanSpeed, 0f, 0f);
            }
            if (mouseXInput < 0 && mainCamera.transform.position.x < cameraPanRightBound)
            {
                mainCamera.transform.position += new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraPanSpeed, 0f, 0f);
            }
            if (mouseYInput > 0 && mainCamera.transform.position.z > cameraPanLowerBound)
            {
                mainCamera.transform.position += new Vector3(0f, 0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraPanSpeed);
            }
            if (mouseYInput < 0 && mainCamera.transform.position.z < cameraPanUpperBound)
            {
                mainCamera.transform.position += new Vector3(0f, 0f, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraPanSpeed);
            }
        }
        if (Input.GetKeyDown("space"))
        {
            mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, player.transform.position.z - 20);
        }
        if (defenseMap)
        {
            defenseCameraPosition = mainCamera.transform.position;
        }
        else
        {
            offenseCameraPosition = mainCamera.transform.position;
        }
    }
    void RegisterCameraMovementInRound()
    {
        if (Input.GetMouseButton(1) && !Input.GetKey("tab"))
        {
            mouseXInput = Input.GetAxis("Mouse X");
            mouseYInput = Input.GetAxis("Mouse Y");
            if (mouseXInput != 0)
            {
                player.transform.Rotate(Vector3.up, mouseXInput * Time.deltaTime * 1000);
            }
        }
        if (Input.GetKeyDown("tab"))
        {
            cameraPosition = mainCamera.transform.position;
            cameraRotation = mainCamera.transform.rotation;
            mainCamera.transform.position = defenseCameraPosition;
            mainCamera.transform.rotation = Quaternion.Euler(75, 0, 0);
        }
        if (Input.GetKeyUp("tab"))
        {
            mainCamera.transform.position = cameraPosition;
            mainCamera.transform.rotation = cameraRotation;
        }
        if (Input.GetKey("tab"))
        {
            RegisterCameraMovementOverhead();
        }
    }
    void SetOffenseMap()
    {
        offenseMapButton.gameObject.SetActive(false);
        defenseMapButton.gameObject.SetActive(true);
        cameraPanLeftBound += 500;
        cameraPanRightBound += 500;
        mainCamera.transform.position = offenseCameraPosition;
        defenseMap = false;
    }
    void SetDefenseMap()
    {
        offenseMapButton.gameObject.SetActive(true);
        defenseMapButton.gameObject.SetActive(false);
        cameraPanLeftBound -= 500;
        cameraPanRightBound -= 500;
        mainCamera.transform.position = defenseCameraPosition;
        defenseMap = true;
    }
    void BeginRound()
    {
        roundBegun = true;
        offenseMapButton.gameObject.SetActive(false);
        defenseMapButton.gameObject.SetActive(false);
        beginRoundButton.gameObject.SetActive(false);
        mainCamera.transform.parent = player.transform;
        ZoomIn();
        StartCoroutine(RoundTimer());
    }
    void ZoomIn()
    {
        mainCamera.transform.position = player.transform.position;//new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z) + cameraOffset;
        mainCamera.transform.rotation = Quaternion.Euler(25, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
        while(Vector3.Distance(mainCamera.transform.position, player.transform.position) < 12)
        {
            mainCamera.transform.Translate(-Vector3.forward);
        }
        mainCamera.transform.position += new Vector3(0, 1, 0);
    }
    IEnumerator RoundTimer()
    {
        yield return new WaitForSeconds(roundDuration);
        EndRound();
    }
    void EndRound()
    {
        roundBegun = false;
        offenseMapButton.gameObject.SetActive(true);
        beginRoundButton.gameObject.SetActive(true);
        mainCamera.transform.parent = null;
        mainCamera.transform.rotation = Quaternion.Euler(75, 0, 0);
        mainCamera.transform.position = defenseCameraPosition;
    }
    
}
