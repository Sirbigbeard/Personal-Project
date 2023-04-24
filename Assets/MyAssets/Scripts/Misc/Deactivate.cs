using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deactivation());
    }

    IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(.001f);
        gameObject.SetActive(false);
    }
}
