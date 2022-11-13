using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private Vector3 moveInput;
    private float rotationRate = 15f;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15f;
    private float manaRegenRate = 1;
    public int currentMana;
    public int maxMana;
    public int currentHP;
    public int maxHP;
    public int level = 1;
    public int castableSpells = 1;
    public int touchingBuilding = 0;
    private bool attackCooldownActive = false;
    private bool spellCasted = false;
    public bool attackDurationActive = false;
    private bool bulwarkRefresh = false;
    private bool bulwarkActive = false;
    private bool manaTickActive = false;
    private float attackCooldownFloat = 3.1f;
    private float attackDurationFloat = 1.5f;
    public GameObject GameManager;
    private GameManager gameManagerScript;
    public GameObject mainCamera;
    public GameObject weapon;
    public GameObject head;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject torso;
    public GameObject iceWaveHitbox;
    public TextMeshProUGUI spell1Name;
    public TextMeshProUGUI spell2Name;
    public TextMeshProUGUI spell3Name;
    public TextMeshProUGUI spell4Name;
    public TextMeshProUGUI manaDisplay;
    public TextMeshProUGUI healthDisplay;
    public List<GameObject> spellList;
    private Renderer leftLegRenderer;
    private Renderer leftArmRenderer;
    private Renderer rightLegRenderer;
    private Renderer rightArmRenderer;
    private Renderer headRenderer;
    private Renderer torsoRenderer;
    private Color playerColor;
    private Color bulwarkColor;
    private Weapon weaponScript;
    private Vector3 startingPosition = new Vector3(0, 3.5f, 0);

    void Start()
    {
        spellList = new List<GameObject>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameManagerScript = GameManager.GetComponent<GameManager>();
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
        currentHP = 10;
        maxHP = 10;
        currentMana = 10;
        maxMana = 10;
        transform.position = startingPosition;
    }

    void Update()
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
            if (Input.GetKeyDown("1") && castableSpells > 0)
            {
                CastSpell(spellList[0]);
                if (spellList.Count > castableSpells && spellCasted)
                {
                    spellList.Add(spellList[0]);
                    spellList[0] = spellList[castableSpells];
                    spell1Name.text = spellList[castableSpells].name;
                    spellList.RemoveAt(castableSpells);
                }
                spellCasted = false;
            }
            if (Input.GetKeyDown("2") && castableSpells > 1)
            {
                CastSpell(spellList[1]);
                if (spellList.Count > castableSpells && spellCasted)
                {
                    spellList.Add(spellList[1]);
                    spellList[1] = spellList[castableSpells];
                    spell2Name.text = spellList[castableSpells].name;
                    spellList.RemoveAt(castableSpells);
                }
                spellCasted = false;
            }
            if (Input.GetKeyDown("3") && castableSpells > 2)
            {
                CastSpell(spellList[2]);
                if (spellList.Count > castableSpells && spellCasted)
                {
                    spellList.Add(spellList[2]);
                    spellList[2] = spellList[castableSpells];
                    spell3Name.text = spellList[castableSpells].name;
                    spellList.RemoveAt(castableSpells);
                }
                spellCasted = false;
            }
            if (Input.GetKeyDown("4") && castableSpells > 3)
            {
                CastSpell(spellList[3]);
                if (spellList.Count > castableSpells && spellCasted)
                {
                    spellList.Add(spellList[3]);
                    spellList[3] = spellList[castableSpells];
                    spell4Name.text = spellList[castableSpells].name;
                    spellList.RemoveAt(castableSpells);
                }
                spellCasted = false;
            }
            if(currentMana < maxMana && !manaTickActive)
            {
                StartCoroutine(ManaTick());
                manaTickActive = true;
            }
        }
    }
    void FixedUpdate()
    {
        if (!Input.GetKey("tab"))
        {
            RegisterMovement();
        }
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
        if (gameManagerScript.roundBegun)
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
    }
    private void Attack()
    {
        //weaponScript.damageDealt = false;
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
        yield return new WaitForSeconds(attackDurationFloat);
        attackDurationActive = false;
    }
    public void CastSpell(GameObject spell)
    {
        if (spell.name == "Fire Ball")
        {
            CastFireball();
            spellCasted = true;
        }
        if (spell.name == "Slam")
        {
            CastSlam();
            spellCasted = true;
        }
        if (spell.name == "Ice Wave" && currentMana >= 5)
        {
            CastIceWave();
            spellCasted = true;
        }
        if (spell.name == "Summon Imp")
        {
            CastSummonImp();
            spellCasted = true;
        }
        if (spell.name == "Bulwark" && currentMana >= 4)
        {
            CastBulwark();
            spellCasted = true;
        }
        if (spell.name == "Blink")
        {
            CastBlink();
            spellCasted = true;
        }
    }
    public void CastFireball()
    {
        Debug.Log("Fireball Casted");
    }
    public void CastSlam()
    {
        Debug.Log("Slam Casted");
    }
    public void CastIceWave()
    {
        currentMana -= 5;
        iceWaveHitbox.SetActive(true);
        Debug.Log("Ice Wave Casted");
    }
    public void CastSummonImp()
    {
        Debug.Log("Summon Imp Casted");
    }
    public void CastBulwark()
    {
        currentMana -= 4;
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
        Debug.Log("Blink Casted");
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
            Debug.Log("Bulwark was refreshed");
            leftLegRenderer.material.SetColor("_Color", playerColor);
            rightLegRenderer.material.SetColor("_Color", playerColor);
            leftArmRenderer.material.SetColor("_Color", playerColor);
            rightArmRenderer.material.SetColor("_Color", playerColor);
            headRenderer.material.SetColor("_Color", playerColor);
            torsoRenderer.material.SetColor("_Color", playerColor);
            bulwarkActive = false;
        }
        Debug.Log("Bulwark not refreshed");
        bulwarkRefresh = false;
    }
    public void Reset()
    {
        transform.position = startingPosition;
        currentHP = maxHP;
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
    }
    IEnumerator ManaTick()
    {
        yield return new WaitForSeconds(manaRegenRate);
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
}
