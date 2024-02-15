using Unity.Netcode;
using UnityEngine;

public class CharacterControllerMotor : NetworkBehaviour
{
    #region Public Variables
    public Vector2 MovementInput{
        private get => _MovementInput.Value;
        set {
            if(IsOwner)
                _MovementInput.Value = value;
        }
    }

    #endregion

    #region Private Variables
    [SerializeField] private float Speed = 5;

    private NetworkVariable<Vector2> _MovementInput = new NetworkVariable<Vector2>(writePerm: NetworkVariableWritePermission.Owner);
    private CharacterController _CharacterController;

    #endregion

    public override void OnNetworkSpawn(){
        _CharacterController = GetComponent<CharacterController>();
    }

    private void Update() {
        if(!IsOwner) return;

        if(MovementInput.magnitude > 0){
            PlayerMovementServerRpc(Time.deltaTime);
            DevConsole.Instance.DisplayDebug($"This is a test message {MovementInput.magnitude}");
        }
    }

    [ServerRpc]
    private void PlayerMovementServerRpc(float clientDeltaTime)
    {
        Vector3 forwardMovement = MovementInput.y * Speed * clientDeltaTime * transform.forward;
        Vector3 rightMovement = MovementInput.x * Speed * clientDeltaTime * transform.right;
        _CharacterController.Move(forwardMovement + rightMovement);
    }

}
