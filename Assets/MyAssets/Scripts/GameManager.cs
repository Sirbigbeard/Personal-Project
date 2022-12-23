using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //draw mana cost on icons
    //make rest of icons
    //add an xp ui for player that pops up opposite side as the incomingdamage
    //make health bars work by concatinating string +/- "_" in for loop with damage
    //test ally xp/level ups, make aspects of the game object that become active to signify leveling up for allies and/or player (for player maybe just go from tan color to blood red.
    //use the physics engine for all movement, fuck it. then you can have knockbacks and stuff, you could even incorporate gravity, things could slide when frozen by ice skeet, etc
    //variable name brush ups
    //comment every variable with what it does and under what
    //TUTORIAL: add tutorial that shows off all systems (maybe)
    //TOOLTIPS: use code in ui block to on mouseover display tooltips above spells, gear, enemy names maybe, tooltip for build
    //create powerpoint or something to show off code, show class trees etc, really demonstrate that I did things smaht (Building RemoveTarget is good.)
    //death screen (when base dies not player, when player dies put screen to overhead view and respawn player at the end of the round.
    //change the way the player spawns in to not be janky

    // make defend key for ally that makes their move target the base until
    //fix follow
    //fix upside down localized ui
    //0: try to fuck around with blender basic modeling and animation
    //taunt spell that works like follow for enemys
    //at start, randomize 3 locations on different walls at least 40ish units apart that can be for boss spawning, so that you can setup extra strong defenses around those points.
    //make a building that does aoe damage by cycling through all targets on the list and doing damage to each of them. 
    //reduce a defensive stat during the attack window of attack duration
    //5: SPELLS: 16 total skills at least, 3 spell ranks maybe +25% effectiveness per, icewave fully freezes motion/rotation on uprank, cleave spell that deals half damage to all but the closest target 
    //spell ideas: Vengeance: rank1: charge for 3 seconds, then attack, dealing bonus damage equal to the damage taken, rank2: 50% damage reduction for dur, rank3: damage immunity for dur.
    //add enemy aggro system where top source of damage is swapped to if its in targetlist?
    //make blacksmith button that can make gear for you for $$ or can get gear adventuring
    //first few rounds are pretty easy with the inital gold you get, but if you choose to adventure your early buildings take significant damage which takes gold to repair. 
    //figure out what other stat systems I want to have in place, armor, attributes, etc.
    //choose class at start, diff stats, special buildings/recruits, abilities, gear
    //Design offense map/maps (im thinking large labyrith of smallish rooms, when you enter one you cannot enter another new one till next round, when you start round if you are in hitbox of an uncleared room you fight it.
    //NOT offense, adventuring. when you are adventuring you have to just trust in your men to hold, you will take more damage to your defenses, but you can find dank skeet. 
    //maybe give option to watch the defense first
    //you have to decide wether you want sick items and artifacts bases from adventuring or to build up your economy and infrastructure by defending your base better/investing in base/interest on rescources.
    //when offense starts the square you are on determines the dungeon you do, which becomes the new offense map until the round finishes. (teleports you and allies there) 
    //something to try: if running a method in a grandparent class of a child, you call the method, and it is overriden in the parent, does the method run the grandparent or parent version
    //how i could have done buildposition better: made an array 126 large for each variable, with the correct variable in the correct location, then just have each button have the same script and an int variable which just calls buildposition passing its corresponding int. 


    public bool currentBuildingRangeFinder = false;
    public bool roundBegun = false;
    private bool defenseMap = true;
    private bool spellBookOpen = false;
    private bool buildingListOpen = false;
    private bool recruitmentOpen = false;
    public bool constructing = false;
    public bool recruiting = false;
    public GameObject healthAndDamageCanvas;
    public GameObject currentHealthAndDamageCanvas;
    public GameObject currentBuilding;
    public GameObject castle;
    public GameObject player;
    public GameObject mainCamera;
    public Camera creationCamera;
    public GameObject enemy;
    public GameObject footman;
    public GameObject archer;
    public GameObject hut;
    public GameObject crenelations;
    public GameObject watchtower;
    public GameObject offenseMapButtonObject;
    public GameObject defenseMapButtonObject;
    public GameObject beginRoundButtonObject;
    public GameObject spellBookButtonObject;
    public GameObject buildingListButtonObject;
    public GameObject fireBallButtonObject;
    public GameObject slamButtonObject;
    public GameObject summonImpButtonObject;
    public GameObject bulwarkButtonObject;
    public GameObject blinkButtonObject;
    public GameObject iceWaveButtonObject;
    public GameObject hutButtonObject;
    public GameObject crenelationsButtonObject;
    public GameObject watchtowerButtonObject;
    public GameObject recruitListButtonObject;
    public GameObject archerButtonObject;
    public GameObject footmanButtonObject;
    private Button offenseMapButton;
    private Button defenseMapButton;
    private Button beginRoundButton;
    private Button spellBookButton;
    private Button buildingListButton;
    private Button hutButton;
    private Button crenelationsButton;
    private Button watchtowerButton;
    private Button recruitListButton;
    private Button archerButton;
    private Button footmanButton;
    public TextMeshProUGUI goldDisplay;
    public TextMeshProUGUI roundDisplay;
    private float mapZoomInput;
    private float mouseXInput;
    private float mouseYInput;
    public int maxActiveSpells = 1;
    private int cameraZoomSpeed = 5000;
    private int cameraPanSpeed = 250;
    private int cameraPanLowerBound = -45;
    private int cameraPanUpperBound = -5;
    private int cameraPanLeftBound = -20;
    private int cameraPanRightBound = 20;
    private int spellXLocation;
    private int spellYLocation;
    private int laneBalance1 = 0;
    private int laneBalance2 = 0;
    private int laneBalance3 = 0;
    private int currentRound = 1;
    public int gold;
    public int currentBuildingCost;
    private Vector3 offenseCameraPosition = new Vector3(500f, 47f, -14f);
    private Vector3 defenseCameraPosition = new Vector3(0f, 47f, -14f);
    private Vector3 offensePlayerPosition = new Vector3(500f, 3.54f, 0f);
    private Vector3 defensePlayerPosition;
    private Vector3 cameraPosition;
    private Vector3 cameraOffset = new Vector3(0, 7, -10);
    public Vector3 cameraDistance;
    private Vector3 lane1Position;
    private Vector3 lane2Position;
    private Vector3 lane3Position;
    private Vector3 enemyOffset = new Vector3(0, 4, 0);
    private Quaternion cameraRotation;
    private Quaternion lane1Rotation;
    private Quaternion lane2Rotation;
    private Quaternion lane3Rotation;
    public List<GameObject> gatheredSpells;
    public List<GameObject> activeSpells;
    public List<GameObject> buildingsAvailable;
    public List<GameObject> troopsAvailable;
    public Player playerScript;
    public Building currentBuildingScript;
    public HealthAndDamageCanvas healthAndDamageCanvasScript;
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        offenseMapButton = offenseMapButtonObject.GetComponent<Button>();
        defenseMapButton = defenseMapButtonObject.GetComponent<Button>();
        beginRoundButton = beginRoundButtonObject.GetComponent<Button>();
        spellBookButton = spellBookButtonObject.GetComponent<Button>();
        buildingListButton = buildingListButtonObject.GetComponent<Button>();
        recruitListButton = recruitListButtonObject.GetComponent<Button>();
        hutButton = hutButtonObject.GetComponent<Button>();
        crenelationsButton = crenelationsButtonObject.GetComponent<Button>();
        watchtowerButton = watchtowerButtonObject.GetComponent<Button>();
        footmanButton = footmanButtonObject.GetComponent<Button>();
        archerButton = archerButtonObject.GetComponent<Button>();
        offenseMapButton.onClick.AddListener(SetOffenseMap);
        defenseMapButton.onClick.AddListener(SetDefenseMap);
        beginRoundButton.onClick.AddListener(BeginRound);
        spellBookButton.onClick.AddListener(ToggleSpellBook);
        recruitListButton.onClick.AddListener(ToggleRecruitment);
        hutButton.onClick.AddListener(delegate { Build(hut, 1.0f, true, 15, new Vector3(0, 2.5f, 0)); });
        crenelationsButton.onClick.AddListener(delegate { Build(crenelations, 0f, false, 5, new Vector3(0, 6, 0)); });
        footmanButton.onClick.AddListener(delegate { Recruit(footman, false, 5, new Vector3(0, 4, 0)); });
        archerButton.onClick.AddListener(delegate { Recruit(archer, false, 5, new Vector3(0, 4, 0)); });
        buildingListButton.onClick.AddListener(ToggleBuildingList);
        gatheredSpells = new List<GameObject>();
        activeSpells = new List<GameObject>();
        troopsAvailable = new List<GameObject>();
        buildingsAvailable = new List<GameObject>();
        troopsAvailable.Add(footmanButtonObject);
        troopsAvailable.Add(archerButtonObject);
        buildingsAvailable.Add(hutButtonObject);
        buildingsAvailable.Add(crenelationsButtonObject);
        buildingsAvailable.Add(watchtowerButtonObject);
        spellBookButtonObject.SetActive(false);
        ResetSpellLocation();
        creationCamera.enabled = false;
        gold = 100;
        goldDisplay.text = "Gold: " + gold;
    }
    void Update()
    {
        //Game-State
        if (!roundBegun)
        {
            RegisterCameraMovementOverhead();
            if (gatheredSpells.Count != 0 && !spellBookButtonObject.activeSelf)
            {
                spellBookButtonObject.SetActive(true);
            }
            if (Input.GetKeyDown("escape"))
            {
                if (spellBookOpen)
                {
                    ToggleSpellBook();
                }
                if (buildingListOpen)
                {
                    ToggleBuildingList();
                }
                if (recruitmentOpen)
                {
                    ToggleRecruitment();
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
            if (Input.GetKeyDown("h"))
            {
                EndRound();
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
        if (buildingListOpen)
        {
            ToggleBuildingList();
        }
        if (recruitmentOpen)
        {
            ToggleRecruitment();
        }
        roundBegun = true;
        offenseMapButtonObject.SetActive(false);
        defenseMapButtonObject.SetActive(false);
        beginRoundButtonObject.SetActive(false);
        spellBookButtonObject.SetActive(false);
        buildingListButtonObject.SetActive(false);
        recruitListButtonObject.SetActive(false);
        mainCamera.transform.parent = player.transform;
        ZoomIn();
        activeSpells.ShuffleList();
        playerScript.RoundBegin();
        SpawnRoundWave();
    }

    void EndRound()
    {
        roundBegun = false;
        offenseMapButtonObject.SetActive(true);
        beginRoundButtonObject.SetActive(true);
        buildingListButtonObject.SetActive(true);
        recruitListButtonObject.SetActive(true);
        mainCamera.transform.parent = null;
        mainCamera.transform.rotation = Quaternion.Euler(75, 0, 0);
        mainCamera.transform.position = defenseCameraPosition;
        playerScript.RoundEnd();
    }
    //Spell and Building UI
    void ToggleSpellBook()
    {
        if (recruitmentOpen)
        {
            ToggleRecruitment();
        }
        if (buildingListOpen)
        {
            ToggleBuildingList();
        }
        if (!spellBookOpen)
        {
            spellBookOpen = true;
            foreach (GameObject spell in gatheredSpells)
            {
                ListSpells(spell);
            }
            ResetSpellLocation();
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
    void ToggleBuildingList()
    {
        if (recruitmentOpen)
        {
            ToggleRecruitment();
        }
        if (spellBookOpen)
        {
            ToggleSpellBook();
        }
        if (!buildingListOpen)
        {
            buildingListOpen = true;
            foreach (GameObject building in buildingsAvailable)
            {
                ListSpells(building);
            }
            ResetSpellLocation();
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
    void ToggleRecruitment()
    {
        if (buildingListOpen)
        {
            ToggleBuildingList();
        }
        if (spellBookOpen)
        {
            ToggleSpellBook();
        }
        if (!recruitmentOpen)
        {
            recruitmentOpen = true;
            if (troopsAvailable.Count != 0)
            {
                foreach (GameObject recruit in troopsAvailable)
                {
                    ListSpells(recruit);
                }
                ResetSpellLocation();
            } 
        }
        else
        {
            recruitmentOpen = false;
            if (troopsAvailable.Count != 0)
            {
                foreach (GameObject recruit in troopsAvailable)
                {
                    recruit.SetActive(false);
                }
            }
        }
    }
    void ListSpells(GameObject spell)
    {
        if (!spell.gameObject.activeSelf)
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
                spellYLocation -= 60;
            }
        }
    }
    //Building Creation Methods
    void Build(GameObject building, float height, bool rangeFinder, int cost, Vector3 offset)
    {
        if(gold >= cost)
        {
            if (currentBuilding != null)
            {
                Destroy(currentBuilding);
            }
            if (currentHealthAndDamageCanvas != null)
            {
                Destroy(currentHealthAndDamageCanvas);
            }
            constructing = true;
            recruiting = false;
            creationCamera.enabled = true;
            currentBuilding = Instantiate(building, new Vector3(0f, height, 447.0f), building.transform.rotation);
            currentBuildingRangeFinder = rangeFinder;
            currentBuildingCost = cost;
            GeneralizedSpawn(offset);
        }
        else
        {
            Debug.Log("You too poor noob");
        }
    }
    void Recruit(GameObject recruit, bool rangeFinder, int cost, Vector3 offset)
    {
        if (gold >= cost)
        {
            if (currentBuilding != null)
            {
                Destroy(currentBuilding);
            }
            if (currentHealthAndDamageCanvas != null)
            {
                Destroy(currentHealthAndDamageCanvas);
            }
            constructing = true;
            recruiting = true;
            creationCamera.enabled = true;
            currentBuilding = Instantiate(recruit, new Vector3(0f, recruit.transform.position.y, 447.0f), recruit.transform.rotation);
            currentBuildingRangeFinder = rangeFinder;
            currentBuildingCost = cost;
            GeneralizedSpawn(offset);
        }
        else
        {
            Debug.Log("You too poor noob");
        }
    }
    void SpawnEnemy(GameObject enemy, Vector3 offset)
    {
        int coinFlip = Random.Range(1, 5);
        float xPos;
        float zPos;
        Quaternion rotation;
        if (coinFlip == 1)
        {
            zPos = -63.5f;
            xPos = Random.Range(-90.5f, 90.5f);
            rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (coinFlip == 2)
        {
            zPos = 47.75f;
            xPos = Random.Range(-90.5f, 90.5f);
            rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (coinFlip == 3)
        {
            xPos = -90.5f;
            zPos = Random.Range(-63.5f, 47.75f);
            rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            xPos = 90.5f;
            zPos = Random.Range(-63.5f, 47.75f);
            rotation = Quaternion.Euler(0, 270, 0);
        }
        currentBuilding = Instantiate(enemy, new Vector3(xPos, enemy.transform.position.y, zPos), rotation);
        GeneralizedSpawn(offset);
    }
    void SpawnEnemyLane(GameObject enemy, Vector3 offset)
    {
        if(Mathf.Abs(laneBalance1 - laneBalance2) > 2)
        {
            if (laneBalance1 < laneBalance2)
            {
                currentBuilding = Instantiate(enemy, lane1Position, lane1Rotation);
                GeneralizedSpawn(offset);
            }
            else
            {
                currentBuilding = Instantiate(enemy, lane1Position, lane1Rotation);
                GeneralizedSpawn(offset);
            }
        }
        else if (Mathf.Abs(laneBalance1 - laneBalance3) > 2)
        {
            if (laneBalance1 < laneBalance2)
            {
                currentBuilding = Instantiate(enemy, lane1Position, lane1Rotation);
                GeneralizedSpawn(offset);
            }
            else
            {
                currentBuilding = Instantiate(enemy, lane3Position, lane3Rotation);
                GeneralizedSpawn(offset);
            }
        }
        else if (Mathf.Abs(laneBalance2 - laneBalance3) > 2)
        {
            if (laneBalance2 < laneBalance3)
            {
                currentBuilding = Instantiate(enemy, lane2Position, lane2Rotation);
                GeneralizedSpawn(offset);
            }
            else
            {
                currentBuilding = Instantiate(enemy, lane3Position, lane3Rotation);
                GeneralizedSpawn(offset);
            }
        }
    }
    private void SpawnRoundWave()
    {
        if(currentRound == 1)
        {
            SpawnEnemy(enemy, enemyOffset);
            roundDisplay.text = "Round 1";
            StartCoroutine(RoundTextReset());
        }
        if (currentRound == 2)
        {
            roundDisplay.text = "Round 2";
        }
        if (currentRound == 3)
        {
            roundDisplay.text = "Round 3";
        }
        currentRound++;
    }
    private IEnumerator RoundTextReset()
    {
        yield return new WaitForSeconds(3);
        roundDisplay.text = "";
    }
    //Misc Methods
    void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void GeneralizedSpawn(Vector3 offset)
    {
        currentHealthAndDamageCanvas = Instantiate(healthAndDamageCanvas, new Vector3(healthAndDamageCanvas.transform.position.x, healthAndDamageCanvas.transform.position.y, healthAndDamageCanvas.transform.position.z), Quaternion.identity);
        healthAndDamageCanvasScript = currentHealthAndDamageCanvas.GetComponent<HealthAndDamageCanvas>();
        healthAndDamageCanvasScript.host = currentBuilding;
        healthAndDamageCanvasScript.offset = offset;
        currentBuildingScript = currentBuilding.GetScript() as Building;
        currentBuildingScript.healthAndDamageCanvas = currentHealthAndDamageCanvas;
        currentBuildingScript.healthAndDamageCanvasScript = healthAndDamageCanvasScript;
        currentBuildingScript.castle = castle;
    }
    void ResetSpellLocation()
    {
        spellXLocation = -250;
        spellYLocation = 250;
    }
}
