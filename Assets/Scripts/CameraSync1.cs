﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSync1 : MonoBehaviour
{

    public Transform originCameraTrasnfrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = originCameraTrasnfrom.rotation;
    }
}
