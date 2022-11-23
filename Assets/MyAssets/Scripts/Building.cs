using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //this class controls building functionality, and is also parent class to all ally and enemy classes to reuse targeting code.
    public GameObject projectile;
    public GameObject target;
    public GameObject rangeFinder;
    public GameObject buildPositionObject;
    public BuildPosition buildPositionScript;
    public float attackRange;
    //public GameObject attackHitbox;
    //protected AttackHitbox attackHitboxScript;
    protected Projectile projectileScript;
    protected RangeFinder rangeFinderScript;
    protected bool attackReadyRanged = true;
    public float attackCooldownRanged = 3f;
    protected List<GameObject> targets;
    protected float range = 8;
    protected Vector3 targetPosition;
    public bool hitsFlying = false;
    protected bool attackCooldownActive = false;
    protected bool attackDurationActive = false;
    protected float attackCooldownFloat = 3.1f;
    protected float attackDurationFloat = 1.5f;
    public GameObject weapon;
    //private Weapon weaponScript;
    public float maxHP;
    public float currentHP;
    protected float distanceToTarget;
    protected float speed;
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

    void Start()
    {
        
    }
    void Update()
    {
        if (attackReadyRanged && target != null)
        {
            Debug.Log("attacking, targets.count = " + targets.Count + " and target = " + target);
            FireProjectile();
        }
        if (currentHP < 1)
        {
            transform.Translate(100000, 100000, 100000);
            ResetPositionScript();
            StartCoroutine(DestroyDelay());
        }
    }
    void Awake()
    {
        Begin();
        maxHP = 25;
        currentHP = 25;
        StartCoroutine(TaggingDelay());
    }
    protected void Begin()
    {
        buildPositionObject = GameObject.Find("BuildPosition");
        buildPositionScript = buildPositionObject.GetComponent<BuildPosition>();
        targets = new List<GameObject>();
        rangeFinderScript = rangeFinder.GetComponent<RangeFinder>();
        //attackHitboxScript = attackHitbox.GetComponent<AttackHitbox>();
        if (!hitsFlying)
        {
            rangeFinder.transform.localScale = new Vector3(range, .25f, range);
        }
        else
        {
            rangeFinder.transform.localScale = new Vector3(range, 2, range);
        }
    }
    void FireProjectile()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        GameObject projectileFired = Instantiate(projectile, spawnPoint, projectile.transform.rotation) as GameObject;
        projectileScript = projectileFired.GetComponent<Projectile>();
        projectileScript.target = target;
        attackReadyRanged = false;
        StartCoroutine(RangedAttackCooldown());
    }
    IEnumerator RangedAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownRanged);
        attackReadyRanged = true;
    }
    IEnumerator TaggingDelay()
    {
        yield return new WaitForSeconds(.1f);
        rangeFinderScript.validTargetTags.Add("Enemy");
    }
    public void AddTarget(GameObject newTarget)
    {
        targets.Add(newTarget);
        if (targets.Count == 1)
        {
            target = targets[0];
        }
    }
    protected void Attack()
    {
        attackCooldownActive = true;
        attackDurationActive = true;
        StartCoroutine(MelleAttackCooldown());
        Debug.Log("bonk");
        //StartCoroutine(MelleAttackDuration());
    }
    IEnumerator MelleAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownFloat);
        attackCooldownActive = false;
    }
    //IEnumerator MelleAttackDuration()
    //{
    //    yield return new WaitForSeconds(attackDurationFloat);
    //    attackDurationActive = false;
    //}
    //both removes the current target and finds the next closest available target if there is one.
    public void RemoveTarget(GameObject targetToRemove)
    {
        float closestDistance = 9999f;
        targets.Remove(targetToRemove);
        GameObject closestEnemy = null;
        if (targets.Count == 0)
        {
            target = null;
        }
        else foreach (GameObject enemy in targets)
        {
                float distanceVector = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceVector < closestDistance)
                {
                    closestDistance = distanceVector;
                    closestEnemy = enemy;
                }
            }
        if (closestEnemy != null)
        {
            target = closestEnemy;
        }
    }
    public void ChangeRange(int change)
    {
        range += change;
    }
    public void SetRange(int newRange)
    {
        range = newRange;
    }
    protected IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
    //methods specifically for children classes
    protected void Move()
    {
        
        if(target != null)
        {
            distanceToTarget = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(target.transform.position.x, 0, target.transform.position.z));
            if(distanceToTarget > attackRange)
            {
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else if(!attackCooldownActive)
            {
                Attack();
            }
            transform.LookAt(targetPosition);
        }
        if(target == null)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0); //default target should be home base when the z value is below whatever value the lanes begin converging
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
    protected void ResetPositionScript()
    {
        if (position1)
        {
            buildPositionScript.position1ButtonObject.SetActive(true);
        }
        if (position2)
        {
            buildPositionScript.position2ButtonObject.SetActive(true);
        }
        if (position3)
        {
            buildPositionScript.position3ButtonObject.SetActive(true);
        }
        if (position4)
        {
            buildPositionScript.position4ButtonObject.SetActive(true);
        }
        if (position5)
        {
            buildPositionScript.position5ButtonObject.SetActive(true);
        }
        if (position6)
        {
            buildPositionScript.position6ButtonObject.SetActive(true);
        }
        if (position7)
        {
            buildPositionScript.position7ButtonObject.SetActive(true);
        }
        if (position8)
        {
            buildPositionScript.position8ButtonObject.SetActive(true);
        }
        if (position9)
        {
            buildPositionScript.position9ButtonObject.SetActive(true);
        }
        if (position10)
        {
            buildPositionScript.position10ButtonObject.SetActive(true);
        }
        if (position11)
        {
            buildPositionScript.position11ButtonObject.SetActive(true);
        }
        if (position12)
        {
            buildPositionScript.position12ButtonObject.SetActive(true);
        }
        if (position13)
        {
            buildPositionScript.position13ButtonObject.SetActive(true);
        }
        if (position14)
        {
            buildPositionScript.position14ButtonObject.SetActive(true);
        }
        if (position15)
        {
            buildPositionScript.position15ButtonObject.SetActive(true);
        }
        if (position16)
        {
            buildPositionScript.position16ButtonObject.SetActive(true);
        }
        if (position17)
        {
            buildPositionScript.position17ButtonObject.SetActive(true);
        }
        if (position18)
        {
            buildPositionScript.position18ButtonObject.SetActive(true);
        }
        if (position19)
        {
            buildPositionScript.position19ButtonObject.SetActive(true);
        }
        if (position20)
        {
            buildPositionScript.position20ButtonObject.SetActive(true);
        }
        if (position21)
        {
            buildPositionScript.position21ButtonObject.SetActive(true);
        }
        if (position22)
        {
            buildPositionScript.position22ButtonObject.SetActive(true);
        }
        if (position23)
        {
            buildPositionScript.position23ButtonObject.SetActive(true);
        }
        if (position24)
        {
            buildPositionScript.position24ButtonObject.SetActive(true);
        }
        if (position25)
        {
            buildPositionScript.position25ButtonObject.SetActive(true);
        }
        if (position26)
        {
            buildPositionScript.position26ButtonObject.SetActive(true);
        }
        if (position27)
        {
            buildPositionScript.position27ButtonObject.SetActive(true);
        }
        if (position28)
        {
            buildPositionScript.position28ButtonObject.SetActive(true);
        }
        if (position29)
        {
            buildPositionScript.position29ButtonObject.SetActive(true);
        }
        if (position30)
        {
            buildPositionScript.position30ButtonObject.SetActive(true);
        }
        if (position31)
        {
            buildPositionScript.position31ButtonObject.SetActive(true);
        }
        if (position32)
        {
            buildPositionScript.position32ButtonObject.SetActive(true);
        }
        if (position33)
        {
            buildPositionScript.position33ButtonObject.SetActive(true);
        }
        if (position34)
        {
            buildPositionScript.position34ButtonObject.SetActive(true);
        }
        if (position35)
        {
            buildPositionScript.position35ButtonObject.SetActive(true);
        }
        if (position36)
        {
            buildPositionScript.position36ButtonObject.SetActive(true);
        }
        if (position37)
        {
            buildPositionScript.position37ButtonObject.SetActive(true);
        }
        if (position38)
        {
            buildPositionScript.position38ButtonObject.SetActive(true);
        }
        if (position39)
        {
            buildPositionScript.position39ButtonObject.SetActive(true);
        }
        if (position40)
        {
            buildPositionScript.position40ButtonObject.SetActive(true);
        }
        if (position41)
        {
            buildPositionScript.position41ButtonObject.SetActive(true);
        }
        if (position42)
        {
            buildPositionScript.position42ButtonObject.SetActive(true);
        }
        if (position43)
        {
            buildPositionScript.position43ButtonObject.SetActive(true);
        }
        if (position44)
        {
            buildPositionScript.position44ButtonObject.SetActive(true);
        }
        if (position45)
        {
            buildPositionScript.position45ButtonObject.SetActive(true);
        }
        if (position46)
        {
            buildPositionScript.position46ButtonObject.SetActive(true);
        }
        if (position47)
        {
            buildPositionScript.position47ButtonObject.SetActive(true);
        }
        if (position48)
        {
            buildPositionScript.position48ButtonObject.SetActive(true);
        }
        if (position49)
        {
            buildPositionScript.position49ButtonObject.SetActive(true);
        }
        if (position50)
        {
            buildPositionScript.position50ButtonObject.SetActive(true);
        }
        if (position51)
        {
            buildPositionScript.position51ButtonObject.SetActive(true);
        }
        if (position52)
        {
            buildPositionScript.position52ButtonObject.SetActive(true);
        }
        if (position53)
        {
            buildPositionScript.position53ButtonObject.SetActive(true);
        }
        if (position54)
        {
            buildPositionScript.position54ButtonObject.SetActive(true);
        }
        if (position55)
        {
            buildPositionScript.position55ButtonObject.SetActive(true);
        }
        if (position56)
        {
            buildPositionScript.position56ButtonObject.SetActive(true);
        }
        if (position57)
        {
            buildPositionScript.position57ButtonObject.SetActive(true);
        }
        if (position58)
        {
            buildPositionScript.position58ButtonObject.SetActive(true);
        }
        if (position59)
        {
            buildPositionScript.position59ButtonObject.SetActive(true);
        }
        if (position60)
        {
            buildPositionScript.position60ButtonObject.SetActive(true);
        }
        if (position61)
        {
            buildPositionScript.position61ButtonObject.SetActive(true);
        }
        if (position62)
        {
            buildPositionScript.position62ButtonObject.SetActive(true);
        }
        if (position63)
        {
            buildPositionScript.position63ButtonObject.SetActive(true);
        }
        if (position64)
        {
            buildPositionScript.position64ButtonObject.SetActive(true);
        }
        if (position65)
        {
            buildPositionScript.position65ButtonObject.SetActive(true);
        }
        if (position66)
        {
            buildPositionScript.position66ButtonObject.SetActive(true);
        }
        if (position67)
        {
            buildPositionScript.position67ButtonObject.SetActive(true);
        }
        if (position68)
        {
            buildPositionScript.position68ButtonObject.SetActive(true);
        }
        if (position69)
        {
            buildPositionScript.position69ButtonObject.SetActive(true);
        }
        if (position70)
        {
            buildPositionScript.position70ButtonObject.SetActive(true);
        }
        if (position71)
        {
            buildPositionScript.position71ButtonObject.SetActive(true);
        }
        if (position72)
        {
            buildPositionScript.position72ButtonObject.SetActive(true);
        }
        if (position73)
        {
            buildPositionScript.position73ButtonObject.SetActive(true);
        }
        if (position74)
        {
            buildPositionScript.position74ButtonObject.SetActive(true);
        }
        if (position75)
        {
            buildPositionScript.position75ButtonObject.SetActive(true);
        }
        if (position76)
        {
            buildPositionScript.position76ButtonObject.SetActive(true);
        }
        if (position77)
        {
            buildPositionScript.position77ButtonObject.SetActive(true);
        }
        if (position78)
        {
            buildPositionScript.position78ButtonObject.SetActive(true);
        }
        if (position79)
        {
            buildPositionScript.position79ButtonObject.SetActive(true);
        }
        if (position80)
        {
            buildPositionScript.position80ButtonObject.SetActive(true);
        }
        if (position81)
        {
            buildPositionScript.position81ButtonObject.SetActive(true);
        }
        if (position82)
        {
            buildPositionScript.position82ButtonObject.SetActive(true);
        }
        if (position83)
        {
            buildPositionScript.position83ButtonObject.SetActive(true);
        }
        if (position84)
        {
            buildPositionScript.position84ButtonObject.SetActive(true);
        }
        if (position85)
        {
            buildPositionScript.position85ButtonObject.SetActive(true);
        }
        if (position86)
        {
            buildPositionScript.position86ButtonObject.SetActive(true);
        }
        if (position87)
        {
            buildPositionScript.position87ButtonObject.SetActive(true);
        }
        if (position88)
        {
            buildPositionScript.position88ButtonObject.SetActive(true);
        }
        if (position89)
        {
            buildPositionScript.position89ButtonObject.SetActive(true);
        }
        if (position90)
        {
            buildPositionScript.position90ButtonObject.SetActive(true);
        }
        if (position91)
        {
            buildPositionScript.position91ButtonObject.SetActive(true);
        }
        if (position92)
        {
            buildPositionScript.position92ButtonObject.SetActive(true);
        }
        if (position93)
        {
            buildPositionScript.position93ButtonObject.SetActive(true);
        }
        if (position94)
        {
            buildPositionScript.position94ButtonObject.SetActive(true);
        }
        if (position95)
        {
            buildPositionScript.position95ButtonObject.SetActive(true);
        }
        if (position96)
        {
            buildPositionScript.position96ButtonObject.SetActive(true);
        }
        if (position97)
        {
            buildPositionScript.position97ButtonObject.SetActive(true);
        }
        if (position98)
        {
            buildPositionScript.position98ButtonObject.SetActive(true);
        }
        if (position99)
        {
            buildPositionScript.position99ButtonObject.SetActive(true);
        }
        if (position100)
        {
            buildPositionScript.position100ButtonObject.SetActive(true);
        }
        if (position101)
        {
            buildPositionScript.position101ButtonObject.SetActive(true);
        }
        if (position102)
        {
            buildPositionScript.position102ButtonObject.SetActive(true);
        }
        if (position103)
        {
            buildPositionScript.position103ButtonObject.SetActive(true);
        }
        if (position104)
        {
            buildPositionScript.position104ButtonObject.SetActive(true);
        }
        if (position105)
        {
            buildPositionScript.position105ButtonObject.SetActive(true);
        }
        if (position106)
        {
            buildPositionScript.position106ButtonObject.SetActive(true);
        }
        if (position107)
        {
            buildPositionScript.position107ButtonObject.SetActive(true);
        }
        if (position108)
        {
            buildPositionScript.position108ButtonObject.SetActive(true);
        }
        if (position109)
        {
            buildPositionScript.position109ButtonObject.SetActive(true);
        }
        if (position110)
        {
            buildPositionScript.position110ButtonObject.SetActive(true);
        }
        if (position111)
        {
            buildPositionScript.position111ButtonObject.SetActive(true);
        }
        if (position112)
        {
            buildPositionScript.position112ButtonObject.SetActive(true);
        }
        if (position113)
        {
            buildPositionScript.position113ButtonObject.SetActive(true);
        }
        if (position114)
        {
            buildPositionScript.position114ButtonObject.SetActive(true);
        }
        if (position115)
        {
            buildPositionScript.position115ButtonObject.SetActive(true);
        }
        if (position116)
        {
            buildPositionScript.position116ButtonObject.SetActive(true);
        }
        if (position117)
        {
            buildPositionScript.position117ButtonObject.SetActive(true);
        }
        if (position118)
        {
            buildPositionScript.position118ButtonObject.SetActive(true);
        }
        if (position119)
        {
            buildPositionScript.position119ButtonObject.SetActive(true);
        }
        if (position120)
        {
            buildPositionScript.position120ButtonObject.SetActive(true);
        }
        if (position121)
        {
            buildPositionScript.position121ButtonObject.SetActive(true);
        }
        if (position122)
        {
            buildPositionScript.position122ButtonObject.SetActive(true);
        }
        if (position123)
        {
            buildPositionScript.position123ButtonObject.SetActive(true);
        }
        if (position124)
        {
            buildPositionScript.position124ButtonObject.SetActive(true);
        }
        if (position125)
        {
            buildPositionScript.position125ButtonObject.SetActive(true);
        }
        if (position126)
        {
            buildPositionScript.position126ButtonObject.SetActive(true);
        }
    }
}
