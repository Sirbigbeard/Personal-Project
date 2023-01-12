using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFlagship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieNoob());
    }
    IEnumerator DieNoob()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
}
