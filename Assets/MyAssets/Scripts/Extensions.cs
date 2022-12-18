using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions : object
{
    public static bool HasComponent<T>(this GameObject obj) where T:Component
    {
        return obj.GetComponent<T>() != null;
    }
    public static Component GetScript(this GameObject obj)
    {
        if(obj.HasComponent<Player>())
        {
            return obj.GetComponent<Player>();
        }
        if (obj.HasComponent<Projectile>())
        {
            return obj.GetComponent<Projectile>();
        }
        if (obj.HasComponent<Enemy>())
        {
            return obj.GetComponent<Enemy>();
        }
        if (obj.HasComponent<Hut>())
        {
            return obj.GetComponent<Hut>();
        }
        if (obj.HasComponent<Building>())
        {
            return obj.GetComponent<Building>();
        }
        if (obj.HasComponent<DamageableObject>())
        {
            return obj.GetComponent<DamageableObject>();
        }
        return null;
    }
    public static void ShuffleList(this List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    public static GameObject GetClosest(this GameObject obj, List<GameObject> list)//change to RangeObject and make RangeObject.cs parent to rf and ah
    {
        GameObject closestTarget = null;
        if (list.Count != 0)
        {
            float closestDistance = 9999f;
            foreach (GameObject target in list)
            {
                float distanceVector = Vector3.Distance(obj.transform.position, target.transform.position);
                if (distanceVector < closestDistance)
                {
                    closestDistance = distanceVector;
                    closestTarget = target;
                }
            }
        }
        return closestTarget;
    }
}