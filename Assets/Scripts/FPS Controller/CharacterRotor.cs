using UnityEngine;
using Unity.Netcode;

public class CharacterRotor : NetworkBehaviour
{
    [SerializeField] private GameObject localCameraHolder;
    [SerializeField] private GameObject clientWeaponHolder;
    [SerializeField] private float horizontalSensativity = 1;
    [SerializeField] private float verticalSensativity = 1;

    private NetworkVariable<float> _CameraRotationEulerX = new();

    private NetworkVariable<Vector2> _MouseDelta =  new NetworkVariable<Vector2>(writePerm: NetworkVariableWritePermission.Owner);
    public Vector2 MouseDelta{
        private get => _MouseDelta.Value;
        set{
            if(IsOwner)
                _MouseDelta.Value = value;
        }
    }

    public override void OnNetworkSpawn()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        SyncRotationToNetwork();

        if(!IsOwner) return;

        if(MouseDelta.magnitude > 0){
            PerformCharacterRotation_ServerRpc();
        }
    }

    private void SyncRotationToNetwork(){
        if(IsOwner)
            localCameraHolder.transform.eulerAngles = new Vector3(_CameraRotationEulerX.Value, localCameraHolder.transform.eulerAngles.y, localCameraHolder.transform.eulerAngles.z);
        else
            clientWeaponHolder.transform.eulerAngles = new Vector3(_CameraRotationEulerX.Value, clientWeaponHolder.transform.eulerAngles.y, clientWeaponHolder.transform.eulerAngles.z);

    }

    [ServerRpc]
    private void PerformCharacterRotation_ServerRpc(){
        //Cache network synced input data
        float _MouseX = MouseDelta.x;
        float _MouseY = MouseDelta.y;

        //Calculate up-down rotations
        _CameraRotationEulerX.Value -= _MouseY * verticalSensativity;
        _CameraRotationEulerX.Value = Mathf.Clamp(_CameraRotationEulerX.Value, -30, 50);

        //Apply horizontal rotations to network transform for character
        gameObject.transform.eulerAngles += new Vector3(0, _MouseX * horizontalSensativity, 0);
    }
}
