using UnityEngine;

public class WeaponController : MonoBehaviour
{
    #region Public Variables
    public Weapon CurrentWeapon;
    #endregion

    #region Private Variables
    private IWeapon _CurrentIWeapon;
    private WeaponData _CurrentWeaponData;
    #endregion

    private void Awake()
    {
        _CurrentIWeapon = CurrentWeapon.GetComponent<IWeapon>();
        _CurrentWeaponData = _CurrentIWeapon.WeaponDataInstance;
    }

    public void FireCurrentWeapon(){
        _CurrentIWeapon.Fire();
    }

    public void ReloadCurrentWeapon(){
        _CurrentIWeapon.Reload();
    }
}
