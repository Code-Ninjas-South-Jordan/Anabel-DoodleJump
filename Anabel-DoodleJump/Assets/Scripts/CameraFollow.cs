﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Target Object")]
    public Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y > transform.position.y) {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }
    }
}