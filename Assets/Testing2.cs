using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Testing2 : XRBaseInteractable
{
    private FloorButtonTrigger test;

    protected override void Awake()
    {
        base.Awake();
        test = GetComponent<FloorButtonTrigger>();
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        print("aa");
        test.PressButon();
        base.OnHoverEntered(args);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }
}
