using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveWeapon{
    Primary,
    Secondary
}

[CreateAssetMenu(fileName = "New Player Loadout", menuName = "New Player Loadout", order = 0)]
public class PlayerLoadout : ScriptableObject {
    [SerializeField] private Weapon primaryWeapon;
    public Weapon PrimaryWeapon{
        get{
            return primaryWeapon;
        }

        set{
            primaryWeapon = value;
        }
    }

    public IWeapon PrimaryWeaponInterface{
        get{
            return primaryWeapon.GetComponent<IWeapon>();
        }
    }

    [SerializeField] private Weapon secondaryWeapon;
    public Weapon SecondaryWeapon{
        get{
            return secondaryWeapon;
        }

        set{
            secondaryWeapon = value;
        }
    }

    public IWeapon SecondaryWeaponInterface{
        get{
            return secondaryWeapon.GetComponent<IWeapon>();
        }
    }

    [SerializeField] private ActiveWeapon activeWeapon;
    public ActiveWeapon ActiveWeapon{
        get{
            return activeWeapon;
        }

        set{
            activeWeapon = value;
        }
    }

    public IWeapon GetActiveWeaponInterface(){
        switch(activeWeapon){
            case ActiveWeapon.Primary:
                return PrimaryWeaponInterface;
            case ActiveWeapon.Secondary:
                return SecondaryWeaponInterface;
        }
        Debug.LogError("Active Weapon Is Null");
        return null;
    }
}
