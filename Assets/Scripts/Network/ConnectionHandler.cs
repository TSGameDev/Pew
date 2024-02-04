using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ConnectionHandler : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    [SerializeField] private GameObject buttonHolder;
    [SerializeField] private TextMeshProUGUI connectionMode;

    #endregion

    public void OnStartHost(){
        NetworkManager.Singleton.StartHost();
        OnConnection();
    }
    public void OnStartClient(){
        NetworkManager.Singleton.StartClient();
        OnConnection();
    }
    public void OnStartServer(){
        NetworkManager.Singleton.StartServer();
        OnConnection();
    }

    private void OnConnection() {
        buttonHolder.SetActive(false);

        string connectionType = NetworkManager.Singleton.IsHost ? "Connection Mode: Host" : NetworkManager.Singleton.IsServer ? "Connection Mode: Server" : "Connection Mode: Client";
        connectionMode.text = $"Transport Mode: {NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name} \n Mode: {connectionType}";
    }
}
