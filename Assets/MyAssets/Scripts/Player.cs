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
    public int currentHP;
    public int maxHP;
    public int touchingBuilding = 0;
    private bool attackCooldownActive = false;
    public bool attackDurationActive = false;
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
    public TextMeshProUGUI spell1Name;
    public TextMeshProUGUI spell2Name;
    public TextMeshProUGUI spell3Name;
    public TextMeshProUGUI spell4Name;
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
            if (Input.GetKeyDown("1") && spellList.Count > 0)
            {
                CastSpell(spellList[0]);
                if (spellList.Count > 4)
                {
                    spellList.Add(spellList[0]);
                    spellList[0] = spellList[4];
                    spell1Name.text = spellList[4].name;
                    spellList.RemoveAt(4);
                }
            }
            if (Input.GetKeyDown("2") && spellList.Count > 1)
            {
                CastSpell(spellList[1]);
                if (spellList.Count > 4)
                {
                    spellList.Add(spellList[1]);
                    spellList[1] = spellList[4];
                    spell2Name.text = spellList[4].name;
                    spellList.RemoveAt(4);
                }
            }
            if (Input.GetKeyDown("3") && spellList.Count > 2)
            {
                CastSpell(spellList[2]);
                if (spellList.Count > 4)
                {
                    spellList.Add(spellList[2]);
                    spellList[2] = spellList[4];
                    spell3Name.text = spellList[4].name;
                    spellList.RemoveAt(4);
                }
            }
            if (Input.GetKeyDown("4") && spellList.Count > 3)
            {
                CastSpell(spellList[3]);
                if (spellList.Count > 4)
                {
                    spellList.Add(spellList[3]);
                    spellList[3] = spellList[4];
                    spell4Name.text = spellList[4].name;
                    spellList.RemoveAt(4);
                }
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
        if(gameManagerScript.roundBegun)
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
        if(spell.name == "Fire Ball")
        {
            CastFireball();
        }
        if (spell.name == "Slam")
        {
            CastSlam();
        }
        if (spell.name == "Ice Wave")
        {
            CastIceWave();
        }
        if (spell.name == "Summon Imp")
        {
            CastSummonImp();
        }
        if (spell.name == "Bulwark")
        {
            CastBulwark();
        }
        if (spell.name == "Blink")
        {
            CastBlink();
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
        Debug.Log("Ice Wave Casted");
    }
    public void CastSummonImp()
    {
        Debug.Log("Summon Imp Casted");
    }
    public void CastBulwark()
    {
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
        if(other.tag == "Building" || other.tag == "Wall")
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
        leftLegRenderer.material.SetColor("_Color", playerColor);
        rightLegRenderer.material.SetColor("_Color", playerColor);
        leftArmRenderer.material.SetColor("_Color", playerColor);
        rightArmRenderer.material.SetColor("_Color", playerColor);
        headRenderer.material.SetColor("_Color", playerColor);
        torsoRenderer.material.SetColor("_Color", playerColor);
    }
    public void Reset()
    {
        transform.position = startingPosition;
        currentHP = maxHP;
    }
}
