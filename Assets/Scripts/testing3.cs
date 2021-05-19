using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class testing3 : XRBaseInteractable
{
    public bool[] check = new bool[4];
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        for (int i = 0; i < check.Length; i++)
        {
            if (check[i] == false)
            {
                base.OnHoverEntered(args);
                return ;
            }
        }

        GetComponent<IPress>().PressButton();
        base.OnHoverEntered(args);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }
}
