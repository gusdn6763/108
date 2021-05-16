using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChange : XRGrabInteractable
{
    [SerializeField] private GameObject[] frame_box = new GameObject[4];
    [SerializeField] private Material changeMat;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        GetComponent<BoxCollider>().isTrigger = true;
        for (int i = 0; i < frame_box.Length; i++)
        {
            frame_box[i].GetComponent<MeshRenderer>().material = changeMat;
            frame_box[i].GetComponent<BoxCollider>().isTrigger = true;
        }
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        GetComponent<BoxCollider>().isTrigger = false;
        for (int i = 0; i < frame_box.Length; i++)
        {
            frame_box[i].GetComponent<BoxCollider>().isTrigger = false;
        }
        
        base.OnSelectExited(args);
    }
}
