using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : DamageableObject
{
    private Rigidbody playerRb;
    private Vector3 moveInput;
    private float rotationRate = 15f;
    private float horizontalInput;
    private float verticalInput;
    private float manaRegenRate = 1;
    public float currentMana;
    public float maxMana;
    private int level = 1;
    private int spellUINumber = 0;
    public int castableSpells = 1;
    public int touchingBuilding = 0;
    private int potentialXP = 0;
    public int currentXP;
    private float basicAttackDamage = 15;
    private bool attackCooldownActive = false;
    private bool spellCasted = false;
    public bool attackDurationActive = false;
    private bool bulwarkRefresh = false;
    private bool bulwarkActive = false;
    private bool manaTickActive = false;
    private bool died = false;
    public GameObject GameManager;
    private GameManager gameManagerScript;
    public DamageableObject closestTargetScript;
    public GameObject mainCamera;
    public GameObject weapon;
    public GameObject head;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject torso;
    public GameObject iceWaveHitbox;
    public GameObject fireball;
    public GameObject imp;
    private GameObject closestTarget;
    public TextMeshProUGUI spell1Name;
    public TextMeshProUGUI spell2Name;
    public TextMeshProUGUI spell3Name;
    public TextMeshProUGUI spell4Name;
    public TextMeshProUGUI manaDisplay;
    public TextMeshProUGUI levelDisplay;
    public TextMeshProUGUI xPDisplay;
    public TextMeshProUGUI roundDisplay;
    public List<GameObject> spellList;
    private Renderer leftLegRenderer;
    private Renderer leftArmRenderer;
    private Renderer rightLegRenderer;
    private Renderer rightArmRenderer;
    private Renderer headRenderer;
    private Renderer torsoRenderer;
    private Color playerColor;
    private Color bulwarkColor;
    private Vector3 startingPosition = new Vector3(0, 3f, 5);
    public ParticleSystem iceWaveParticle;
    public Sprite fireBallSprite;
    public Sprite slamSprite;
    public Sprite iceWaveSprite;
    public Sprite blinkSprite;
    public Sprite bulwarkSprite;
    public Sprite summonImpSprite;
    public GameObject spell1Image;
    public GameObject spell2Image;
    public GameObject spell3Image;
    public GameObject spell4Image;
    private GameObject summonedCreature;
    private GameObject currentHealthAndDamageCanvas;
    private HealthAndDamageCanvas summonedHealthAndDamageCanvasScript;
    private Building currentSummonedCreatureScript;
    void Start()
    {
        spellList = new List<GameObject>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameManagerScript = GameManager.GetComponent<GameManager>();
        attackHitboxScript = attackHitbox.GetComponent<AttackHitbox>();
        healthAndDamageCanvasScript = healthAndDamageCanvas.GetComponent<HealthAndDamageCanvas>();
        healthAndDamageCanvasScript.offset = new Vector3(0, 2, 0);
        bulwarkColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
        playerColor = new Color(.82f, .79f, .19f, 1f);
        leftLegRenderer = leftLeg.GetComponent<Renderer>();
        rightLegRenderer = rightLeg.GetComponent<Renderer>();
        leftArmRenderer = leftArm.GetComponent<Renderer>();
        rightArmRenderer = rightArm.GetComponent<Renderer>();
        headRenderer = head.GetComponent<Renderer>();
        torsoRenderer = torso.GetComponent<Renderer>();
        leftLegRenderer.material.SetColor("_Color", playerColor);
        rightLegRenderer.material.SetColor("_Color", playerColor);
        leftArmRenderer.material.SetColor("_Color", playerColor);
        rightArmRenderer.material.SetColor("_Color", playerColor);
        headRenderer.material.SetColor("_Color", playerColor);
        torsoRenderer.material.SetColor("_Color", playerColor);
        attackHitboxScript.validTargetTags.Add("Enemy");
        currentHP = 10;
        maxHP = 10;
        currentMana = 10;
        maxMana = 10;
        speed = 15f;
        attackCooldownFloat = 3.1f;
        transform.position = startingPosition;
        levelDisplay.text = "Level: " + level;
        xPDisplay.text = "XP: " + currentXP + "/" + (5 + 5 * level);
        spell1Image.SetActive(false);
        spell2Image.SetActive(false);
        spell3Image.SetActive(false);
        spell4Image.SetActive(false);
        healthAndDamageCanvasScript.health = (int)maxHP;
    }

    void Update()
    {
        if(currentHP > 0)
        {
            if (gameManagerScript.roundBegun)
            {
                if (!attackCooldownActive)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Attack();
                    }
                }
                if (Input.GetKeyDown("1") && spellList.Count > 0)
                {
                    CastSpell(spellList[0]);
                    if (spellList.Count > castableSpells && spellCasted)
                    {
                        spellList.Add(spellList[0]);
                        spellList[0] = spellList[castableSpells];
                        spell1Image.GetComponent<Image>().sprite = FindImage(spellList[0]);
                        spell1Name.text = spellList[castableSpells].name;
                        spellList.RemoveAt(castableSpells);
                    }
                    spellCasted = false;
                }
                if (Input.GetKeyDown("2") && spellList.Count > 1 && castableSpells > 1)
                {
                    CastSpell(spellList[1]);
                    if (spellList.Count > castableSpells && spellCasted)
                    {
                        spellList.Add(spellList[1]);
                        spellList[1] = spellList[castableSpells];
                        spell2Image.GetComponent<Image>().sprite = FindImage(spellList[1]);
                        spell2Name.text = spellList[castableSpells].name;
                        spellList.RemoveAt(castableSpells);
                    }
                    spellCasted = false;
                }
                if (Input.GetKeyDown("3") && spellList.Count > 2 && castableSpells > 2)
                {
                    CastSpell(spellList[2]);
                    if (spellList.Count > castableSpells && spellCasted)
                    {
                        spellList.Add(spellList[2]);
                        spellList[2] = spellList[castableSpells];
                        spell3Image.GetComponent<Image>().sprite = FindImage(spellList[2]);
                        spell3Name.text = spellList[castableSpells].name;
                        spellList.RemoveAt(castableSpells);
                    }
                    spellCasted = false;
                }
                if (Input.GetKeyDown("4") && spellList.Count > 3 && castableSpells > 3)
                {
                    CastSpell(spellList[3]);
                    if (spellList.Count > castableSpells && spellCasted)
                    {
                        spellList.Add(spellList[3]);
                        spellList[3] = spellList[castableSpells];
                        spell4Image.GetComponent<Image>().sprite = FindImage(spellList[3]);
                        spell4Name.text = spellList[castableSpells].name;
                        spellList.RemoveAt(castableSpells);
                    }
                    spellCasted = false;
                }
                if (currentMana < maxMana && !manaTickActive)
                {
                    StartCoroutine(ManaTick());
                    manaTickActive = true;
                }
            }
        }
    }
    void FixedUpdate()
    {
        RegisterMovement();
    }
    //registers wasd and moves character correspondingly
    private void RegisterMovement()
    {
        if (!gameManagerScript.roundBegun)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerRb.position += moveInput * speed / 100;
            if (moveInput.sqrMagnitude > 0)
            {
                Quaternion rotation = Quaternion.LookRotation(moveInput, Vector3.up);
                playerRb.rotation = Quaternion.Lerp(playerRb.rotation, rotation, Time.fixedDeltaTime * rotationRate);
            }
        }
        if (gameManagerScript.roundBegun && currentHP > 0)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            if (touchingBuilding == 0)
            {
                playerRb.velocity = new Vector3(0, 0, 0);
                transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
                transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
            }
            if (touchingBuilding > 0)
            {
                playerRb.AddForce(transform.forward * speed * 10 * verticalInput);
            }
        }
        if(currentHP <= 0 && !died)
        {
            died = true;
            transform.Translate(1000, 1000, 1000);
            roundDisplay.text = "Knocked Out ";
            roundDisplay.color = new Color(205, 0, 0, 255);
            StartCoroutine(RoundTextReset());
        }
    }
    private IEnumerator RoundTextReset()
    {
        yield return new WaitForSeconds(3);
        roundDisplay.color = new Color(0, 0, 0, 0);
        roundDisplay.text = "";
    }
    private void Attack()
    {
        attackCooldownActive = true;
        attackDurationActive = true;
        StartCoroutine(AttackCooldown());
        StartCoroutine(AttackDuration());
    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownFloat);
        attackCooldownActive = false;
    }
    IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(.01f);
        closestTarget = gameObject.GetClosest(attackHitboxScript.targets);
        if (closestTarget != null)
        {
            BasicAttack();
        }
        attackDurationActive = false;
    } 
    void BasicAttack()
    {
        closestTargetScript = closestTarget.GetScript() as DamageableObject;
        DealDamage(basicAttackDamage);
    }
    public void CastSpell(GameObject spell)
    {
        if (spell.name == "Fire Ball" && currentMana >= 3)
        {
            CastFireball();
            spellCasted = true;
        }
        if (spell.name == "Slam" && currentMana >= 3)
        {
            CastSlam();
            spellCasted = true;
        }
        if (spell.name == "Ice Wave" && currentMana >= 5)
        {
            CastIceWave();
            spellCasted = true;
        }
        if (spell.name == "Summon Imp" && currentMana >= 7)
        {
            CastSummonImp();
            spellCasted = true;
        }
        if (spell.name == "Bulwark" && currentMana >= 4)
        {
            CastBulwark();
            spellCasted = true;
        }
        if (spell.name == "Blink" && currentMana >= 2)
        {
            CastBlink();
            spellCasted = true;
        }
    }
    public Sprite FindImage(GameObject spell)
    {
        if (spell.name == "Fire Ball")
        {
            return fireBallSprite;
        }
        if (spell.name == "Slam")
        {
            return slamSprite;
        }
        if (spell.name == "Ice Wave")
        {
            return iceWaveSprite;
        }
        if (spell.name == "Summon Imp")
        {
            return summonImpSprite;
        }
        if (spell.name == "Bulwark")
        {
            return bulwarkSprite;
        }
        if (spell.name == "Blink")
        {
            return blinkSprite;
        }
        return null;
    }
    public void CastFireball()
    {
        GameObject currentFireball = Instantiate(fireball, new Vector3(transform.position.x, 2f, transform.position.z), transform.rotation);
        currentFireball.transform.Translate(Vector3.forward * 1);
    }
    public void CastSlam()
    {
        basicAttackDamage *= 1.5f;
        float reduction = basicAttackDamage / 3;
        Attack();
        basicAttackDamage -= reduction;
        //have this do BasicAttack but with 50% more damage and a knockback, see how enemies move toward buildings for knockback code. 
    }
    public void CastIceWave()
    {
        currentMana -= 5;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        iceWaveHitbox.SetActive(true);
        iceWaveParticle.gameObject.SetActive(true);
        //iceWaveParticle.Play();
        StartCoroutine(IceWaveHitDuration());
        StartCoroutine(IceWaveParticleDuration());
    }
    public void CastSummonImp()
    {
        currentMana -= 7;
        summonedCreature = Instantiate(imp, gameObject.transform.position, gameObject.transform.rotation);
        currentHealthAndDamageCanvas = Instantiate(healthAndDamageCanvas, new Vector3(healthAndDamageCanvas.transform.position.x, healthAndDamageCanvas.transform.position.y, healthAndDamageCanvas.transform.position.z), Quaternion.identity);
        summonedHealthAndDamageCanvasScript = currentHealthAndDamageCanvas.GetComponent<HealthAndDamageCanvas>();
        summonedHealthAndDamageCanvasScript.host = summonedCreature;
        summonedHealthAndDamageCanvasScript.offset = new Vector3(0, 4, 0);
        currentSummonedCreatureScript = summonedCreature.GetScript() as Building;
        currentSummonedCreatureScript.healthAndDamageCanvas = currentHealthAndDamageCanvas;
        currentSummonedCreatureScript.healthAndDamageCanvasScript = summonedHealthAndDamageCanvasScript;
        currentSummonedCreatureScript.castle = gameManagerScript.castle;
        currentSummonedCreatureScript.healthAndDamageCanvasScript.health = (int)currentSummonedCreatureScript.maxHP;
    }
    public void CastBulwark()
    {
        currentMana -= 4;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        if (bulwarkActive == true)
        {
            bulwarkRefresh = true;
        }
        bulwarkActive = true;
        leftLegRenderer.material.SetColor("_Color", bulwarkColor);
        rightLegRenderer.material.SetColor("_Color", bulwarkColor);
        leftArmRenderer.material.SetColor("_Color", bulwarkColor);
        rightArmRenderer.material.SetColor("_Color", bulwarkColor);
        headRenderer.material.SetColor("_Color", bulwarkColor);
        torsoRenderer.material.SetColor("_Color", bulwarkColor);
        StartCoroutine(BulwarkTimer());
    }
    public void CastBlink()
    {
        currentMana -= 2;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        transform.Translate(Vector3.forward * 15);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building" || other.tag == "Wall")
        {
            touchingBuilding += 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building" || other.tag == "Wall")
        {
            touchingBuilding -= 1;
            playerRb.velocity = new Vector3(0, 0, 0);
        }
    }
    IEnumerator BulwarkTimer()
    {
        yield return new WaitForSeconds(5);
        if (!bulwarkRefresh)
        {
            leftLegRenderer.material.SetColor("_Color", playerColor);
            rightLegRenderer.material.SetColor("_Color", playerColor);
            leftArmRenderer.material.SetColor("_Color", playerColor);
            rightArmRenderer.material.SetColor("_Color", playerColor);
            headRenderer.material.SetColor("_Color", playerColor);
            torsoRenderer.material.SetColor("_Color", playerColor);
            bulwarkActive = false;
        }
        bulwarkRefresh = false;
    }
    public void RoundBegin()
    {
        spellUINumber = 0;
        if (gameManagerScript.gatheredSpells.Count != 0)
        {
            if (level < 3)
            {
                castableSpells = 1;
            }
            else if (level < 6)
            {
                castableSpells = 2;
            }
            else if (level < 10)
            {
                castableSpells = 3;
            }
            else
            {
                castableSpells = 4;
            }
        }
        foreach (GameObject spell in gameManagerScript.activeSpells)
        {
            if (!spellList.Contains(spell) && spellList.Count < gameManagerScript.maxActiveSpells)
            {
                spellList.Add(spell);
            }
            if (spellUINumber == 0 && castableSpells > 0)
            {
                spell1Name.text = spell.name;
                spell1Image.GetComponent<Image>().sprite = FindImage(spell); ;
            }
            if (spellUINumber == 1 && castableSpells > 1)
            {
                spell2Name.text = spell.name;
                spell2Image.GetComponent<Image>().sprite = FindImage(spell);
            }
            if (spellUINumber == 2 && castableSpells > 2)
            {
                spell3Name.text = spell.name;
                spell3Image.GetComponent<Image>().sprite = FindImage(spell);
            }
            if (spellUINumber == 3 && castableSpells > 3)
            {
                spell4Name.text = spell.name;
                spell4Image.GetComponent<Image>().sprite = FindImage(spell);
            }
            spellUINumber++;
        }
        if (spellList.Count > 0)
        {
            spell1Image.SetActive(true);
        }
        if (spellList.Count > 1 && castableSpells > 1)
        {
            spell2Image.SetActive(true);
        }
        if (spellList.Count > 2 && castableSpells > 2)
        {
            spell3Image.SetActive(true);
        }
        if (spellList.Count > 3 && castableSpells > 3)
        {
            spell4Image.SetActive(true);
        }
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        healthDisplay.text = "Health: " + currentHP + "/" + maxHP;
    }
    public void RoundEnd()
    {
        died = false;
        transform.position = startingPosition;
        FullHeal();
        //healthAndDamageCanvasScript.GainHealth(maxHP - currentHP);
        //currentHP = maxHP;
        if (gameManagerScript.gatheredSpells.Count != 0)
        {
            if (level < 3)
            {
                castableSpells = 1;
            }
            else if (level < 6) 
            {
                castableSpells = 2;
            }
            else if (level < 10)
            {
                castableSpells = 3;
            }
            else
            {
                castableSpells = 4;
            }
        }
        spell1Name.text = "";
        spell2Name.text = "";
        spell3Name.text = "";
        spell4Name.text = "";
        manaDisplay.text = "";
        healthDisplay.text = "";
        spell1Image.SetActive(false);
        spell2Image.SetActive(false);
        spell3Image.SetActive(false);
        spell4Image.SetActive(false);
    }
    private void DealDamage(float damage)
    {
        potentialXP = closestTargetScript.TakeDamage(damage);
        if (potentialXP > 0)
        {
            GainXP(potentialXP);
        }
    }
    public void GainXP(int xp)
    {
        currentXP += xp;
        xPDisplay.text = "XP: " + currentXP + "/" + (5 + 5 * level);
        if (currentXP >= 5 + 5 * level)
        {
            currentXP -= 5 + 5 * level;
            xPDisplay.text = "XP: " + currentXP + "/" + (5 + 5 * level);
            level++;
            maxHP += 2;
            healthAndDamageCanvasScript.GainHealth(2);
            manaRegenRate += .1f;
            if (gameManagerScript.maxActiveSpells < 8)
            {
                gameManagerScript.maxActiveSpells++;
            }
            levelDisplay.text = "Level:" + level;
        }
    }
    IEnumerator ManaTick()
    {
        yield return new WaitForSeconds(1/manaRegenRate);
        currentMana++;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        if(currentMana < maxMana)
        {
            StartCoroutine(ManaTick());
        }
        else
        {
            manaTickActive = false;
        }
    }
    IEnumerator IceWaveHitDuration()
    {
        yield return new WaitForSeconds(.05f);
        iceWaveHitbox.SetActive(false);
    }
    IEnumerator IceWaveParticleDuration()
    {
        yield return new WaitForSeconds(2f);
        iceWaveParticle.gameObject.SetActive(false);
    }
}
