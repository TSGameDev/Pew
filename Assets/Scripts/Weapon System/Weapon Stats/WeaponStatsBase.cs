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
    public float timeBetweenShots;
    public int magazineSize;
    public int magazineAmmo;
    public int stockpileSize;
    public int stockpileAmmo;
    public int damage;
    public float headShotMultiplier;
    public float weakShotMultiplier;

    public WeaponData(string weaponName,
        FireMode fireMode = FireMode.Bolt,
        float timeBetweenShots = 0.5f,
        int magazineSize = 1,
        int magazineAmmo = 1,
        int stockpileSize = 2,
        int stockpileAmmo = 2,
        int damage = 1,
        float headShotMultiplier = 1.00f,
        float weakShotMultiplier = 1.00f)
    {
        this.weaponName = weaponName;
        this.fireMode = fireMode;
        this.timeBetweenShots = timeBetweenShots;
        this.magazineAmmo = magazineAmmo;
        this.magazineSize = magazineSize;
        this.stockpileSize = stockpileSize;
        this.stockpileAmmo = stockpileAmmo;
        this.damage = damage;
        this.headShotMultiplier = headShotMultiplier;
        this.weakShotMultiplier = weakShotMultiplier;
    }

    public WeaponData(WeaponStatsBase weaponDataCopy)
    {
        weaponName = weaponDataCopy.weaponData.weaponName;
        fireMode = weaponDataCopy.weaponData.fireMode;
        timeBetweenShots = weaponDataCopy.weaponData.timeBetweenShots;
        magazineAmmo = weaponDataCopy.weaponData.magazineAmmo;
        magazineSize = weaponDataCopy.weaponData.magazineSize;
        stockpileSize = weaponDataCopy.weaponData.stockpileSize;
        stockpileAmmo = weaponDataCopy.weaponData.stockpileAmmo;
        damage = weaponDataCopy.weaponData.damage;
        headShotMultiplier = weaponDataCopy.weaponData.headShotMultiplier;
        weakShotMultiplier = weaponDataCopy.weaponData.weakShotMultiplier;
    }
}

[CreateAssetMenu(fileName = "New Weapon Stats", menuName = "TSGameDev/New Weapon Stats", order = 1)]
public class WeaponStatsBase : ScriptableObject
{
    public WeaponData weaponData;

}
