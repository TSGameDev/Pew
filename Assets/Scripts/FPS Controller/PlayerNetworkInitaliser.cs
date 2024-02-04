using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkInitaliser : NetworkBehaviour 
{
    #region Public Variables

    #endregion

    #region Private Variables

    [SerializeField] private GameObject localVisuals;
    [SerializeField] private GameObject clientVisuals;

    #endregion

    public override void OnNetworkSpawn(){
        if(IsOwner){
            localVisuals.SetActive(true);
            clientVisuals.SetActive(false);
        }
        else{
            localVisuals.SetActive(false);
            clientVisuals.SetActive(true);
        }
    }

}
