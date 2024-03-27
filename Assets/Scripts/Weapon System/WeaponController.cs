using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private PlayerLoadout playerLoadout;

    public void FireCurrentWeapon(){
        playerLoadout.GetActiveWeaponInterface().Fire();
    }

    public void ReloadCurrentWeapon(){
        playerLoadout.GetActiveWeaponInterface().Reload();
    }
}
