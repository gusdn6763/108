using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class OnGrab : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

            GetComponent<BoxCollider>().isTrigger = true;
            Player.instance.isGrabItem = this.gameObject;
            base.OnSelectEntered(args);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        GetComponent<BoxCollider>().isTrigger = false;
        Player.instance.isGrabItem = null;
        base.OnHoverExited(args);
    }


    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        if (Player.instance.isGrabItem == null)
        {
            Player.instance.isGrabItem = this.gameObject;
        }
        return (base.IsSelectableBy(interactor) && Player.instance.isGrabItem == this.gameObject);
    }
}
