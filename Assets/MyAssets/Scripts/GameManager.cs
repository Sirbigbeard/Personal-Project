using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //finish floor buttons
    //change player movement to force rather than transform.translate to prevent moving through barriers, try to keep the movement crispy
    //make health and mana bars for player.
    //create currency with which to buy buildings/gear
    //give allies/enemies attacks

    //replace all references to game manager within prefabs to gameManager = GameObject.Find("GameManager"); as currently they lose reference when instantiated.
    //models and animations
    //UI/overlay look good
    //pause functionality
    //gamedesign of the abilities etc, expand upon all the systems in place.
    //have a forward area with smaller areas that allies can be placed upon, or upon buildings if they have capacity. 
    //comment every line of code 
    ///Design offense map/maps (im thinking large labyrith of smallish rooms, when you enter one you cannot enter another new one till next round, when you start round if you are in hitbox of an uncleared room you fight it.
    ///NOT offense, adventuring. when you are adventuring you have to just trust in your men to hold, you will take more damage to your defenses, but you can find dank skeet. 
    ///maybe give option to watch the defense first
    ///you have to decide wether you want sick items and artifacts bases from adventuring or to build up your economy and infrastructure by defending your base better/investing in base/interest on rescources.
    ///when offense starts the square you are on determines the dungeon you do, which becomes the new offense map until the round finishes. 
    //have a max number of buildings, which can be increased
    //To add spell ui images just perform a check for the first 4 spells listed in the round begin of game manager and display the corresponding image, then each time a spell is cast do a check with a FindImage()
    //method that takes in the name of the spell as a parameter and displays the corresponding image to the correct position on the UI

    public bool currentBuildingRangeFinder = false;
    public bool roundBegun = false;
    private bool defenseMap = true;
    private bool spellBookOpen = false;
    private bool buildingListOpen = false;
    private bool constructing = false;
    private GameObject currentBuilding;
    public GameObject player;
    public GameObject mainCamera;
    public Camera creationCamera;
    public GameObject enemy;
    public GameObject ally;
    public GameObject hut;
    public GameObject crenelations;
    public GameObject watchtower;
    public GameObject offenseMapButtonObject;
    public GameObject defenseMapButtonObject;
    public GameObject beginRoundButtonObject;
    public GameObject spellBookButtonObject;
    public GameObject fireBallButtonObject;
    public GameObject slamButtonObject;
    public GameObject summonImpButtonObject;
    public GameObject bulwarkButtonObject;
    public GameObject blinkButtonObject;
    public GameObject iceWaveButtonObject;
    public GameObject buildingListButtonObject;
    public GameObject hutButtonObject;
    public GameObject crenelationsButtonObject;
    public GameObject watchtowerButtonObject;
    public GameObject position1ButtonObject;
    public GameObject position2ButtonObject;
    private Button offenseMapButton;
    private Button defenseMapButton;
    private Button beginRoundButton;
    private Button spellBookButton;
    private Button buildingListButton;
    private Button hutButton;
    private Button crenelationsButton;
    private Button watchtowerButton;
    private Button position1Button;
    private Button position2Button;
    private float mapZoomInput;
    private float mouseXInput;
    private float mouseYInput;
    private int cameraZoomSpeed = 5000;
    private int cameraPanSpeed = 250;
    private int cameraPanLowerBound = -45;
    private int cameraPanUpperBound = -5;
    private int cameraPanLeftBound = -20;
    private int cameraPanRightBound = 20;
    private int spellXLocation = -250;
    private int spellYLocation = 200;
    private int spellUINumber = 0;
    private Vector3 offenseCameraPosition = new Vector3(500f, 47f, -23.3f);
    private Vector3 defenseCameraPosition = new Vector3(0f, 47f, -23.3f);
    private Vector3 offensePlayerPosition = new Vector3(500f, 3.54f, 0f);
    private Vector3 defensePlayerPosition;
    private Vector3 cameraPosition;
    private Vector3 cameraOffset = new Vector3(0, 7, -10);
    public Vector3 cameraDistance;
    private Quaternion cameraRotation;
    public List<GameObject> gatheredSpells;
    public List<GameObject> activeSpells;
    public List<GameObject> buildingsAvailable;
    public Player playerScript;
    public Building currentBuildingScript;
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        offenseMapButton = offenseMapButtonObject.GetComponent<Button>();
        defenseMapButton = defenseMapButtonObject.GetComponent<Button>();
        beginRoundButton = beginRoundButtonObject.GetComponent<Button>();
        spellBookButton = spellBookButtonObject.GetComponent<Button>();
        buildingListButton = buildingListButtonObject.GetComponent<Button>();
        hutButton = hutButtonObject.GetComponent<Button>();
        crenelationsButton = crenelationsButtonObject.GetComponent<Button>();
        watchtowerButton = watchtowerButtonObject.GetComponent<Button>();
        position1Button = position1ButtonObject.GetComponent<Button>();
        position2Button = position2ButtonObject.GetComponent<Button>();
        offenseMapButton.onClick.AddListener(SetOffenseMap);
        defenseMapButton.onClick.AddListener(SetDefenseMap);
        beginRoundButton.onClick.AddListener(BeginRound);
        spellBookButton.onClick.AddListener(ToggleSpellBook);
        hutButton.onClick.AddListener(BuildHut);
        crenelationsButton.onClick.AddListener(BuildCrenelations);
        buildingListButton.onClick.AddListener(ToggleBuildingList);
        position1Button.onClick.AddListener(BuildPosition1);
        position2Button.onClick.AddListener(BuildPosition2);
        gatheredSpells = new List<GameObject>();
        activeSpells = new List<GameObject>();
        buildingsAvailable = new List<GameObject>();
        buildingsAvailable.Add(hutButtonObject);
        buildingsAvailable.Add(crenelationsButtonObject);
        buildingsAvailable.Add(watchtowerButtonObject);
        spellBookButtonObject.SetActive(false);
        Instantiate(enemy, new Vector3(0, 3.6f, 15), hut.transform.rotation);
        Instantiate(enemy, new Vector3(-15, 3.6f, 15), hut.transform.rotation);
        creationCamera.enabled = false;
    }
    void Update()
    {
        //Game-State
        if (!roundBegun)
        {
            RegisterCameraMovementOverhead();
            if (gatheredSpells.Count != 0)
            {
                spellBookButtonObject.SetActive(true);
            }
            buildingListButtonObject.SetActive(true);
            if (Input.GetKeyDown("escape"))
            {
                if (spellBookOpen)
                {
                    ToggleSpellBook();
                    spellBookOpen = false;
                }
                if (buildingListOpen)
                {
                    ToggleBuildingList();
                    buildingListOpen = false;
                }
                if (constructing)
                {
                    Destroy(currentBuilding);
                    constructing = false;
                    creationCamera.enabled = false;
                }
            }
        }
        if (roundBegun)
        {
            RegisterCameraMovementInRound();
            if (Input.GetKeyDown("escape"))
            {
                Pause();
            }
        }
    }

    //Camera Movement Functionality
    void RegisterCameraMovementOverhead()
    {
        int maxCameraDistance = 47;
        int minCameraDistance = 15;
        mapZoomInput = Input.GetAxis("Mouse ScrollWheel");
        if (minCameraDistance <= mainCamera.transform.position.y && mainCamera.transform.position.y <= maxCameraDistance)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraZoomSpeed * mapZoomInput, Space.World);
        }
        else if (minCameraDistance > mainCamera.transform.position.y && mapZoomInput < 0)
        {
            mainCamera.transform.Translate(Vector3.down * Time.deltaTime * cameraZoomSpeed * mapZoomInput, Space.World);
        }
        else if (mainCamera.transform.position.y > maxCameraDistance && mapZoomInput > 0)
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
        int maxCameraDistance = 26;
        int minCameraDistance = 6;
        float zoomDistance = Vector3.Distance(player.transform.position, mainCamera.transform.position);
        mapZoomInput = Input.GetAxis("Mouse ScrollWheel");
        if (minCameraDistance <= zoomDistance && zoomDistance <= maxCameraDistance)
        {
            mainCamera.transform.Translate(Vector3.forward * Time.deltaTime * cameraZoomSpeed * mapZoomInput);
        }
        else if (minCameraDistance > zoomDistance && mapZoomInput < 0)
        {
            mainCamera.transform.Translate(Vector3.forward * Time.deltaTime * cameraZoomSpeed * mapZoomInput);
        }
        else if (zoomDistance > maxCameraDistance && mapZoomInput > 0)
        {
            mainCamera.transform.Translate(Vector3.forward * Time.deltaTime * cameraZoomSpeed * mapZoomInput);
        }
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
        offenseMapButtonObject.SetActive(false);
        defenseMapButtonObject.SetActive(true);
        cameraPanLeftBound += 500;
        cameraPanRightBound += 500;
        mainCamera.transform.position = offenseCameraPosition;
        defensePlayerPosition = player.transform.position;
        player.transform.position = offensePlayerPosition;
        defenseMap = false;
    }
    void SetDefenseMap()
    {
        offenseMapButtonObject.SetActive(true);
        defenseMapButtonObject.SetActive(false);
        cameraPanLeftBound -= 500;
        cameraPanRightBound -= 500;
        mainCamera.transform.position = defenseCameraPosition;
        offensePlayerPosition = player.transform.position;
        player.transform.position = defensePlayerPosition;
        defenseMap = true;
    }
    void ZoomIn()
    {
        mainCamera.transform.position = player.transform.position;
        mainCamera.transform.rotation = Quaternion.Euler(25, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
        while(Vector3.Distance(mainCamera.transform.position, player.transform.position) < 12)
        {
            mainCamera.transform.Translate(-Vector3.forward);
        }
        mainCamera.transform.position += new Vector3(0, 1, 0);
    }

    //Round Rotation Functionality
    void BeginRound()
    {
        if (spellBookOpen)
        {
            ToggleSpellBook();
        }
        roundBegun = true;
        offenseMapButtonObject.SetActive(false);
        defenseMapButtonObject.SetActive(false);
        beginRoundButtonObject.SetActive(false);
        spellBookButtonObject.SetActive(false);
        buildingListButtonObject.SetActive(false);
        mainCamera.transform.parent = player.transform;
        ZoomIn();
        ShuffleList(activeSpells);
        spellUINumber = 0;
        foreach(GameObject spell in activeSpells)
        {
            if (!playerScript.spellList.Contains(spell))
            {
                playerScript.spellList.Add(spell);
                Debug.Log(spell.name);
                if (spellUINumber == 0)
                {
                    playerScript.spell1Name.text = spell.name;
                }
                if (spellUINumber == 1)
                {
                    playerScript.spell2Name.text = spell.name;
                }
                if (spellUINumber == 2)
                {
                    playerScript.spell3Name.text = spell.name;
                }
                if (spellUINumber == 3)
                {
                    playerScript.spell4Name.text = spell.name;
                }
                spellUINumber++;
            }
        }
    }

    void EndRound()
    {
        roundBegun = false;
        offenseMapButtonObject.SetActive(true);
        beginRoundButtonObject.SetActive(true);
        mainCamera.transform.parent = null;
        mainCamera.transform.rotation = Quaternion.Euler(75, 0, 0);
        mainCamera.transform.position = defenseCameraPosition;
        if(gatheredSpells.Count != 0)
        {
            spellBookButtonObject.SetActive(true);
        }
    }


    //Spell and Building UI
    void ToggleSpellBook()
    {
        if (!buildingListOpen)
        {
            if (!spellBookOpen)
            {
                spellBookOpen = true;
                foreach (GameObject spell in gatheredSpells)
                {
                    ListSpells(spell);
                }
                spellXLocation = -250;
                spellYLocation = 200;
            }
            else
            {
                spellBookOpen = false;
                foreach (GameObject spell in gatheredSpells)
                {
                    spell.SetActive(false);
                }
            }
        }
    }
    void ToggleBuildingList()
    {
        if (!spellBookOpen)
        {
            if (!buildingListOpen)
            {
                buildingListOpen = true;
                foreach (GameObject building in buildingsAvailable)
                {
                    ListBuildings(building);
                }
                spellXLocation = -250;
                spellYLocation = 200;
                spellBookButtonObject.SetActive(false);
            }
            else
            {
                buildingListOpen = false;
                foreach (GameObject building in buildingsAvailable)
                {
                    building.SetActive(false);
                }
            }
        }
    }
    void ListSpells(GameObject spell)
    {
        if (spell.gameObject.activeSelf == false)
        {
            spell.SetActive(true);
            spell.GetComponent<RectTransform>().anchoredPosition = new Vector2(spellXLocation, spellYLocation);
            if (spellXLocation < 1)
            {
                spellXLocation += 250;
            }
            else
            {
                spellXLocation = -250;
                spellYLocation += 60;
            }
        }
    }
    void ListBuildings(GameObject building)
    {
        if (building.gameObject.activeSelf == false)
        {
            building.SetActive(true);
            building.GetComponent<RectTransform>().anchoredPosition = new Vector2(spellXLocation, spellYLocation);
            if (spellXLocation < 1)
            {
                spellXLocation += 250;
            }
            else
            {
                spellXLocation = -250;
                spellYLocation += 60;
            }
        }
    }

    //Build Position Methods
    //Make a dummy child at index 0 of any object that doesnt have a range finder, and objects that do need range finder as child index 0
    void BuildPosition1()
    {
        if (constructing)
        {
            currentBuilding.transform.position = new Vector3(5f, currentBuilding.transform.position.y, -5f);
            position1ButtonObject.SetActive(false);
            BuildPosition();
        }
    }
    void BuildPosition2()
    {
        if (constructing)
        {
            currentBuilding.transform.position = new Vector3(15f, currentBuilding.transform.position.y, -5f);
            position2ButtonObject.SetActive(false);
            BuildPosition();
        }
    }

    //Building Creation Methods
    void BuildHut()
    {
        if (currentBuilding != null)
        {
            Destroy(currentBuilding);
        }
        currentBuilding = Instantiate(hut, new Vector3(0f, 1.0f, 447.0f), hut.transform.rotation);
        currentBuildingRangeFinder = true;
        InitialBuild();
    }
    void BuildCrenelations()
    {
        if (currentBuilding != null)
        {
            Destroy(currentBuilding);
        }
        currentBuilding = Instantiate(crenelations, new Vector3(0f, 2.0f, 447.0f), crenelations.transform.rotation);
        currentBuildingRangeFinder = false;
        InitialBuild();
    }
    //Misc Methods
    void Pause()
    {
        Debug.Log("Game Paused");
    }
    void ShuffleList(List<GameObject> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    void InitialBuild()
    {
        currentBuildingScript = currentBuilding.GetComponent<Building>();
        constructing = true;
        creationCamera.enabled = true;
    }
    void BuildPosition()
    {
        if (currentBuildingRangeFinder)
        {
            currentBuildingScript.rangeFinder.GetComponent<MeshRenderer>().enabled = false;
        }
        creationCamera.enabled = false;
        constructing = false;
        currentBuilding = null;
    }
    
}
