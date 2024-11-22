using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : Gun, IRecoilable
{
    [SerializeField] private float recoilForce;

    protected override void MouseLeftPress()
    {
        base.MouseLeftPress();
        if (Attack())
        {
            Recoil(recoilForce);
        }
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
        Debug.Log("����");
    }

    public void ZoomOut()
    {
        Debug.Log("�ܾƿ�");
    }

    public void Recoil(float force)
    {
        Debug.Log($"�ݵ� {recoilForce}��ŭ �ޱ�");
    }
}
