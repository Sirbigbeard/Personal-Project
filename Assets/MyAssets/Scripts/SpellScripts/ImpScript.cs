using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpScript : Ally
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        transform.Translate(Vector3.forward * 1);
        speed = 3;
        Begin();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}