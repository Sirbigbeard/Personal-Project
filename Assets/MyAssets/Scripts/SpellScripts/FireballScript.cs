using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private int speed = 55;
    public int damage = 7;
    public DamageableObject targetScript;
    void Start()
    {
        
    }
    void Awake()
    {
        StartCoroutine(DeathDelay());
    }
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targetScript = other.gameObject.GetScript() as DamageableObject;
            targetScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
