using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageUI : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 location;
    public Transform host;
    public TextMeshProUGUI textMesh;
    public int incomingDamageCount = 0;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {
        if(host != null)
        {
            location = cam.WorldToScreenPoint(host.position + offset);
            if (transform.position != location)
            {
                transform.position = location;
            }
        }
    }
    public void DamageIncoming(float damage)
    {
        textMesh.text = "-" + damage;
        incomingDamageCount++;
        StartCoroutine(DamageFade());
    }
    IEnumerator DamageFade()
    {
        yield return new WaitForSeconds(1);
        incomingDamageCount--;
        if (incomingDamageCount == 0)
        {
            textMesh.text = "";
        }
    }
}
