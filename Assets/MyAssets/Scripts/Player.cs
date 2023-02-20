using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : DamageableObject
{
    private Rigidbody playerRb;
    private float rotationRate = 15f;
    private float horizontalInput;
    private float verticalInput;
    private float manaRegenRate = 1;
    public float currentMana;
    public float maxMana;
    public float basicAttackDamage = 3;
    private float attackWindup = .87f;
    private int level = 1;
    private int maxEnergy = 20;
    private int currentEnergy = 20;
    private int spellUINumber = 0;
    public int castableSpells = 1;
    public int touchingBuilding = 0;
    private int potentialXP = 0;
    public int currentXP;
    private int fireBallCDDuration;
    private int slamCDDuration;
    private int iceWaveCDDuration;
    private int blinkCDDuration;
    private int bulwarkCDDuration;
    private int summonImpCDDuration;
    private int attackDamageLevelTracker;
    private bool attackCooldownActive;
    private bool spellCasted;
    private bool energyTickCooldownBool;
    private bool attackDurationActive;
    private bool energyDowntickCooldown;
    private bool bulwarkRefresh;
    private bool manaTickActive;
    private bool casting;
    private bool dying;
    public bool died;
    private bool fireBallCD;
    private bool summonImpCD;
    private bool slamCD;
    private bool iceWaveCD;
    private bool blinkCD;
    private bool bulwarkCD;
    private bool maxSpellsIncreaseQueue;
    public GameObject mace;
    public GameObject GameManager;
    public GameObject mainCamera;
    //public GameObject weapon;
    public GameObject iceWaveHitbox;
    public GameObject fireball;
    public GameObject imp;
    private GameObject closestTarget;
    public GameObject spell1Image;
    public GameObject spell2Image;
    public GameObject spell3Image;
    public GameObject spell4Image;
    private GameObject summonedCreature;
    public GameObject model;
    public TextMeshProUGUI spell1Name;
    public TextMeshProUGUI spell2Name;
    public TextMeshProUGUI spell3Name;
    public TextMeshProUGUI spell4Name;
    public TextMeshProUGUI manaDisplay;
    public TextMeshProUGUI energyDisplay;
    public TextMeshProUGUI levelDisplay;
    public TextMeshProUGUI xPDisplay;
    public TextMeshProUGUI roundDisplay;
    public List<GameObject> spellList;
    private Color playerColor;
    private Color bulwarkColor;
    private Vector3 moveInput;
    private Vector3 startingPosition = new Vector3(0.12f, 3.1f, -15);
    public ParticleSystem iceWaveParticle;
    public Sprite fireBallSprite;
    public Sprite slamSprite;
    public Sprite iceWaveSprite;
    public Sprite blinkSprite;
    public Sprite bulwarkSprite;
    public Sprite summonImpSprite;
    public Sprite fireBallCDSprite;
    public Sprite slamCDSprite;
    public Sprite iceWaveCDSprite;
    public Sprite blinkCDSprite;
    public Sprite bulwarkCDSprite;
    public Sprite summonImpCDSprite;
    private Animator characterAnimation;
    private List<TextMeshProUGUI> spellNameList;
    private List<GameObject> spellImageList;
    public GameManager gameManagerScript;
    public DamageableObject closestTargetScript;
    private Building currentSummonedCreatureScript;
    public MovementSM playerState;

    void Start()
    {
        currentHP = 10;
        maxHP = 10;
        currentMana = 10;
        maxMana = 10;
        speed = 87f;
        attackCooldownFloat = 1.8f;
        bulwarkDefense = 1;
        spellList = new List<GameObject>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameManagerScript = GameManager.GetComponent<GameManager>();
        attackHitboxScript = attackHitbox.GetComponent<AttackHitbox>();
        healthAndDamageCanvasScript = healthAndDamageCanvas.GetComponent<HealthAndDamageCanvas>();
        bulwarkColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);
        playerColor = new Color(.82f, .79f, .19f, 1f);
        transform.position = startingPosition;
        levelDisplay.text = "Level: " + level;
        xPDisplay.text = "XP: " + currentXP + "/" + (5 + 5 * level);
        healthDisplay.text = "Health: " + currentHP + "/" + maxHP;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        energyDisplay.text = "Energy " + currentEnergy + "/" + maxEnergy;
        spell1Image.SetActive(false);
        spell2Image.SetActive(false);
        spell3Image.SetActive(false);
        spell4Image.SetActive(false);
        spellNameList = new List<TextMeshProUGUI>();
        spellImageList = new List<GameObject>();
        spellNameList.Add(spell1Name);
        spellNameList.Add(spell2Name);
        spellNameList.Add(spell3Name);
        spellNameList.Add(spell4Name);
        spellImageList.Add(spell1Image);
        spellImageList.Add(spell2Image);
        spellImageList.Add(spell3Image);
        spellImageList.Add(spell4Image);
        healthAndDamageCanvasScript.maxHP = (int)maxHP;
        characterAnimation = model.GetComponent<Animator>();
        playerState.characterAnimation = characterAnimation; 
        characterAnimation.Play("Walk");
    }
    void Update()
    {
        if(currentHP > 0)
        {
            if (gameManagerScript.roundBegun)
            {
                if (!casting)
                {
                    RegisterAttacks();
                }
                if (!attackDurationActive)
                {
                    RegisterSpellcast();
                }
                ReplenishManaAndEnergy();
            }
            playerRb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            characterAnimation.Play("Die");
            dying = true;
            StartCoroutine(DeathAnimation());
        }
    }
    void FixedUpdate()
    {
        if(!attackDurationActive && !casting && !dying)
        {
            RegisterMovement();
        }
    }
    //registers wasd (or arrow keys) and moves character correspondingly
    private void RegisterMovement()
    {
        if (currentHP > 0)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            moveInput = new Vector3(horizontalInput, 0, verticalInput);
            if (verticalInput > .9 && horizontalInput > .9)
            {
                verticalInput = .5f;
                horizontalInput = .5f;
            }
            if (verticalInput < -.9 && horizontalInput < -.9)
            {
                verticalInput = -.5f;
                horizontalInput = -.5f;
            }
            if (verticalInput > .9 && horizontalInput < -.9)
            {
                verticalInput = .5f;
                horizontalInput = -.5f;
            }
            if (verticalInput < -.9 && horizontalInput > .9)
            {
                verticalInput = -.5f;
                horizontalInput = .5f;
            }
            if (!gameManagerScript.roundBegun)
            {
                if (Mathf.Abs(horizontalInput) < Mathf.Epsilon && Mathf.Abs(verticalInput) < Mathf.Epsilon)
                {
                    characterAnimation.Play("Idle");
                }
                else
                {
                    if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Walk") && !characterAnimation.IsInTransition(0))
                    {
                        characterAnimation.Play("Walk");
                    }
                    playerRb.position += moveInput * speed / 650;
                }
                if (moveInput.sqrMagnitude > 0)
                {
                    Quaternion rotation = Quaternion.LookRotation(moveInput, Vector3.up);
                    model.transform.rotation = Quaternion.Lerp(model.transform.rotation, rotation, Time.fixedDeltaTime * rotationRate);
                    playerRb.velocity = new Vector3(0, 0, 0);
                }
            }
            else if (Input.GetKey("left shift") && currentEnergy > 0 && verticalInput > 0)
            {
                playerRb.AddForce(transform.forward * speed * 7 * verticalInput);
                playerRb.AddForce(transform.right * speed * 7 * horizontalInput);
                playerRb.velocity = new Vector3(0, 0, 0);
                if (!energyDowntickCooldown && (verticalInput > .05f || horizontalInput > .05f))
                {
                    currentEnergy--;
                    energyDisplay.text = "Energy " + currentEnergy + "/" + maxEnergy;
                    energyDowntickCooldown = true;
                    if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Run") && !characterAnimation.IsInTransition(0))
                    {
                        characterAnimation.Play("Run");
                    }
                    StartCoroutine(EnergyDowntickCooldown());
                }
                if (moveInput.sqrMagnitude > 0)
                {
                    Quaternion rotation = Quaternion.LookRotation(moveInput, Vector3.up);
                    model.transform.rotation = Quaternion.Lerp(playerRb.rotation, rotation, Time.fixedDeltaTime * rotationRate);
                }
            }
            else if (Mathf.Abs(horizontalInput) < Mathf.Epsilon && Mathf.Abs(verticalInput) < Mathf.Epsilon)
            {
                characterAnimation.Play("Idle");
            }
            else
            {
                playerRb.AddForce(transform.forward * speed * 4f * verticalInput);
                playerRb.AddForce(transform.right * speed * 4f * horizontalInput);
                playerRb.velocity = new Vector3(0, 0, 0);
                if (!characterAnimation.GetCurrentAnimatorStateInfo(0).IsName("Walk") && !characterAnimation.IsInTransition(0))
                {
                    characterAnimation.Play("Walk");
                }
                if (moveInput.sqrMagnitude > 0)
                {
                    Quaternion rotation = Quaternion.LookRotation(moveInput, Vector3.up) * playerRb.rotation;
                    model.transform.rotation = Quaternion.Lerp(model.transform.rotation, rotation, Time.fixedDeltaTime * rotationRate);
                }
            }
        } 
    }
    //register attack on left click
    private void RegisterAttacks()
    {
        if (!attackCooldownActive && currentEnergy > 10 && Input.GetMouseButtonDown(0) && attackHitboxScript.targets.Count != 0)
        {
            Attack();
            currentEnergy -= 10;
        }
    }
    //Register spellcast on 1-4 and cycles spells if needed
    private void RegisterSpellcast()
    {
        if (Input.GetKeyDown("1") && spellList.Count > 0)
        {
            StartCoroutine(CastSpell(spellList[0], 0));
            if (spellList.Count > castableSpells && spellCasted)
            {
                spellList.Add(spellList[0]);
                spellList[0] = spellList[castableSpells];
                spell1Image.GetComponent<Image>().sprite = FindImage(spellList[0]);
                spell1Name.text = spellList[castableSpells].name;
                spellList.RemoveAt(castableSpells);
            }
        }
        if (Input.GetKeyDown("2") && spellList.Count > 1 && castableSpells > 1)
        {
            StartCoroutine(CastSpell(spellList[1], 1));
            //characterAnimation.Play("Cast");
            if (spellList.Count > castableSpells && spellCasted)
            {
                spellList.Add(spellList[1]);
                spellList[1] = spellList[castableSpells];
                spell2Image.GetComponent<Image>().sprite = FindImage(spellList[1]);
                spell2Name.text = spellList[castableSpells].name;
                spellList.RemoveAt(castableSpells);
            }
        }
        if (Input.GetKeyDown("3") && spellList.Count > 2 && castableSpells > 2)
        {
            StartCoroutine(CastSpell(spellList[2], 2));
            //characterAnimation.Play("Cast");
            if (spellList.Count > castableSpells && spellCasted)
            {
                spellList.Add(spellList[2]);
                spellList[2] = spellList[castableSpells];
                spell3Image.GetComponent<Image>().sprite = FindImage(spellList[2]);
                spell3Name.text = spellList[castableSpells].name;
                spellList.RemoveAt(castableSpells);
            }
        }
        if (Input.GetKeyDown("4") && spellList.Count > 3 && castableSpells > 3)
        {
            StartCoroutine(CastSpell(spellList[3], 3));
            //characterAnimation.Play("Cast");
            if (spellList.Count > castableSpells && spellCasted)
            {
                spellList.Add(spellList[3]);
                spellList[3] = spellList[castableSpells];
                spell4Image.GetComponent<Image>().sprite = FindImage(spellList[3]);
                spell4Name.text = spellList[castableSpells].name;
                spellList.RemoveAt(castableSpells);
            }
        }
        if (spellCasted)
        {
            characterAnimation.Play("Cast");
            casting = true;
            spellCasted = false;
        }
    }
    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(2);
        if (!died)
        {
            dying = false;
            died = true;
            transform.position = new Vector3(1000, transform.position.y, 1000);
            roundDisplay.text = "Knocked Out";
            roundDisplay.color = new Color(205, 0, 0, 255);
            StartCoroutine(RoundTextReset());
            if (gameManagerScript.alliesRemaining == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    private void ReplenishManaAndEnergy()
    {
        if (currentMana < maxMana && !manaTickActive)
        {
            StartCoroutine(ManaTick());
            manaTickActive = true;
        }
        if (!energyTickCooldownBool && currentEnergy < maxEnergy)
        {
            StartCoroutine(EnergyTick());
            energyTickCooldownBool = true;
        }
    }
    private IEnumerator RoundTextReset()
    {
        yield return new WaitForSeconds(3);
        roundDisplay.color = new Color(0, 0, 0, 0);
        roundDisplay.text = "";
    }
    //starts necessary timers for attack
    private void Attack()
    {
        characterAnimation.Play("Slap");
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
        yield return new WaitForSeconds(attackWindup);
        BasicAttack();
        attackDurationActive = false;
    }
    //perform the basic attack
    void BasicAttack()
    {
        closestTarget = gameObject.GetClosest(attackHitboxScript.targets);
        if (closestTarget != null)
        {
            closestTargetScript = closestTarget.GetScript() as DamageableObject;
            DealDamage(basicAttackDamage);
        }
    }
    //parses the spells name into its own casting method, sets cooldown if not cycled, and displays cooldown on image and text 
    public IEnumerator CastSpell(GameObject spell, int keyHit)
    {
        if (spell.name == "Fire Ball" && currentMana >= 3)
        {
            if(spellList.Count > castableSpells)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                CastFireball();
            }
            else if (fireBallCD == false)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                fireBallCDDuration = 5;
                spellNameList[keyHit].text += " (" + fireBallCDDuration + ")";
                spellImageList[keyHit].GetComponent<Image>().sprite = fireBallCDSprite; 
                CastFireball();
                fireBallCD = true;
                StartCoroutine(FireBallCDTimer(keyHit));
            }
        }
        if (spell.name == "Slam" && currentMana >= 4)
        {
            if (spellList.Count > castableSpells)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                CastSlam();
            }
            else if (slamCD == false)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                slamCDDuration = 7;
                spellNameList[keyHit].text += " (" + slamCDDuration + ")";
                spellImageList[keyHit].GetComponent<Image>().sprite = slamCDSprite;
                CastSlam();
                slamCD = true;
                StartCoroutine(SlamCDTimer(keyHit));
            }
        }
        if (spell.name == "Ice Wave" && currentMana >= 5)
        {
            if (spellList.Count > castableSpells)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                CastIceWave();
            }
            else if (iceWaveCD == false)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                iceWaveCDDuration = 8;
                spellNameList[keyHit].text += " (" + iceWaveCDDuration + ")";
                spellImageList[keyHit].GetComponent<Image>().sprite = iceWaveCDSprite;
                CastIceWave();
                iceWaveCD = true;
                StartCoroutine(IceWaveCDTimer(keyHit));
            }
        }
        if (spell.name == "Summon Imp" && currentMana >= 7)
        {
            if (spellList.Count > castableSpells)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                CastSummonImp();
            }
            else if (summonImpCD == false)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                summonImpCDDuration = 10;
                spellNameList[keyHit].text += " (" + summonImpCDDuration + ")";
                spellImageList[keyHit].GetComponent<Image>().sprite = summonImpCDSprite;
                CastSummonImp();
                summonImpCD = true;
                StartCoroutine(SummonImpCDTimer(keyHit));
            }
        }
        if (spell.name == "Bulwark" && currentMana >= 4)
        {
            if (spellList.Count > castableSpells)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                CastBulwark();
            }
            else if (bulwarkCD == false)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                bulwarkCDDuration = 8;
                spellNameList[keyHit].text += " (" + bulwarkCDDuration + ")";
                spellImageList[keyHit].GetComponent<Image>().sprite = bulwarkCDSprite;
                CastBulwark();
                bulwarkCD = true;
                StartCoroutine(BulwarkCDTimer(keyHit));
            }
        }
        if (spell.name == "Blink" && currentMana >= 2)
        {
            if (spellList.Count > castableSpells)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                CastBlink();
            }
            else if (blinkCD == false)
            {
                spellCasted = true;
                yield return new WaitForSeconds(1.1f);
                blinkCDDuration = 3;
                spellNameList[keyHit].text += " (" + blinkCDDuration + ")";
                spellImageList[keyHit].GetComponent<Image>().sprite = blinkCDSprite;
                CastBlink();
                blinkCD = true;
                StartCoroutine(BlinkCDTimer(keyHit));
            }
        }
        StartCoroutine(FinishCastAnimation());
    }
    IEnumerator FinishCastAnimation()
    {
        yield return new WaitForSeconds(.6f);
        casting = false;
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
        currentMana -= 3;
        GameObject currentFireball = Instantiate(fireball, new Vector3(transform.position.x, 2f, transform.position.z), transform.rotation);
        currentFireball.transform.Translate(Vector3.forward * 1);
    }
    private IEnumerator FireBallCDTimer(int keyHit)
    {
        yield return new WaitForSeconds(1);
        fireBallCDDuration--;
        spellNameList[keyHit].text = "Fire Ball (" + fireBallCDDuration + ")";
        if (fireBallCDDuration > 0)
        {
            StartCoroutine(FireBallCDTimer(keyHit));
        }
        else
        {
            spellNameList[keyHit].text = "Fire Ball";
            spellImageList[keyHit].GetComponent<Image>().sprite = fireBallSprite;
            fireBallCD = false;
        }
    }
    public void CastSlam()
    {
        currentMana -= 4;
        basicAttackDamage *= 2f;
        float reduction = basicAttackDamage / 2f;
        BasicAttack();
        basicAttackDamage -= reduction;
    }
    private IEnumerator SlamCDTimer(int keyHit)
    {
        yield return new WaitForSeconds(1);
        slamCDDuration--;
        spellNameList[keyHit].text = "Slam (" + slamCDDuration + ")";
        if (slamCDDuration > 0)
        {
            StartCoroutine(SlamCDTimer(keyHit));
        }
        else
        {
            spellNameList[keyHit].text = "Slam";
            spellImageList[keyHit].GetComponent<Image>().sprite = slamSprite;
            slamCD = false;
        }
    }
    public void CastIceWave()
    {
        currentMana -= 5;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        iceWaveHitbox.SetActive(true);
        iceWaveParticle.gameObject.SetActive(true);
        StartCoroutine(IceWaveHitDuration());
        StartCoroutine(IceWaveParticleDuration());
    }
    private IEnumerator IceWaveCDTimer(int keyHit)
    {
        yield return new WaitForSeconds(1);
        iceWaveCDDuration--;
        spellNameList[keyHit].text = "Ice Wave (" + iceWaveCDDuration + ")";
        if (iceWaveCDDuration > 0)
        {
            StartCoroutine(IceWaveCDTimer(keyHit));
        }
        else
        {
            spellNameList[keyHit].text = "Ice Wave";
            spellImageList[keyHit].GetComponent<Image>().sprite = iceWaveSprite;
            iceWaveCD = false;
        }
    }
    public void CastSummonImp()
    {
        currentMana -= 7;
        summonedCreature = Instantiate(imp, gameObject.transform.position, gameObject.transform.rotation);
        summonedCreature.transform.Translate(Vector3.forward * 1);
        currentSummonedCreatureScript = summonedCreature.GetScript() as Building;
        currentSummonedCreatureScript.castle = gameManagerScript.castle;
        currentSummonedCreatureScript.mainCanvas = gameManagerScript.mainCanvas;
        currentSummonedCreatureScript.gameManagerScript = gameManagerScript.gameObject.GetComponent<GameManager>();
        currentSummonedCreatureScript.healthAndDamageCanvasScript.maxHP = (int)currentSummonedCreatureScript.maxHP;
    }
    private IEnumerator SummonImpCDTimer(int keyHit)
    {
        yield return new WaitForSeconds(1);
        summonImpCDDuration--;
        spellNameList[keyHit].text = "Summon Imp (" + summonImpCDDuration + ")";
        if (summonImpCDDuration > 0)
        {
            StartCoroutine(SummonImpCDTimer(keyHit));
        }
        else
        {
            spellNameList[keyHit].text = "Summon Imp";
            spellImageList[keyHit].GetComponent<Image>().sprite = summonImpSprite;
            summonImpCD = false;
        }
    }
    public void CastBulwark()
    {
        currentMana -= 5;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        if (bulwarkActive)
        {
            bulwarkRefresh = true;
        }
        bulwarkActive = true;
        StartCoroutine(BulwarkTimer());
    }
    private IEnumerator BulwarkCDTimer(int keyHit)
    {
        yield return new WaitForSeconds(1);
        bulwarkCDDuration--;
        spellNameList[keyHit].text = "Bulwark (" + bulwarkCDDuration + ")";
        if (bulwarkCDDuration > 0)
        {
            StartCoroutine(BulwarkCDTimer(keyHit));
        }
        else
        {
            spellNameList[keyHit].text = "Bulwark";
            spellImageList[keyHit].GetComponent<Image>().sprite = bulwarkSprite;
            bulwarkCD = false;
        }
    }
    public void CastBlink()
    {
        currentMana -= 2;
        manaDisplay.text = "Mana: " + currentMana + "/" + maxMana;
        transform.Translate(Vector3.forward * 15);
    }
    private IEnumerator BlinkCDTimer(int keyHit)
    {
        yield return new WaitForSeconds(1);
        blinkCDDuration--;
        spellNameList[keyHit].text = "Blink (" + blinkCDDuration + ")";
        if (blinkCDDuration > 0)
        {
            StartCoroutine(BlinkCDTimer(keyHit));
        }
        else
        {
            spellNameList[keyHit].text = "Blink";
            spellImageList[keyHit].GetComponent<Image>().sprite = blinkSprite;
            blinkCD = false;
        }
    }
    private void SpellIncreaseCheck()
    {
        int castable = castableSpells;
        int maxSpells = gameManagerScript.maxActiveSpells;
        if (level < 3)
        {
            castableSpells = 1;
            gameManagerScript.maxActiveSpells = 1;
        }
        else if (level < 6)
        {
            castableSpells = 2;
            gameManagerScript.maxActiveSpells = 4;
        }
        else if (level < 10)
        {
            castableSpells = 3;
            gameManagerScript.maxActiveSpells = 6;
        }
        else
        {
            castableSpells = 4;
            gameManagerScript.maxActiveSpells = 8;
        }
        if (gameManagerScript.maxActiveSpells > maxSpells)
        {
            gameManagerScript.itemDropText.text = "Maximum selectable spells increased to " + gameManagerScript.maxActiveSpells;
            StartCoroutine(SpellTextNoQueue());
            maxSpellsIncreaseQueue = true;
        }
        if (castableSpells > castable)
        {
            if (maxSpellsIncreaseQueue)
            {
                StartCoroutine(SpellTextQueue());
            }
            else
            {
                gameManagerScript.itemDropText.text = "Spell slots improved to " + castableSpells;
                StartCoroutine(SpellTextNoQueue());
            }
        }
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
            //leftLegRenderer.material.SetColor("_Color", playerColor);
            bulwarkActive = false;
        }
        bulwarkRefresh = false;
    }
    public void GainMace()
    {
        basicAttackDamage += 2;
        mace.SetActive(true);
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
                spell1Image.GetComponent<Image>().sprite = FindImage(spell); 
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
        manaDisplay.gameObject.SetActive(true);
        healthDisplay.gameObject.SetActive(true);
    }
    public void RoundEnd()
    {
        died = false;
        transform.position = startingPosition;
        FullHeal();
        spell1Name.text = "";
        spell2Name.text = "";
        spell3Name.text = "";
        spell4Name.text = "";
        manaDisplay.gameObject.SetActive(false);
        healthDisplay.gameObject.SetActive(false);
        spell1Image.SetActive(false);
        spell2Image.SetActive(false);
        spell3Image.SetActive(false);
        spell4Image.SetActive(false);
    }
    private IEnumerator SpellTextQueue()
    {
        yield return new WaitForSeconds(2);
        gameManagerScript.itemDropText.text = "New spell slot unlocked!";
        maxSpellsIncreaseQueue = false;
        StartCoroutine(SpellTextNoQueue());
    }
    private IEnumerator SpellTextNoQueue()
    {
        yield return new WaitForSeconds(2);
        gameManagerScript.itemDropText.text = "";
    }
    private void DealDamage(float damage)
    {
        potentialXP = closestTargetScript.TakeDamage(damage);
        if (potentialXP > 0)
        {
            GainXP(potentialXP);
        }
    }
    //handles leveling up as well as xp gain
    public void GainXP(int xp)
    {
        currentXP += xp;
        xPDisplay.text = "XP: " + currentXP + "/" + (5 + 5 * level);
        if (currentXP >= 5 + 5 * level)
        {
            LevelUp();
            SpellIncreaseCheck();
        }
    }
    public void LevelUp()
    {
        currentXP -= 5 + 5 * level;
        xPDisplay.text = "XP: " + currentXP + "/" + (5 + 5 * level);
        level++;
        attackDamageLevelTracker++;
        maxHP += 2;
        healthAndDamageCanvasScript.maxHP = (int)maxHP;
        Heal(2);
        levelDisplay.text = "Level:" + level;
        if (attackDamageLevelTracker > 3)
        {
            attackDamageLevelTracker = 0;
            basicAttackDamage++;
        }
        if (currentXP >= 5 + 5 * level)
        {
            LevelUp();
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
    IEnumerator EnergyTick()
    {
        yield return new WaitForSeconds(.3f);
        if (!energyDowntickCooldown)
        {
            currentEnergy++;
            energyDisplay.text = "Energy " + currentEnergy + "/" + maxEnergy;
        }
        if (currentEnergy < maxEnergy)
        {
            StartCoroutine(EnergyTick());
        }
        else
        {
            energyTickCooldownBool = false;
        }
    }
    IEnumerator EnergyDowntickCooldown()
    {
        yield return new WaitForSeconds(.12f);
        energyDowntickCooldown = false;
    }
    //how long the ice wave hitbox is active.
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
