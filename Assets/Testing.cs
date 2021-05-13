using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Testing : XRBaseInteractable
{
    private CallElevatorButton test;

    protected override void Awake()
    {
        base.Awake();
        test = GetComponent<CallElevatorButton>();
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        print(this.gameObject.transform.position);
        print(args.interactor.gameObject.transform.position);
        if (Vector3.Distance(this.gameObject.transform.position, args.interactor.gameObject.transform.position) < 2f)
        {
            print("a");
            test.PressButon();
        }
        base.OnHoverEntered(args);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }
}
