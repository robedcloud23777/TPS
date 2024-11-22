using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun, IZoomable
{
    protected override void MouseLeftPress()
    {
        base.MouseLeftPress();
        Attack();
    }

    protected override void RKeyPress()
    {
        base.RKeyPress();
        Reload();
    }

    protected override void MouseRightPress()
    {
        base.MouseRightPress();
        ZoomIn();
    }

    protected override void MouseRightRelease()
    {
        base.MouseRightRelease();
        ZoomOut();
    }

    public void ZoomIn()
    {
        Debug.Log("¡‹¿Œ");
    }

    public void ZoomOut()
    {
        Debug.Log("¡‹æ∆øÙ");
    }
}
