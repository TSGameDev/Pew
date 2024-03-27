using System;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.Netcode;

[Serializable]
public class Weapon : MonoBehaviour, IWeapon
{
    [Title("Shotting Settings")]
    [SerializeField] private WeaponStatsBase weaponData;
    
    private WeaponData _WeaponDataInstance;
    private float _CurrentShotTimer = 0f;

    [Space(10)]
    [Title("SFX Settings")]
    [SerializeField] private GameObject bulletHolePlane;
    [SerializeField] private ParticleSystem bulletVFX;
    [SerializeField] private AudioClip bulletSFX;

    private AudioSource _WeaponAudioSource;

    private void Start(){
        _WeaponAudioSource = GetComponent<AudioSource>();

        _WeaponDataInstance = new WeaponData(weaponData);
    }

    private void Update(){
        if (_CurrentShotTimer > 0)
        {
            _CurrentShotTimer -= 1 * Time.deltaTime;
        }
    }

    public void Fire(){
        if (_WeaponDataInstance.magazineAmmo > 0 && _CurrentShotTimer <= 0)
        {
            _WeaponDataInstance.magazineAmmo--;
            _CurrentShotTimer = _WeaponDataInstance.timeBetweenShots;
            Debug.Log($"Weapon Fired! \n Mag Ammo: {_WeaponDataInstance.magazineAmmo}");
        }
        else if (_CurrentShotTimer <= 0)
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

    [ServerRpc]
    private void Fire_ServerRPC(){
        
    }
}
