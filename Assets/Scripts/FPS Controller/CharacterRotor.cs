using UnityEngine;
using Unity.Netcode;

public class CharacterRotor : NetworkBehaviour
{
    [SerializeField] private GameObject _CameraHolder;
    [SerializeField] private float horizontalSensativity = 1;
    [SerializeField] private float verticalSensativity = 1;

    private float _CameraRotationEulerX = 0f;

    public Vector2 MouseDelta{
        private get => _MouseDelta.Value;
        set{
            if(IsOwner)
                _MouseDelta.Value = value;
        }
    }
    private NetworkVariable<Vector2> _MouseDelta =  new NetworkVariable<Vector2>();

    public override void OnNetworkSpawn()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        if(!IsOwner) return;

        if(MouseDelta.magnitude > 0){
            RequestCharacterRotation();
        }
    }

    private void RequestCharacterRotation(){
        float _MouseX = MouseDelta.x;
        float _MouseY = MouseDelta.y;

        gameObject.transform.eulerAngles += new Vector3(0, _MouseX * horizontalSensativity, 0);
        _CameraRotationEulerX -= _MouseY * verticalSensativity;
        _CameraRotationEulerX = Mathf.Clamp(_CameraRotationEulerX, -30, 50);
        _CameraHolder.transform.eulerAngles = new Vector3(_CameraRotationEulerX, _CameraHolder.transform.eulerAngles.y, _CameraHolder.transform.eulerAngles.z);
    }

    [ServerRpc]
    private void PerformCharacterRotation_ServerRpc(){

    }
}
