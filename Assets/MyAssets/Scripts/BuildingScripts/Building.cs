using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Building : DamageableObject
{
    //This class is parent to Ally and Enemy.

    public float rangedAttackRange;
    public float rangedAttackDamage;
    public float sightRange;
    public float attackCooldownRanged;
    public float attackDamage;
    public float attackRange;
    public float attackDurationFloat;
    public List<GameObject> itemDrops;
    public bool cleavingAttackBool;
    public bool hitsFlying;
    public int cost;
    public int spikeSelfDamage;
    public int level;
    protected float distanceToTarget;
    protected int potentialXP;
    public int currentXP;
    private int repairCost;
    public bool endRoundCheck;
    protected bool isRanged;
    private bool lootPositionChecked;
    private bool canvasTimer;
    private bool checkedSpawn;
    private bool projectile1Fired;
    protected bool attackCooldownActive;
    protected bool attackDurationActive;
    protected bool cleavingAttackCooldownActive;
    protected bool cleavingAttackDurationActive;
    protected bool attackReadyRanged;
    protected bool following;
    private string trueName;
    public Vector3 startPosition;
    private Vector3 lootPosition;
    public Vector3 startingPosition;
    protected Vector3 targetPosition;
    private Vector3 spawnPoint;
    public GameObject projectile;
    private GameObject projectile1;
    private GameObject projectile2;
    public GameObject target;
    public GameObject rangeFinder;
    public GameObject castle;
    public GameObject gameManager;
    public GameManager gameManagerScript;
    public GameObject rank2Marker;
    public GameObject rank3Marker;
    public GameObject repairTooltipObject;
    public GameObject nameTextObject;
    protected GameObject player;
    public GameObject buildPositionObject;
    public static GameObject fireBallBook;
    public static GameObject blinkBook;
    public static GameObject bulwarkBook;
    public static GameObject summonImpBook;
    public static GameObject iceWaveBook;
    public static GameObject slamBook;
    public static GameObject smallGoldReward;
    public static GameObject mediumGoldReward;
    public static GameObject largeGoldReward;
    public static GameObject mountainousGoldReward;
    public static GameObject smallXPReward;
    public static GameObject largeXPReward;
    public Canvas mainCanvas;
    public TextMeshProUGUI repairTooltip;
    public TextMeshPro nameText;
    protected List<GameObject> targets;
    public RangeFinder rangeFinderScript;
    public DamageableObject targetScript;
    public BuildPosition buildPositionScript;
    //protected Projectile projectileScript;
    protected Projectile projectileScript1;
    protected Projectile projectileScript2;
    public Player playerScript;

    //this is for Castle which runs buildingScript directly
    void Update()
    {
        StatusCheck();
    }
    //Handles all communal code needed for buildings, call method in update. For melle, set rangedAttackRange to -1 or any value at least .5 below their attackRange.
    protected void BuildingUpdate()
    {
        //Ranged Attack
        if (attackReadyRanged && target != null && distanceToTarget <= rangedAttackRange + .4f && checkedSpawn && isRanged && !following)
        {
            FireProjectile();
        }
        StatusCheck();
        UICheck();
        //Checks for the end of the round
        if(gameManagerScript.roundBegun && endRoundCheck)
        {
            endRoundCheck = false;
        }
    }
    //Activates and deactivates ui elements so that nearby buttons are not blocked.
    private void UICheck()
    {
        if (!gameManagerScript.roundBegun && canvasTimer)
        {
            if (rangeFinder.activeSelf)
            {
                rangeFinder.SetActive(false);
            }
            if (healthAndDamageCanvas.activeSelf)
            {
                healthAndDamageCanvas.SetActive(false);
            }
        }
        else
        {
            if (!rangeFinder.activeSelf)
            {
                rangeFinder.SetActive(true);
            }
            if (!healthAndDamageCanvas.activeSelf)
            {
                healthAndDamageCanvas.SetActive(true);
            }
        }
    }
    void Awake()
    {
        //Initializes castle (castle directly uses building script)
        if (name == "Castle")
        {
            repairTooltip = repairTooltipObject.GetComponent<TextMeshProUGUI>();
            gameManagerScript = gameManager.GetComponent<GameManager>();
            healthAndDamageCanvasScript = healthAndDamageCanvas.GetComponent<HealthAndDamageCanvas>();
            healthAndDamageCanvasScript.maxHP = 50;
            cost = 25;
            trueName = FindTrueName();
            //stores static building variables in castle for future use.
            fireBallBook = GameObject.Find("FireBallBook");
            blinkBook = GameObject.Find("BlinkBook");
            bulwarkBook = GameObject.Find("BulwarkBook");
            summonImpBook = GameObject.Find("SummonImpBook");
            iceWaveBook = GameObject.Find("IceWaveBook");
            slamBook = GameObject.Find("SlamBook");
            smallGoldReward = GameObject.Find("SmallGoldReward");
            mediumGoldReward = GameObject.Find("MediumGoldReward");
            largeGoldReward = GameObject.Find("LargeGoldReward");
            mountainousGoldReward = GameObject.Find("MountainousGoldReward");
            smallXPReward = GameObject.Find("SmallXPReward");
            largeXPReward = GameObject.Find("LargeXPReward");
        }
    }
    //All standardized building initializations.
    protected void Begin()
    {
        if(transform.Find("AttackHitbox") != null)
        {
            attackHitboxScript = attackHitbox.GetComponent<AttackHitbox>();
        }
        if(nameTextObject != null)
        {
            nameText = nameTextObject.GetComponent<TextMeshPro>();
        }
        StartCoroutine(TaggingDelay());
        StartCoroutine(SpawnChecker());
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Character");
        playerScript = player.GetComponent<Player>();
        healthAndDamageCanvasScript = healthAndDamageCanvas.GetComponent<HealthAndDamageCanvas>();
        healthAndDamageCanvasScript.maxHP = (int)maxHP;
        gameManagerScript = gameManager.GetComponent<GameManager>();
        buildPositionObject = GameObject.Find("BuildPosition");
        buildPositionScript = buildPositionObject.GetComponent<BuildPosition>();
        targets = new List<GameObject>();
        rangeFinderScript = rangeFinder.GetComponent<RangeFinder>();
        StartCoroutine(CanvasTimer());
        trueName = FindTrueName();
        //changes Y range of their sight hitbox to include flying units
        if (!hitsFlying)
        {
            rangeFinder.transform.localScale = new Vector3(sightRange, .25f, sightRange);
        }
        else
        {
            rangeFinder.transform.localScale = new Vector3(sightRange, 2, sightRange);
        }
        if (isRanged)
        {
            spawnPoint = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            projectile1 = Instantiate(projectile, new Vector3(spawnPoint.x + 1000, spawnPoint.y + 1000, spawnPoint.z + 1000), projectile.transform.rotation);
            projectileScript1 = projectile1.GetScript() as Projectile;
            projectileScript1.building = gameObject;
            if (rangedAttackDamage != 0)
            {
                projectileScript1.damage = rangedAttackDamage;
            }
            projectile2 = Instantiate(projectile, new Vector3(spawnPoint.x + 1001, spawnPoint.y + 1001, spawnPoint.z + 1001), projectile.transform.rotation);
            projectileScript2 = projectile2.GetScript() as Projectile;
            if(rangedAttackDamage != 0)
            {
                projectileScript2.damage = rangedAttackDamage;
            }
            projectileScript2.building = gameObject;
        }
    }
    //Creates an object assigned as the projectile and initializes it. Projectile code will determine things like speed and projectile damage
    protected void FireProjectile()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        if (!projectile1Fired)
        {
            projectileScript1.startPosition = projectile1.transform.position;
            projectile1.transform.position = spawnPoint;
            projectileScript1.target = target;
            projectileScript1.targetScript = targetScript;
            projectileScript1.active = true;
            projectile1Fired = true;
        }
        else
        {
            projectileScript2.startPosition = projectile2.transform.position;
            projectile2.transform.position = spawnPoint;
            projectileScript2.target = target;
            projectileScript2.targetScript = targetScript;
            projectileScript2.active = true;
            projectile1Fired = false;
        }
        attackReadyRanged = false;
        StartCoroutine(RangedAttackCooldown());
    }
    /*protected void FireProjectile()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        GameObject projectileFired = Instantiate(projectile, spawnPoint, projectile.transform.rotation) as GameObject;
        projectileScript = projectileFired.GetScript() as Projectile;
        projectileScript.target = target;
        projectileScript.targetScript = targetScript;
        projectileScript.building = gameObject;
        attackReadyRanged = false;
        StartCoroutine(RangedAttackCooldown());
    }*/
    protected void StatusCheck()
    {
        //checks for death
        if (currentHP < 1)
        {
            if (!lootPositionChecked)
            {
                lootPosition = new Vector3(transform.position.x, .7f, transform.position.z);
                lootPositionChecked = true;
                StartCoroutine(DestroyDelay());
            }
            if(name == "Castle")
            {
                SceneManager.LoadScene(2);
            }
        }
        //checks for round end
        if (!gameManagerScript.roundBegun && !endRoundCheck && !gameManagerScript.constructing && (tag == "Ally"))
        {
            endRoundCheck = true;
            FullHeal();
            transform.position = startingPosition;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    //Must be moved before destruction to trigger onTriggerExit of other rangeFinders
    protected IEnumerator DestroyDelay()
    {
        transform.Translate(100000, 100000, 100000);
        yield return new WaitForSeconds(.1f);
        //if ally or building, ResetPositionScript will make place built available for building/recruiting once more. 
        ResetPositionScript();
        if (tag == "Enemy")
        {
            gameManagerScript.enemyCount--;
            SpawnEnemyDrop();
        }
        Destroy(gameObject);
    }
    private void SpawnEnemyDrop()
    {
        float dropRoll = Random.Range(0, 100);
        if (dropRoll > .9)
        {
            Instantiate(itemDrops[0], lootPosition, itemDrops[0].transform.rotation);
        }
        else if (dropRoll > .75)
        {
            Instantiate(itemDrops[1], lootPosition, itemDrops[0].transform.rotation);
        }
        else if (dropRoll > .5)
        {
            Instantiate(itemDrops[2], lootPosition, itemDrops[0].transform.rotation);
        }
        else
        {
            Instantiate(itemDrops[3], lootPosition, itemDrops[0].transform.rotation);
        }
    }
    protected IEnumerator RangedAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownRanged);
        attackReadyRanged = true;
    }
    //Needs to be overridden and called in lowest child
    protected IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
    }
    private IEnumerator SpawnChecker()
    {
        yield return new WaitForSeconds(.1f);
        checkedSpawn = true;
    }
    //MelleAttack is called if not a cleaving unit
    protected void MelleAttack()
    {
        attackCooldownActive = true;
        attackDurationActive = true;
        StartCoroutine(MelleAttackCooldown());
        DealDamage(attackDamage);
    }
    IEnumerator CanvasTimer()
    {
        yield return new WaitForSeconds(.1f);
        canvasTimer = true;
    }
    IEnumerator MelleAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownFloat);
        attackCooldownActive = false;
    }
    //CleavingAttack is called if is a cleaving unit
    protected void CleavingAttack()
    {
        attackCooldownActive = true;
        cleavingAttackDurationActive = true;
        StartCoroutine(MelleAttackCooldown());
        StartCoroutine(CleavingAttackDuration());
    }
    //Damages all objects within the attackHitbox
    protected IEnumerator CleavingAttackDuration()
    {
        yield return new WaitForSeconds(attackDurationFloat);
        foreach (GameObject target in attackHitboxScript.targets)
        {
            DamageableObject currentTargetScript = target.GetScript() as DamageableObject;
            currentTargetScript.TakeDamage(attackDamage);
        }
        cleavingAttackDurationActive = false;
    }
    //Adds a target to the targetList, if it is the only target then it is set as the target object, if not the only one then RemoveTarget will handle resetting target gameObject.
    public void AddTarget(GameObject newTarget)
    {
        targets.Add(newTarget);
        if (targets.Count == 1)
        {
            target = targets[0];
            targetScript = target.GetScript() as DamageableObject;
            following = false;
        }
    }
    //Removes the target and sets the next available target in targets[] to the target gameObject.
    public void RemoveTarget(GameObject targetToRemove)
    {
        targets.Remove(targetToRemove);
        if (targets.Count == 0)
        {
            target = null;
            targetScript = null;
        }
        else
        {
            target = gameObject.GetClosest(targets);
            if(target != null)
            {
                targetScript = target.GetScript() as DamageableObject;
            }
        }
    }
    //deals damage (potentialXP only returns a value other than 0 if the unit is killed by the attack.)
    public void DealDamage(float damage)
    {
        potentialXP = targetScript.TakeDamage(damage);
        if (level < 3 && potentialXP > 0)
        {
            GainXP(potentialXP);
        } 
    }
    public void GainXP(int xp)
    {
        currentXP += xp;
        if (currentXP >= 10 + 10 * level)
        {
            LevelUp();
        }
    }
    //override this in childest children for diff effects for leveling
    public void LevelUp()
    {
        currentXP -= 10 + 10 * level;
        level++;
        if (level == 1)
        {
            if (rank2Marker != null)
            {
                rank2Marker.SetActive(true);
            }
            nameText.text = trueName + " (Rank 2)";
        }
        if (level == 2)
        {
            if (rank3Marker != null)
            {
                rank3Marker.SetActive(true);
            }
            nameText.text = trueName + " (Rank 3)";
        }
        maxHP += 2;
        Heal(2);
    }
    public void SpikeDamageLoop(DamageableObject spikeTargetScript)
    {
        if (targets.Contains(spikeTargetScript.gameObject))
        {
            spikeTargetScript.TakeDamage(attackDamage);
            TakeDamage(spikeSelfDamage);
            StartCoroutine(SpikeDamageReset(spikeTargetScript));
        }
    }
    private IEnumerator SpikeDamageReset(DamageableObject spikeTargetScript)
    {
        yield return new WaitForSeconds(2.2f);
        if(spikeTargetScript.gameObject != null)
        {
            SpikeDamageLoop(spikeTargetScript);
        }
    }
    //removes (clone) from name for ui purposes
    private string FindTrueName()
    {
        int charIndex = 0;
        for(int i = 0; i < name.Length; i++)
        {
            if (name[i] == '(')
            {
                return name.Substring(0, charIndex);
            }
            else
            {
                charIndex++;
            }
        }
        return name.Substring(0, charIndex);
    }
    //Shows repair tooltip if repairing and repairable
    void OnMouseEnter()
    {
        if(tag == "Building" && currentHP < maxHP && gameManagerScript.repairing)
        {
            Vector2 pos;
            repairCost = (int)(cost * (1 - currentHP / maxHP) / 2);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(mainCanvas.transform as RectTransform, Input.mousePosition, mainCanvas.worldCamera, out pos);
            repairTooltip.text = "Repair this " + trueName + " for " + repairCost + " gold.";
            repairTooltip.transform.position = mainCanvas.transform.TransformPoint(pos);
        }
    }
    void OnMouseExit()
    {
        if (tag == "Building")
        {
            repairTooltip.text = "";
        }
    }
    //Attempts to repair the building
    void OnMouseDown()
    {
        if (tag == "Building" && !gameManagerScript.roundBegun)
        {
            if (gameManagerScript.repairing && currentHP < maxHP && gameManagerScript.gold >= repairCost)
            {
                gameManagerScript.GainGold((-repairCost));
                FullHeal();
                repairTooltip.text = "";
                repairTooltip.transform.position = new Vector2(0, 0);
            }
            /*else if(gameManagerScript.repairing && currentHP < maxHP && gameManagerScript.gold < repairCost)
            {
                Heal((maxHP - currentHP) / (repairCost / gameManagerScript.gold));
                gameManagerScript.GainGold((-gameManagerScript.gold));
            }*/
        }
    }





    //Handles re-enabling the relevant build position after building or recruit is destroyed. Leave in the wastleland.
    public bool position1 = false;
    public bool position2 = false;
    public bool position3 = false;
    public bool position4 = false;
    public bool position5 = false;
    public bool position6 = false;
    public bool position7 = false;
    public bool position8 = false;
    public bool position9 = false;
    public bool position10 = false;
    public bool position11 = false;
    public bool position12 = false;
    public bool position13 = false;
    public bool position14 = false;
    public bool position15 = false;
    public bool position16 = false;
    public bool position17 = false;
    public bool position18 = false;
    public bool position19 = false;
    public bool position20 = false;
    public bool position21 = false;
    public bool position22 = false;
    public bool position23 = false;
    public bool position24 = false;
    public bool position25 = false;
    public bool position26 = false;
    public bool position27 = false;
    public bool position28 = false;
    public bool position29 = false;
    public bool position30 = false;
    public bool position31 = false;
    public bool position32 = false;
    public bool position33 = false;
    public bool position34 = false;
    public bool position35 = false;
    public bool position36 = false;
    public bool position37 = false;
    public bool position38 = false;
    public bool position39 = false;
    public bool position40 = false;
    public bool position41 = false;
    public bool position42 = false;
    public bool position43 = false;
    public bool position44 = false;
    public bool position45 = false;
    public bool position46 = false;
    public bool position47 = false;
    public bool position48 = false;
    public bool position49 = false;
    public bool position50 = false;
    public bool position51 = false;
    public bool position52 = false;
    public bool position53 = false;
    public bool position54 = false;
    public bool position55 = false;
    public bool position56 = false;
    public bool position57 = false;
    public bool position58 = false;
    public bool position59 = false;
    public bool position60 = false;
    public bool position61 = false;
    public bool position62 = false;
    public bool position63 = false;
    public bool position64 = false;
    public bool position65 = false;
    public bool position66 = false;
    public bool position67 = false;
    public bool position68 = false;
    public bool position69 = false;
    public bool position70 = false;
    public bool position71 = false;
    public bool position72 = false;
    public bool position73 = false;
    public bool position74 = false;
    public bool position75 = false;
    public bool position76 = false;
    public bool position77 = false;
    public bool position78 = false;
    public bool position79 = false;
    public bool position80 = false;
    public bool position81 = false;
    public bool position82 = false;
    public bool position83 = false;
    public bool position84 = false;
    public bool position85 = false;
    public bool position86 = false;
    public bool position87 = false;
    public bool position88 = false;
    public bool position89 = false;
    public bool position90 = false;
    public bool position91 = false;
    public bool position92 = false;
    public bool position93 = false;
    public bool position94 = false;
    public bool position95 = false;
    public bool position96 = false;
    public bool position97 = false;
    public bool position98 = false;
    public bool position99 = false;
    public bool position100 = false;
    public bool position101 = false;
    public bool position102 = false;
    public bool position103 = false;
    public bool position104 = false;
    public bool position105 = false;
    public bool position106 = false;
    public bool position107 = false;
    public bool position108 = false;
    public bool position109 = false;
    public bool position110 = false;
    public bool position111 = false;
    public bool position112 = false;
    public bool position113 = false;
    public bool position114 = false;
    public bool position115 = false;
    public bool position116 = false;
    public bool position117 = false;
    public bool position118 = false;
    public bool position119 = false;
    public bool position120 = false;
    public bool position121 = false;
    public bool position122 = false;
    public bool position123 = false;
    public bool position124 = false;
    public bool position125 = false;
    public bool position126 = false;
    public bool position1R = false;
    public bool position2R = false;
    public bool position3R = false;
    public bool position4R = false;
    public bool position5R = false;
    public bool position6R = false;
    public bool position7R = false;
    public bool position8R = false;
    public bool position9R = false;
    public bool position10R = false;
    public bool position11R = false;
    public bool position12R = false;
    public bool position13R = false;
    public bool position14R = false;
    public bool position15R = false;
    public bool position16R = false;
    public bool position17R = false;
    public bool position18R = false;
    public bool position19R = false;
    public bool position20R = false;
    public bool position21R = false;
    public bool position22R = false;
    public bool position23R = false;
    public bool position24R = false;
    public bool position25R = false;
    public bool position26R = false;
    public bool position27R = false;
    public bool position28R = false;
    public bool position29R = false;
    public bool position30R = false;
    public bool position31R = false;
    public bool position32R = false;
    public bool position33R = false;
    public bool position34R = false;
    public bool position35R = false;
    public bool position36R = false;
    public bool position37R = false;
    public bool position38R = false;
    public bool position39R = false;
    public bool position40R = false;
    public bool position41R = false;
    public bool position42R = false;
    public bool position43R = false;
    public bool position44R = false;
    public bool position45R = false;
    public bool position46R = false;
    public bool position47R = false;
    public bool position48R = false;
    public bool position49R = false;
    public bool position50R = false;
    public bool position51R = false;
    public bool position52R = false;
    public bool position53R = false;
    public bool position54R = false;
    public bool position55R = false;
    public bool position56R = false;
    public bool position57R = false;
    public bool position58R = false;
    public bool position59R = false;
    public bool position60R = false;
    public bool position61R = false;
    public bool position62R = false;
    public bool position63R = false;
    public bool position64R = false;
    public bool position65R = false;
    public bool position66R = false;
    public bool position67R = false;
    public bool position68R = false;
    public bool position69R = false;
    public bool position70R = false;
    public bool position71R = false;
    public bool position72R = false;
    public bool position73R = false;
    public bool position74R = false;
    public bool position75R = false;
    public bool position76R = false;
    public bool position77R = false;
    public bool position78R = false;
    public bool position79R = false;
    public bool position80R = false;
    public bool position81R = false;
    public bool position82R = false;
    public bool position83R = false;
    public bool position84R = false;
    public bool position85R = false;
    public bool position86R = false;
    public bool position87R = false;
    public bool position88R = false;
    public bool position89R = false;
    public bool position90R = false;
    public bool position91R = false;
    public bool position92R = false;
    public bool position93R = false;
    public bool position94R = false;
    public bool position95R = false;
    public bool position96R = false;
    public bool position97R = false;
    public bool position98R = false;
    public bool position99R = false;
    public bool position100R = false;
    public bool position101R = false;
    public bool position102R = false;
    public bool position103R = false;
    public bool position104R = false;
    public bool position105R = false;
    public bool position106R = false;
    public bool position107R = false;
    public bool position108R = false;
    public bool position109R = false;
    public bool position110R = false;
    public bool position111R = false;
    public bool position112R = false;
    public bool position113R = false;
    public bool position114R = false;
    public bool position115R = false;
    public bool position116R = false;
    public bool position117R = false;
    public bool position118R = false;
    public bool position119R = false;
    public bool position120R = false;
    public bool position121R = false;
    public bool position122R = false;
    public bool position123R = false;
    public bool position124R = false;
    public bool position125R = false;
    public bool position126R = false;
    protected void ResetPositionScript()
    {
        if(tag == "Building")
        {
            gameManagerScript.alliesRemaining--;
            if (position1)
            {
                buildPositionScript.position1Building = false;
            }
            if (position2)
            {
                buildPositionScript.position2Building = false;
            }
            if (position3)
            {
                buildPositionScript.position3Building = false;
            }
            if (position4)
            {
                buildPositionScript.position4Building = false;
            }
            if (position5)
            {
                buildPositionScript.position5Building = false;
            }
            if (position6)
            {
                buildPositionScript.position6Building = false;
            }
            if (position7)
            {
                buildPositionScript.position7Building = false;
            }
            if (position8)
            {
                buildPositionScript.position8Building = false;
            }
            if (position9)
            {
                buildPositionScript.position9Building = false;
            }
            if (position10)
            {
                buildPositionScript.position10Building = false;
            }
            if (position11)
            {
                buildPositionScript.position11Building = false;
            }
            if (position12)
            {
                buildPositionScript.position12Building = false;
            }
            if (position13)
            {
                buildPositionScript.position13Building = false;
            }
            if (position14)
            {
                buildPositionScript.position14Building = false;
            }
            if (position15)
            {
                buildPositionScript.position15Building = false;
            }
            if (position16)
            {
                buildPositionScript.position16Building = false;
            }
            if (position17)
            {
                buildPositionScript.position17Building = false;
            }
            if (position18)
            {
                buildPositionScript.position18Building = false;
            }
            if (position19)
            {
                buildPositionScript.position19Building = false;
            }
            if (position20)
            {
                buildPositionScript.position20Building = false;
            }
            if (position21)
            {
                buildPositionScript.position21Building = false;
            }
            if (position22)
            {
                buildPositionScript.position22Building = false;
            }
            if (position23)
            {
                buildPositionScript.position23Building = false;
            }
            if (position24)
            {
                buildPositionScript.position24Building = false;
            }
            if (position25)
            {
                buildPositionScript.position25Building = false;
            }
            if (position26)
            {
                buildPositionScript.position26Building = false;
            }
            if (position27)
            {
                buildPositionScript.position27Building = false;
            }
            if (position28)
            {
                buildPositionScript.position28Building = false;
            }
            if (position29)
            {
                buildPositionScript.position29Building = false;
            }
            if (position30)
            {
                buildPositionScript.position30Building = false;
            }
            if (position31)
            {
                buildPositionScript.position31Building = false;
            }
            if (position32)
            {
                buildPositionScript.position32Building = false;
            }
            if (position33)
            {
                buildPositionScript.position33Building = false;
            }
            if (position34)
            {
                buildPositionScript.position34Building = false;
            }
            if (position35)
            {
                buildPositionScript.position35Building = false;
            }
            if (position36)
            {
                buildPositionScript.position36Building = false;
            }
            if (position37)
            {
                buildPositionScript.position37Building = false;
            }
            if (position38)
            {
                buildPositionScript.position38Building = false;
            }
            if (position39)
            {
                buildPositionScript.position39Building = false;
            }
            if (position40)
            {
                buildPositionScript.position40Building = false;
            }
            if (position41)
            {
                buildPositionScript.position41Building = false;
            }
            if (position42)
            {
                buildPositionScript.position42Building = false;
            }
            if (position43)
            {
                buildPositionScript.position43Building = false;
            }
            if (position44)
            {
                buildPositionScript.position44Building = false;
            }
            if (position45)
            {
                buildPositionScript.position45Building = false;
            }
            if (position46)
            {
                buildPositionScript.position46Building = false;
            }
            if (position47)
            {
                buildPositionScript.position47Building = false;
            }
            if (position48)
            {
                buildPositionScript.position48Building = false;
            }
            if (position49)
            {
                buildPositionScript.position49Building = false;
            }
            if (position50)
            {
                buildPositionScript.position50Building = false;
            }
            if (position51)
            {
                buildPositionScript.position51Building = false;
            }
            if (position52)
            {
                buildPositionScript.position52Building = false;
            }
            if (position53)
            {
                buildPositionScript.position53Building = false;
            }
            if (position54)
            {
                buildPositionScript.position54Building = false;
            }
            if (position55)
            {
                buildPositionScript.position55Building = false;
            }
            if (position56)
            {
                buildPositionScript.position56Building = false;
            }
            if (position57)
            {
                buildPositionScript.position57Building = false;
            }
            if (position58)
            {
                buildPositionScript.position58Building = false;
            }
            if (position59)
            {
                buildPositionScript.position59Building = false;
            }
            if (position60)
            {
                buildPositionScript.position60Building = false;
            }
            if (position61)
            {
                buildPositionScript.position61Building = false;
            }
            if (position62)
            {
                buildPositionScript.position62Building = false;
            }
            if (position63)
            {
                buildPositionScript.position63Building = false;
            }
            if (position64)
            {
                buildPositionScript.position64Building = false;
            }
            if (position65)
            {
                buildPositionScript.position65Building = false;
            }
            if (position66)
            {
                buildPositionScript.position66Building = false;
            }
            if (position67)
            {
                buildPositionScript.position67Building = false;
            }
            if (position68)
            {
                buildPositionScript.position68Building = false;
            }
            if (position69)
            {
                buildPositionScript.position69Building = false;
            }
            if (position70)
            {
                buildPositionScript.position70Building = false;
            }
            if (position71)
            {
                buildPositionScript.position71Building = false;
            }
            if (position72)
            {
                buildPositionScript.position72Building = false;
            }
            if (position73)
            {
                buildPositionScript.position73Building = false;
            }
            if (position74)
            {
                buildPositionScript.position74Building = false;
            }
            if (position75)
            {
                buildPositionScript.position75Building = false;
            }
            if (position76)
            {
                buildPositionScript.position76Building = false;
            }
            if (position77)
            {
                buildPositionScript.position77Building = false;
            }
            if (position78)
            {
                buildPositionScript.position78Building = false;
            }
            if (position79)
            {
                buildPositionScript.position79Building = false;
            }
            if (position80)
            {
                buildPositionScript.position80Building = false;
            }
            if (position81)
            {
                buildPositionScript.position81Building = false;
            }
            if (position82)
            {
                buildPositionScript.position82Building = false;
            }
            if (position83)
            {
                buildPositionScript.position83Building = false;
            }
            if (position84)
            {
                buildPositionScript.position84Building = false;
            }
            if (position85)
            {
                buildPositionScript.position85Building = false;
            }
            if (position86)
            {
                buildPositionScript.position86Building = false;
            }
            if (position87)
            {
                buildPositionScript.position87Building = false;
            }
            if (position88)
            {
                buildPositionScript.position88Building = false;
            }
            if (position89)
            {
                buildPositionScript.position89Building = false;
            }
            if (position90)
            {
                buildPositionScript.position90Building = false;
            }
            if (position91)
            {
                buildPositionScript.position91Building = false;
            }
            if (position92)
            {
                buildPositionScript.position92Building = false;
            }
            if (position93)
            {
                buildPositionScript.position93Building = false;
            }
            if (position94)
            {
                buildPositionScript.position94Building = false;
            }
            if (position95)
            {
                buildPositionScript.position95Building = false;
            }
            if (position96)
            {
                buildPositionScript.position96Building = false;
            }
            if (position97)
            {
                buildPositionScript.position97Building = false;
            }
            if (position98)
            {
                buildPositionScript.position98Building = false;
            }
            if (position99)
            {
                buildPositionScript.position99Building = false;
            }
            if (position100)
            {
                buildPositionScript.position100Building = false;
            }
            if (position101)
            {
                buildPositionScript.position101Building = false;
            }
            if (position102)
            {
                buildPositionScript.position102Building = false;
            }
            if (position103)
            {
                buildPositionScript.position103Building = false;
            }
            if (position104)
            {
                buildPositionScript.position104Building = false;
            }
            if (position105)
            {
                buildPositionScript.position105Building = false;
            }
            if (position106)
            {
                buildPositionScript.position106Building = false;
            }
            if (position107)
            {
                buildPositionScript.position107Building = false;
            }
            if (position108)
            {
                buildPositionScript.position108Building = false;
            }
            if (position109)
            {
                buildPositionScript.position109Building = false;
            }
            if (position110)
            {
                buildPositionScript.position110Building = false;
            }
            if (position111)
            {
                buildPositionScript.position111Building = false;
            }
            if (position112)
            {
                buildPositionScript.position112Building = false;
            }
            if (position113)
            {
                buildPositionScript.position113Building = false;
            }
            if (position114)
            {
                buildPositionScript.position114Building = false;
            }
            if (position115)
            {
                buildPositionScript.position115Building = false;
            }
            if (position116)
            {
                buildPositionScript.position116Building = false;
            }
            if (position117)
            {
                buildPositionScript.position117Building = false;
            }
            if (position118)
            {
                buildPositionScript.position118Building = false;
            }
            if (position119)
            {
                buildPositionScript.position119Building = false;
            }
            if (position120)
            {
                buildPositionScript.position120Building = false;
            }
            if (position121)
            {
                buildPositionScript.position121Building = false;
            }
            if (position122)
            {
                buildPositionScript.position122Building = false;
            }
            if (position123)
            {
                buildPositionScript.position123Building = false;
            }
            if (position124)
            {
                buildPositionScript.position124Building = false;
            }
            if (position125)
            {
                buildPositionScript.position125Building = false;
            }
            if (position126)
            {
                buildPositionScript.position126Building = false;
            }
        }
        if (tag == "Ally")
        {
            gameManagerScript.alliesRemaining--;
            if (position1)
            {
                buildPositionScript.position1Recruit = false;
            }
            if (position2)
            {
                buildPositionScript.position2Recruit = false;
            }
            if (position3)
            {
                buildPositionScript.position3Recruit = false;
            }
            if (position4)
            {
                buildPositionScript.position4Recruit = false;
            }
            if (position5)
            {
                buildPositionScript.position5Recruit = false;
            }
            if (position6)
            {
                buildPositionScript.position6Recruit = false;
            }
            if (position7)
            {
                buildPositionScript.position7Recruit = false;
            }
            if (position8)
            {
                buildPositionScript.position8Recruit = false;
            }
            if (position9)
            {
                buildPositionScript.position9Recruit = false;
            }
            if (position10)
            {
                buildPositionScript.position10Recruit = false;
            }
            if (position11)
            {
                buildPositionScript.position11Recruit = false;
            }
            if (position12)
            {
                buildPositionScript.position12Recruit = false;
            }
            if (position13)
            {
                buildPositionScript.position13Recruit = false;
            }
            if (position14)
            {
                buildPositionScript.position14Recruit = false;
            }
            if (position15)
            {
                buildPositionScript.position15Recruit = false;
            }
            if (position16)
            {
                buildPositionScript.position16Recruit = false;
            }
            if (position17)
            {
                buildPositionScript.position17Recruit = false;
            }
            if (position18)
            {
                buildPositionScript.position18Recruit = false;
            }
            if (position19)
            {
                buildPositionScript.position19Recruit = false;
            }
            if (position20)
            {
                buildPositionScript.position20Recruit = false;
            }
            if (position21)
            {
                buildPositionScript.position21Recruit = false;
            }
            if (position22)
            {
                buildPositionScript.position22Recruit = false;
            }
            if (position23)
            {
                buildPositionScript.position23Recruit = false;
            }
            if (position24)
            {
                buildPositionScript.position24Recruit = false;
            }
            if (position25)
            {
                buildPositionScript.position25Recruit = false;
            }
            if (position26)
            {
                buildPositionScript.position26Recruit = false;
            }
            if (position27)
            {
                buildPositionScript.position27Recruit = false;
            }
            if (position28)
            {
                buildPositionScript.position28Recruit = false;
            }
            if (position29)
            {
                buildPositionScript.position29Recruit = false;
            }
            if (position30)
            {
                buildPositionScript.position30Recruit = false;
            }
            if (position31)
            {
                buildPositionScript.position31Recruit = false;
            }
            if (position32)
            {
                buildPositionScript.position32Recruit = false;
            }
            if (position33)
            {
                buildPositionScript.position33Recruit = false;
            }
            if (position34)
            {
                buildPositionScript.position34Recruit = false;
            }
            if (position35)
            {
                buildPositionScript.position35Recruit = false;
            }
            if (position36)
            {
                buildPositionScript.position36Recruit = false;
            }
            if (position37)
            {
                buildPositionScript.position37Recruit = false;
            }
            if (position38)
            {
                buildPositionScript.position38Recruit = false;
            }
            if (position39)
            {
                buildPositionScript.position39Recruit = false;
            }
            if (position40)
            {
                buildPositionScript.position40Recruit = false;
            }
            if (position41)
            {
                buildPositionScript.position41Recruit = false;
            }
            if (position42)
            {
                buildPositionScript.position42Recruit = false;
            }
            if (position43)
            {
                buildPositionScript.position43Recruit = false;
            }
            if (position44)
            {
                buildPositionScript.position44Recruit = false;
            }
            if (position45)
            {
                buildPositionScript.position45Recruit = false;
            }
            if (position46)
            {
                buildPositionScript.position46Recruit = false;
            }
            if (position47)
            {
                buildPositionScript.position47Recruit = false;
            }
            if (position48)
            {
                buildPositionScript.position48Recruit = false;
            }
            if (position49)
            {
                buildPositionScript.position49Recruit = false;
            }
            if (position50)
            {
                buildPositionScript.position50Recruit = false;
            }
            if (position51)
            {
                buildPositionScript.position51Recruit = false;
            }
            if (position52)
            {
                buildPositionScript.position52Recruit = false;
            }
            if (position53)
            {
                buildPositionScript.position53Recruit = false;
            }
            if (position54)
            {
                buildPositionScript.position54Recruit = false;
            }
            if (position55)
            {
                buildPositionScript.position55Recruit = false;
            }
            if (position56)
            {
                buildPositionScript.position56Recruit = false;
            }
            if (position57)
            {
                buildPositionScript.position57Recruit = false;
            }
            if (position58)
            {
                buildPositionScript.position58Recruit = false;
            }
            if (position59)
            {
                buildPositionScript.position59Recruit = false;
            }
            if (position60)
            {
                buildPositionScript.position60Recruit = false;
            }
            if (position61)
            {
                buildPositionScript.position61Recruit = false;
            }
            if (position62)
            {
                buildPositionScript.position62Recruit = false;
            }
            if (position63)
            {
                buildPositionScript.position63Recruit = false;
            }
            if (position64)
            {
                buildPositionScript.position64Recruit = false;
            }
            if (position65)
            {
                buildPositionScript.position65Recruit = false;
            }
            if (position66)
            {
                buildPositionScript.position66Recruit = false;
            }
            if (position67)
            {
                buildPositionScript.position67Recruit = false;
            }
            if (position68)
            {
                buildPositionScript.position68Recruit = false;
            }
            if (position69)
            {
                buildPositionScript.position69Recruit = false;
            }
            if (position70)
            {
                buildPositionScript.position70Recruit = false;
            }
            if (position71)
            {
                buildPositionScript.position71Recruit = false;
            }
            if (position72)
            {
                buildPositionScript.position72Recruit = false;
            }
            if (position73)
            {
                buildPositionScript.position73Recruit = false;
            }
            if (position74)
            {
                buildPositionScript.position74Recruit = false;
            }
            if (position75)
            {
                buildPositionScript.position75Recruit = false;
            }
            if (position76)
            {
                buildPositionScript.position76Recruit = false;
            }
            if (position77)
            {
                buildPositionScript.position77Recruit = false;
            }
            if (position78)
            {
                buildPositionScript.position78Recruit = false;
            }
            if (position79)
            {
                buildPositionScript.position79Recruit = false;
            }
            if (position80)
            {
                buildPositionScript.position80Recruit = false;
            }
            if (position81)
            {
                buildPositionScript.position81Recruit = false;
            }
            if (position82)
            {
                buildPositionScript.position82Recruit = false;
            }
            if (position83)
            {
                buildPositionScript.position83Recruit = false;
            }
            if (position84)
            {
                buildPositionScript.position84Recruit = false;
            }
            if (position85)
            {
                buildPositionScript.position85Recruit = false;
            }
            if (position86)
            {
                buildPositionScript.position86Recruit = false;
            }
            if (position87)
            {
                buildPositionScript.position87Recruit = false;
            }
            if (position88)
            {
                buildPositionScript.position88Recruit = false;
            }
            if (position89)
            {
                buildPositionScript.position89Recruit = false;
            }
            if (position90)
            {
                buildPositionScript.position90Recruit = false;
            }
            if (position91)
            {
                buildPositionScript.position91Recruit = false;
            }
            if (position92)
            {
                buildPositionScript.position92Recruit = false;
            }
            if (position93)
            {
                buildPositionScript.position93Recruit = false;
            }
            if (position94)
            {
                buildPositionScript.position94Recruit = false;
            }
            if (position95)
            {
                buildPositionScript.position95Recruit = false;
            }
            if (position96)
            {
                buildPositionScript.position96Recruit = false;
            }
            if (position97)
            {
                buildPositionScript.position97Recruit = false;
            }
            if (position98)
            {
                buildPositionScript.position98Recruit = false;
            }
            if (position99)
            {
                buildPositionScript.position99Recruit = false;
            }
            if (position100)
            {
                buildPositionScript.position100Recruit = false;
            }
            if (position101)
            {
                buildPositionScript.position101Recruit = false;
            }
            if (position102)
            {
                buildPositionScript.position102Recruit = false;
            }
            if (position103)
            {
                buildPositionScript.position103Recruit = false;
            }
            if (position104)
            {
                buildPositionScript.position104Recruit = false;
            }
            if (position105)
            {
                buildPositionScript.position105Recruit = false;
            }
            if (position106)
            {
                buildPositionScript.position106Recruit = false;
            }
            if (position107)
            {
                buildPositionScript.position107Recruit = false;
            }
            if (position108)
            {
                buildPositionScript.position108Recruit = false;
            }
            if (position109)
            {
                buildPositionScript.position109Recruit = false;
            }
            if (position110)
            {
                buildPositionScript.position110Recruit = false;
            }
            if (position111)
            {
                buildPositionScript.position111Recruit = false;
            }
            if (position112)
            {
                buildPositionScript.position112Recruit = false;
            }
            if (position113)
            {
                buildPositionScript.position113Recruit = false;
            }
            if (position114)
            {
                buildPositionScript.position114Recruit = false;
            }
            if (position115)
            {
                buildPositionScript.position115Recruit = false;
            }
            if (position116)
            {
                buildPositionScript.position116Recruit = false;
            }
            if (position117)
            {
                buildPositionScript.position117Recruit = false;
            }
            if (position118)
            {
                buildPositionScript.position118Recruit = false;
            }
            if (position119)
            {
                buildPositionScript.position119Recruit = false;
            }
            if (position120)
            {
                buildPositionScript.position120Recruit = false;
            }
            if (position121)
            {
                buildPositionScript.position121Recruit = false;
            }
            if (position122)
            {
                buildPositionScript.position122Recruit = false;
            }
            if (position123)
            {
                buildPositionScript.position123Recruit = false;
            }
            if (position124)
            {
                buildPositionScript.position124Recruit = false;
            }
            if (position125)
            {
                buildPositionScript.position125Recruit = false;
            }
            if (position126)
            {
                buildPositionScript.position126Recruit = false;
            }
        }
    }
}
