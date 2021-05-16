using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Testing2 : XRBaseInteractable
{
    [SerializeField] private Transform trans;

    private void Update()
    {
        transform.position = trans.position;
    }
}
