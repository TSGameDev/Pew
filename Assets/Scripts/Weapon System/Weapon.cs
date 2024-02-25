using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Weapon : MonoBehaviour, IWeapon
{

    #region Public Variables

    [SerializeField] private WeaponStatsBase weaponData;

    WeaponData IWeapon.WeaponDataInstance { get => _WeaponDataInstance; set => _WeaponDataInstance = value; }
    #endregion

    #region Private Variables

    private WeaponData _WeaponDataInstance;

    private float currentShotTimer = 0f;
    #endregion

    private void Start(){
        _WeaponDataInstance = new WeaponData(weaponData);
    }

    private void Update(){
        if (currentShotTimer > 0)
        {
            currentShotTimer -= 1 * Time.deltaTime;
        }
    }

    public void Fire(){
        if (_WeaponDataInstance.magazineAmmo > 0 && currentShotTimer <= 0)
        {
            _WeaponDataInstance.magazineAmmo--;
            currentShotTimer = _WeaponDataInstance.timeBetweenShots;
            Debug.Log($"Weapon Fired! \n Mag Ammo: {_WeaponDataInstance.magazineAmmo}");
        }
        else if (currentShotTimer <= 0)
        {
            Debug.Log("Weapon Out Of Ammo! RELOADING!");
            Reload();
        }
    }

    public void Reload(){
        _WeaponDataInstance.stockpileAmmo -= _WeaponDataInstance.magazineSize - _WeaponDataInstance.magazineAmmo;
        _WeaponDataInstance.magazineAmmo = _WeaponDataInstance.magazineSize;
        Debug.Log($"Weapon Reloaded! \n Mag Ammo: {_WeaponDataInstance.magazineAmmo} \n Stockpile Ammo: {_WeaponDataInstance.stockpileAmmo} " +
            $"\n  Mag Size: {_WeaponDataInstance.magazineSize} \n Stockpile Size: {_WeaponDataInstance.stockpileSize}");
    }
}
