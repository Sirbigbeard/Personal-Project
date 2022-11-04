using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public GameObject holder;
    public Player holderScript;
    private int damage = 9;
    public bool damageDealt = false;
    public Enemy enemyScript;

    void Start()
    {
        //holderScript = holder.GetComponent<Player>();
    }
    void Update()
    {
        
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (holderScript.attackDurationActive)
        {
            if (other.gameObject.tag == "Enemy")
            {
                enemyScript = other.gameObject.GetComponent<Enemy>();
                if (!damageDealt)
                {
                    enemyScript.health -= damage;
                    Debug.Log(enemyScript.health);
                    Debug.Log("damage");
                    damageDealt = true;
                }
            }
        }
    }*/
}
