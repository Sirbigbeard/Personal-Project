using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //comment what things do if unclear, or where things lead if unclear (or what script handles the other parts of something like building targeting being handled by range finder
    //figure out a way for the prospective people to test spell functions (maybe have a second option on start screen for testing mode, which brings up a similar scene but with character high level and with all spellbooks there
    //create powerpoint or something to show off code, show class trees etc, really demonstrate that I did things smaht (Building RemoveTarget is good. toggle spellbook good, Building Awake(), building relation to melle enemy/ally, move function placement, spikes other.yadayada, canvas spellButtons unity function event listeners) show where i would add animations into code if i had them. the only assets I imported were the ms paint spell drawings I did lol.

    //make a max number of recruits you can have that increases based on level
    //try to fix follow
    //variable name brush ups
    //TUTORIAL: add tutorial that shows off all systems
    //make save/load game function
    //add basic animations
    //make healthbar a red block that shrinks and widens its x scale based upon health percent. (in healthanddamagecanvas gain/lose health)
    //make weapons which modify attack speed and damage.
    //change colors of health bars dependign on type
    // make defend key for ally that makes their move target the base until

    //0: try to fuck around with blender basic modeling and animation
    //taunt spell that works like follow for enemys
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
    //maybe give option to a the defense first
    //you have to decide wether you want sick items and artifacts bases from adventuring or to build up your economy and infrastructure by defending your base better/investing in base/interest on rescources.
    //when offense starts the square you are on determines the dungeon you do, which becomes the new offense map until the round finishes. (teleports you and allies there) 
    //if a child calls a method only defined by parent/grandparent, and parent overrides it, does parent or gp method run?
    //how i could have done buildposition better: made an array 126 large for each variable, with the correct variable in the correct location, then just have each button have the same script and an int variable which just calls buildposition passing its corresponding int. 
    //I did not use extensions as much as i could have, the problem being I only found out they exist while doing this project. I did not use interfaces at all because while they would have been useful for DamageableObject, using a parent class works almost as well, and I didn't know about them until after the fact, so I didn't want to redo the whole thing just to have interfaces in my code.
    //instead of spellBookButton i should have just made gameManager load up string variables into activeSpells based on name given by button press.
    //give all spells scripts that have all their relevant info such as cost, then use an extension getSpell() to set currentSpell variable, then pull info from currentSpell to cast.

    public bool currentBuildingRangeFinder = false;
    public bool roundBegun = false;
    private bool defenseMap = true;
    private bool spellBookOpen = false;
    private bool buildingListOpen = false;
    private bool recruitmentOpen = false;
    public bool constructing = false;
    public bool recruiting = false;
    private bool playerDeath = false;
    public GameObject currentBuilding;
    public GameObject castle;
    public GameObject player;
    public GameObject mainCamera;
    public Camera creationCamera;
    public GameObject enemy;
    public GameObject grunt;
    public GameObject javleneer;
    public GameObject chieftan;
    public GameObject footman;
    public GameObject archer;
    public GameObject hut;
    public GameObject crenelations;
    public GameObject spikes;
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
    public GameObject spikesButtonObject;
    public GameObject recruitListButtonObject;
    public GameObject archerButtonObject;
    public GameObject footmanButtonObject;
    public GameObject bossGateway;
    private GameObject currentEnemy;
    private Button offenseMapButton;
    private Button defenseMapButton;
    private Button beginRoundButton;
    private Button spellBookButton;
    private Button buildingListButton;
    private Button hutButton;
    private Button crenelationsButton;
    private Button spikesButton;
    private Button recruitListButton;
    private Button archerButton;
    private Button footmanButton;
    public TextMeshProUGUI beginRoundButtonText;
    public TextMeshProUGUI goldDisplay;
    public TextMeshProUGUI roundDisplay;
    public TextMeshProUGUI itemDropText;
    public TextMeshProUGUI buildingTooltip;
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
    public int enemyCount = 0;
    public int gold;
    public int currentBuildingCost;
    private int bossNumber = 0;
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
    private Vector3 bossSpawnLocation1;
    private Vector3 bossSpawnLocation2;
    private Vector3 bossSpawnLocation3;
    private Vector3 bossSpawnLocation4;
    private Vector3 currentBossSpawnLocation;
    private Vector3 humanoidOffset = new Vector3(0, 2f, 0);
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
    private Color goldColor;
    public Canvas mainCanvas;
    public TextMeshProUGUI repairTooltip;
    public GameObject repairTooltipObject;
    public bool repairing = false;
    public GameObject repairButtonObject;
    private Button repairButton;
    private Image repairButtonImage;
    private Color baseButtonColor;
    //public Texture2D repairCursorTexture;

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
        spikesButton = spikesButtonObject.GetComponent<Button>();
        footmanButton = footmanButtonObject.GetComponent<Button>();
        archerButton = archerButtonObject.GetComponent<Button>();
        repairButton = repairButtonObject.GetComponent<Button>();
        offenseMapButton.onClick.AddListener(SetOffenseMap);
        defenseMapButton.onClick.AddListener(SetDefenseMap);
        beginRoundButton.onClick.AddListener(BeginRound);
        spellBookButton.onClick.AddListener(ToggleSpellBook);
        recruitListButton.onClick.AddListener(ToggleRecruitment);
        repairButton.onClick.AddListener(ToggleRepairing);
        hutButton.onClick.AddListener(delegate { Build(hut, 1.0f, true, 15, new Vector3(0, 2.5f, 0)); });
        crenelationsButton.onClick.AddListener(delegate { Build(crenelations, 0f, false, 5, new Vector3(0, 6, 0)); });
        spikesButton.onClick.AddListener(delegate { Build(spikes, 3f, true, 10, new Vector3(0, 3, 0)); });
        footmanButton.onClick.AddListener(delegate { Recruit(footman, false, 7, new Vector3(0, 4, 0)); });
        archerButton.onClick.AddListener(delegate { Recruit(archer, false, 13, new Vector3(0, 4, 0)); });
        buildingListButton.onClick.AddListener(ToggleBuildingList);
        gatheredSpells = new List<GameObject>();
        activeSpells = new List<GameObject>();
        troopsAvailable = new List<GameObject>();
        buildingsAvailable = new List<GameObject>();
        troopsAvailable.Add(footmanButtonObject);
        troopsAvailable.Add(archerButtonObject);
        buildingsAvailable.Add(hutButtonObject);
        buildingsAvailable.Add(crenelationsButtonObject);
        buildingsAvailable.Add(spikesButtonObject);
        spellBookButtonObject.SetActive(false);
        repairTooltip = repairTooltipObject.GetComponent<TextMeshProUGUI>();
        repairButtonImage = repairButtonObject.GetComponent<Image>();
        baseButtonColor = repairButtonImage.color;
        ResetSpellLocation();
        creationCamera.enabled = false;
        goldColor = new Color(.9137f, .6666f, .0039f, 1);
        gold = 10;
        goldDisplay.text = "Gold: " + gold;
        bossGateway.transform.rotation = new Quaternion(0, 0, 0, 0);
        bossSpawnLocation1 = new Vector3(Random.Range(-70.5f, 70.5f), 1.25f, -62.35f);
        bossSpawnLocation2 = new Vector3(Random.Range(-70.5f, 70.5f), 1.25f, 47.07f);
        bossSpawnLocation3 = new Vector3(-89f, 1.25f, Random.Range(-53.5f, 37.75f));
        bossSpawnLocation4 = new Vector3(89f, 1.25f, Random.Range(-53.5f, 37.75f));
        Instantiate(bossGateway, bossSpawnLocation1, bossGateway.transform.rotation);
        Instantiate(bossGateway, bossSpawnLocation2, bossGateway.transform.rotation);
        bossGateway.transform.Rotate(0, 90, 0);
        Instantiate(bossGateway, bossSpawnLocation3, bossGateway.transform.rotation);
        Instantiate(bossGateway, bossSpawnLocation4, bossGateway.transform.rotation);
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
            if (Input.GetKeyDown("g"))
            {
                ToggleSpellBook();
            }
            if (Input.GetKeyDown("b"))
            {
                ToggleBuildingList();
            }
            if (Input.GetKeyDown("r"))
            {
                ToggleRecruitment();
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
                if (repairing)
                {
                    repairing = false;
                    repairButtonImage.color = baseButtonColor;
                    //Cursor.SetCursor(repairCursorTexture, Vector2.zero, CursorMode.Auto);
                }
            }
        }
        if (roundBegun)
        {
            if (playerScript.currentHP <= 0)
            {
                if (!playerDeath)
                {
                    mainCamera.transform.parent = null;
                    mainCamera.transform.rotation = Quaternion.Euler(75, 0, 0);
                    mainCamera.transform.position = defenseCameraPosition;
                    playerDeath = true;
                }
                RegisterCameraMovementOverhead();
            }
            else
            {
                RegisterCameraMovementInRound();
            }

            if (Input.GetKeyDown("escape"))
            {
                Pause();
            }
            if (enemyCount == 0)//handled in building under healthcheck()
            {
                beginRoundButtonObject.SetActive(true);
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
        while (Vector3.Distance(mainCamera.transform.position, player.transform.position) < 12)
        {
            mainCamera.transform.Translate(-Vector3.forward);
        }
        mainCamera.transform.position += new Vector3(0, 1, 0);
    }

    //Round Rotation Functionality
    void BeginRound()
    {
        if (roundBegun)
        {
            EndRound();
        }
        else
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
            repairing = false;
            roundBegun = true;
            offenseMapButtonObject.SetActive(false);
            defenseMapButtonObject.SetActive(false);
            beginRoundButtonObject.SetActive(false);
            spellBookButtonObject.SetActive(false);
            buildingListButtonObject.SetActive(false);
            recruitListButtonObject.SetActive(false);
            repairButtonObject.SetActive(false);
            repairButtonImage.color = baseButtonColor;
            mainCamera.transform.parent = player.transform;
            ZoomIn();
            activeSpells.ShuffleList();
            playerScript.RoundBegin();
            beginRoundButtonText.text = "End Round";
            StartCoroutine(RoundTextReset());
            SpawnRoundWave();
        }
    }

    void EndRound()
    {
        roundBegun = false;
        playerDeath = false;
        offenseMapButtonObject.SetActive(true);
        buildingListButtonObject.SetActive(true);
        recruitListButtonObject.SetActive(true);
        repairButtonObject.SetActive(true);
        mainCamera.transform.parent = null;
        mainCamera.transform.rotation = Quaternion.Euler(75, 0, 0);
        mainCamera.transform.position = defenseCameraPosition;
        playerScript.RoundEnd();
        roundDisplay.text = "Round " + currentRound + " Completed";
        roundDisplay.color = new Color(.1607f, .2157f, .7765f, 1);
        beginRoundButtonText.text = "Begin Round";
        StartCoroutine(RoundTextReset());
        currentRound++;
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
            buildingTooltip.text = "Select spells for the next round. Cycling spells refreshes their cooldown.";
        }
        else
        {
            spellBookOpen = false;
            foreach (GameObject spell in gatheredSpells)
            {
                spell.SetActive(false);
            }
            buildingTooltip.text = "";
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
            buildingTooltip.text = "Buildings are unmoving and stronger than recruits for their cost.";
        }
        else
        {
            buildingListOpen = false;
            foreach (GameObject building in buildingsAvailable)
            {
                building.SetActive(false);
            }
            buildingTooltip.text = "";
        }
        if (constructing)
        {
            if (currentBuilding != null)
            {
                Destroy(currentBuilding);
            }
            constructing = false;
            creationCamera.enabled = false;
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
            buildingTooltip.text = "Recruits heal after each round and will help when adventuring.";
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
            buildingTooltip.text = "";
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
        if (gold >= cost)
        {
            if (currentBuilding != null)
            {
                Destroy(currentBuilding);
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
            roundDisplay.text = "Not Enough Gold ";
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
            roundDisplay.text = "Not Enough Gold ";
        }
    }
    public void SpawnEnemy(GameObject enemy, Vector3 offset)
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
        enemyCount++;
    }
    void SpawnEnemyDistributed(GameObject enemy, Vector3 offset)
    {
        if (Mathf.Abs(laneBalance1 - laneBalance2) > 2)
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
        enemyCount++;
    }
    private void SpawnBoss(GameObject enemy, Vector3 offset)
    {
        while (bossNumber < 4)
        {
            if (bossNumber == 0)
            {
                currentBossSpawnLocation = bossSpawnLocation1;
            }
            if (bossNumber == 1)
            {
                currentBossSpawnLocation = bossSpawnLocation2;
            }
            if (bossNumber == 2)
            {
                currentBossSpawnLocation = bossSpawnLocation3;
            }
            if (bossNumber == 3)
            {
                currentBossSpawnLocation = bossSpawnLocation4;
            }
            currentBuilding = Instantiate(enemy, new Vector3(currentBossSpawnLocation.x, enemy.transform.position.y, currentBossSpawnLocation.z), enemy.transform.rotation);
            GeneralizedSpawn(offset);
            bossNumber++;
            enemyCount++;
        }
    }
    private void SpawnRoundWave()
    {
        bool bossRound = false;
        if (currentRound == 1)
        {
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
        }
        if (currentRound == 2)
        {
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
        }
        if (currentRound == 3)
        {
            SpawnBoss(chieftan, humanoidOffset);
            bossRound = true;
        }
        if (currentRound == 4)
        {
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(grunt, humanoidOffset);
            SpawnEnemy(javleneer, humanoidOffset);
        }
        if (bossRound)
        {
            roundDisplay.text = "Boss Round!";
            roundDisplay.color = new Color(1f, 0f, 0f, 1);
        }
        else
        {
            roundDisplay.text = "Round " + currentRound;
            roundDisplay.color = new Color(.3882f, .8314f, .1897f, 1);
        }
        bossNumber = 0;
    }
    private IEnumerator RoundTextReset()
    {
        yield return new WaitForSeconds(3);
        roundDisplay.color = new Color(0, 0, 0, 0);
        roundDisplay.text = "";
    }
    public void ToggleRepairing()
    {
        if (repairing)
        {
            repairing = false;
        }
        else
        {
            repairing = true;
        }
        repairing = true;
        repairButtonImage.color = new Color(1, 0, 0, 1);
        //Cursor.SetCursor(repairCursorTexture, Vector2.zero, CursorMode.Auto);
    }
    public void DropTextResetShell(float duration)
    {
        StartCoroutine(DropTextReset(duration));
    }
    private IEnumerator DropTextReset(float duration)
    {
        yield return new WaitForSeconds(duration);
        itemDropText.color = new Color(0, 0, 0, 0);
        itemDropText.text = "";
    }
    //Misc Methods
    void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void GainGold(int goldGained)
    {
        gold += goldGained;
        itemDropText.color = goldColor;
        if (goldGained > 0)
        {
            itemDropText.text = "+" + goldGained + " Gold";
        }
        else
        {
            itemDropText.text = goldGained + " Gold";
        }
        goldDisplay.text = "Gold: " + gold;
        StartCoroutine(DropTextReset(1.9f));
    }
    void GeneralizedSpawn(Vector3 offset)
    {
        currentBuildingScript = currentBuilding.GetScript() as Building;
        currentBuildingScript.castle = castle;
        currentBuildingScript.cost = currentBuildingCost;
        currentBuildingScript.mainCanvas = mainCanvas;
        currentBuildingScript.repairTooltip = repairTooltip;
        currentBuildingScript.gameManagerScript = gameObject.GetComponent<GameManager>();
        currentBuildingScript.healthAndDamageCanvasScript.maxHP = (int)currentBuildingScript.maxHP;
    }
    void ResetSpellLocation()
    {
        spellXLocation = -250;
        spellYLocation = 250;
    }
}
