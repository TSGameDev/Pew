using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ClientDebugger : MonoBehaviour
{
    public static ClientDebugger instance;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
        DontDestroyOnLoad(instance);

    }

    [ServerRpc]
    public void ClientDebug_ServerRpc(ulong _ClientID, string _Message){
        Debug.Log($"Client {_ClientID} sent the message: \n{_Message}");
        ClientDebug_ClientRpc(_ClientID, _Message);
    }

    [ClientRpc]
    public void ClientDebug_ClientRpc(ulong _ClientID, string _Message){
        Debug.Log($"Client {_ClientID} sent the message: \n{_Message}");
    }
}
