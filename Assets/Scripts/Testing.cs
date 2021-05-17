using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Testing : XRBaseInteractable
{
    public int count;
    public testing3 test;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        GetComponent<IPress>().PressButton();
        test.check[count] = true;
        base.OnHoverEntered(args);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }
}
