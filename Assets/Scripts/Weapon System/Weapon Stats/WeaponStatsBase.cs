using System;
using UnityEngine;

[Serializable]
public enum FireMode{
    Bolt,
    SemiAuto,
    FullAuto
}

[Serializable]
public struct WeaponData {
    public string weaponName;
    public FireMode fireMode;
    public int magazineSize;
    public int maxAmmo;
    public int damage;
    public float headShotMultiplier;
    public float weakShotMultiplier;

    public WeaponData(string weaponName,
        FireMode fireMode = FireMode.Bolt,
        int magazineSize = 1,
        int maxAmmo = 2,
        int damage = 1,
        float headShotMultiplier = 1.00f,
        float weakShotMultiplier = 1.00f)
    {
        this.weaponName = weaponName;
        this.fireMode = fireMode;
        this.magazineSize = magazineSize;
        this.maxAmmo = maxAmmo;   
        this.damage = damage;
        this.headShotMultiplier = headShotMultiplier;
        this.weakShotMultiplier = weakShotMultiplier;
    }

    public WeaponData(WeaponData weaponDataCopy)
    {
        weaponName = weaponDataCopy.weaponName;
        fireMode = weaponDataCopy.fireMode;
        magazineSize = weaponDataCopy.magazineSize;
        maxAmmo = weaponDataCopy.maxAmmo;
        damage = weaponDataCopy.damage;
        headShotMultiplier = weaponDataCopy.headShotMultiplier;
        weakShotMultiplier = weaponDataCopy.weakShotMultiplier;
    }
}

[CreateAssetMenu(fileName = "New Weapon Stats", menuName = "TSGameDev/New Weapon Stats", order = 1)]
public class WeaponStatsBase : ScriptableObject
{
    [SerializeField] private WeaponData _WeaponData;
}
