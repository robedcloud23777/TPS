using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon, IAttackable, IReloadable
{
    [SerializeField] protected int maxAmmoCount;
    [SerializeField] protected int curAmmoCount;
    [SerializeField] protected int totalAmmoCount;
    [SerializeField] protected int ammoPerShot;

    public virtual bool Attack()
    {
        if(curAmmoCount <= 0 ) return false;

        int shootingAmmoCount = Mathf.Min(ammoPerShot, curAmmoCount);
        curAmmoCount -= shootingAmmoCount;

        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance, detectLayer))
        {
            if(hit.transform.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage(weaponDamage * shootingAmmoCount);
            }
        }

        return true;
    }

    public virtual void Reload()
    {
        int neededCount = maxAmmoCount - curAmmoCount;

        if(totalAmmoCount >= neededCount)
        {
            curAmmoCount += neededCount;
            totalAmmoCount -= neededCount;
        }
        else
        {
            curAmmoCount += totalAmmoCount;
            totalAmmoCount = 0;
        }
    }
}
