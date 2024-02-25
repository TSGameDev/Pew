using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public WeaponData WeaponDataInstance { get;  set; }

    public void Fire();
    public void Reload();
}
