using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    private bool attackCooldownActive = false;
    public bool attackDurationActive = false;
    private float attackCooldownFloat = 3.1f;
    private float attackDurationFloat = 1.5f;
    public GameObject GameManager;
    private GameManager gameManagerScript;
    public GameObject mainCamera;
    public GameObject weapon;
    public TextMeshProUGUI spell1Name;
    public TextMeshProUGUI spell2Name;
    public TextMeshProUGUI spell3Name;
    public TextMeshProUGUI spell4Name;
    public List<GameObject> spellList;
    private Weapon weaponScript;

    void Start()
    {
        spellList = new List<GameObject>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameManagerScript = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (!Input.GetKey("tab"))
        {
            RegisterMovement();
        }
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
    //registers wasd and moves character correspondingly
    private void RegisterMovement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (!gameManagerScript.roundBegun)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed, Space.World);
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed, Space.World);
            SetDirection();
        }
        if(gameManagerScript.roundBegun)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
        //playerRb.velocity = new Vector3(0, 0, 0);
    }
    //Faces the player model towards the moving direction and sets the direction variable to the corresponding number
    private void SetDirection()
    {
        if (verticalInput > 0 && horizontalInput == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (verticalInput > 0 && horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        if (verticalInput == 0 && horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (verticalInput < 0 && horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (verticalInput < 0 && horizontalInput == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (verticalInput < 0 && horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -135, 0);
        }
        if (verticalInput == 0 && horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (verticalInput > 0 && horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
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
        Debug.Log("Bulwark Casted");
    }
    public void CastBlink()
    {
        Debug.Log("Blink Casted");
    }

}
