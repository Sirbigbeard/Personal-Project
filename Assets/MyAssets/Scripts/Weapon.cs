using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player;
    public Player playerScript;
    private bool attackCooldown = false;
    private bool attackDuration = false;
    private float attackCooldownFloat = 3.1f;
    private float attackDurationFloat = 1.5f;
    private int damage = 2;
    private bool damageDealt = false;
    public Enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackCooldown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    }
    private void Attack()
    {
        damageDealt = false;
        Debug.Log("attacked");
        attackCooldown = true;
        attackDuration = true;
        StartCoroutine(AttackCooldown());
        StartCoroutine(AttackDuration());
    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownFloat);
        Debug.Log("test");
        attackCooldown = false;
    }
    IEnumerator AttackDuration()
    {
        yield return new WaitForSeconds(attackDurationFloat);
        attackDuration = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (attackDuration)
        {
            if (other.gameObject.tag == "Enemy")
            {
                enemyScript = other.gameObject.GetComponent<Enemy>();
                if (!damageDealt)
                {
                    //enemyScript.health -= 10;
                    //Debug.Log(enemyScript.health);
                    Debug.Log("Gottem");
                    damageDealt = true;
                }
            }
        }
    }
}
