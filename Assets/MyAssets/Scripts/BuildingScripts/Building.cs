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
    public float attackWindup;
    public float rangedWeaponY;
    public float rangedWeaponX;
    public float spikeDamageInterval;
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
    public bool isRanged;
    protected bool lootPositionChecked;
    private bool canvasTimer;
    private bool checkedSpawn;
    private bool projectile1Fired;
    protected bool attackCooldownActive;
    protected bool attackDurationActive;
    protected bool cleavingAttackCooldownActive;
    protected bool cleavingAttackDurationActive;
    protected bool attackReadyRanged;
    public bool following;
    public bool verticalPositiveCollision;
    public bool verticalNegativeCollision;
    public bool horizontalPositiveCollision;
    public bool horizontalNegativeCollision;
    public string trueName;
    public Vector3 startPosition;
    private Vector3 lootPosition;
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
    //public GameObject buildPositionObject;
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
    //public BuildPosition buildPositionScript;
    //protected Projectile projectileScript;
    protected Projectile projectileScript1;
    protected Projectile projectileScript2;
    public Player playerScript;
    public GameObject model;
    protected Animator characterAnimation;

    //this is for Castle which runs buildingScript directly
    void Update()
    {
        StatusCheck();
    }
    //Handles all communal code needed for buildings, call method in update. For melle, set rangedAttackRange to -1 or any value at least .5 below their attackRange.
    protected void BuildingUpdate()
    {
        if (!died)
        {
            //Ranged Attack
            if (attackReadyRanged && target != null && distanceToTarget <= rangedAttackRange + .4f && checkedSpawn && isRanged && !following)
            {
                FireProjectile();
            }
            StatusCheck();
            //UICheck();
            //Checks for the end of the round
            if (gameManagerScript.roundBegun && endRoundCheck)
            {
                endRoundCheck = false;
            }
        }
    }
    //Activates and deactivates ui elements so that nearby buttons are not blocked.
    private void UICheck()//i can probably remove this
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
        if (transform.Find("AttackHitbox") != null)
        {
            attackHitboxScript = attackHitbox.GetComponent<AttackHitbox>();
        }
        if (nameTextObject != null)
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
        //buildPositionObject = GameObject.Find("BuildPosition");
        //buildPositionScript = buildPositionObject.GetComponent<BuildPosition>();
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
            if (rangedAttackDamage != 0)
            {
                projectileScript2.damage = rangedAttackDamage;
            }
            projectileScript2.building = gameObject;
        }
        if (tag == "Enemy" || tag == "Ally")
        {
            characterAnimation = model.GetComponent<Animator>();
        }
    }
    //Creates an object assigned as the projectile and initializes it. Projectile code will determine things like speed and projectile damage
    protected void FireProjectile()
    {
        spawnPoint = new Vector3(transform.position.x + rangedWeaponX, transform.position.y + rangedWeaponY, transform.position.z);
        if (tag != "Building")
        {
            if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                StartCoroutine(AttackDelay());
                characterAnimation.Play("Attack");
            }
        }
        else
        {
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
        }
        
        attackReadyRanged = false;
        StartCoroutine(RangedAttackCooldown());
    }
    protected IEnumerator AttackDelay()
    {
        attackCooldownActive = true;
        yield return new WaitForSeconds(attackWindup);
        if (isRanged)
        {
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
        }
        else
        {
            MelleAttack();
        }
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
                if(tag == "Building")
                {
                    StartCoroutine(DestroyDelayAfter());
                }
                else
                {
                    StartCoroutine(DestroyDelay());
                }
            }
            if (name == "Castle")
            {
                SceneManager.LoadScene(2);
            }
        }
        //checks for round end
        if (!gameManagerScript.roundBegun && !endRoundCheck && !gameManagerScript.constructing && (tag == "Ally"))
        {
            endRoundCheck = true;
            FullHeal();
            transform.position = startPosition;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            following = false;
            target = null;
        }
    }
    //Must be moved before destruction to trigger onTriggerExit of other rangeFinders
    protected IEnumerator DestroyDelay()
    {
        if (tag == "Enemy")
        {
            gameManagerScript.enemyCount--;
            SpawnEnemyDrop();
        }
        //characterAnimation.Rebind();
        //characterAnimation.Update(0f);
        died = true;
        characterAnimation.Play("Die");
        if(trueName == "Footman")
        {
            yield return new WaitForSeconds(1.9f);
        }
        else
        {
            yield return new WaitForSeconds(characterAnimation.GetCurrentAnimatorStateInfo(0).length);
        }
        transform.Translate(100000, 100000, 100000);
        StartCoroutine(DestroyDelayAfter());
    }
    protected IEnumerator DestroyDelayAfter()
    {
        yield return new WaitForSeconds(.1f);
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
            if (target != null)
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
        if(spikeTargetScript.gameObject != null)
        {
            if (targets.Contains(spikeTargetScript.gameObject))
            {
                spikeTargetScript.TakeDamage(attackDamage);
                TakeDamage(spikeSelfDamage);
                StartCoroutine(SpikeDamageReset(spikeTargetScript));
            }
        }
    }
    private IEnumerator SpikeDamageReset(DamageableObject spikeTargetScript)
    {
        yield return new WaitForSeconds(spikeDamageInterval);
        if (spikeTargetScript.gameObject != null)
        {
            SpikeDamageLoop(spikeTargetScript);
        }
    }
    //removes (clone) from name for ui purposes
    private string FindTrueName()
    {
        int charIndex = 0;
        for (int i = 0; i < name.Length; i++)
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
        if (tag == "Building" && currentHP < maxHP && gameManagerScript.repairing)
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
    /*void OnColliderEnter(Collider other)
    {
        float zDiff = Mathf.Abs(other.transform.position.z - transform.position.z);
        float xDiff = Mathf.Abs(other.transform.position.x - transform.position.x);
        if (other.tag == "Building" || other.tag == "Ally")
        {
            Debug.Log("test");
            if(zDiff > xDiff)
            {
                if(other.transform.position.z - transform.position.z > 0)
                {
                    horizontalPositiveCollision = true;
                }
                else
                {
                    horizontalNegativeCollision = true;
                }
                
            }
            else
            {
                if (other.transform.position.x - transform.position.x > 0)
                {
                    verticalPositiveCollision = true;
                }
                else
                {
                    verticalNegativeCollision = true;
                }
            }
        }
    }
    void OnColliderExit(Collider other)
    {
        if (other.tag == "Building" || other.tag == "Ally")
        {
            verticalPositiveCollision = false;
            verticalNegativeCollision = false;
            horizontalPositiveCollision = false;
            horizontalNegativeCollision = false;
        }
    }*/
}