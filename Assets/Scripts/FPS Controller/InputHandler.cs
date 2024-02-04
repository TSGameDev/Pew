using Unity.Netcode;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class InputHandler : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    private PlayerInputs _PlayerInputs;
    private CharacterControllerMotor _CharacterMotor;

    #endregion

    private void Awake(){
        _PlayerInputs = new PlayerInputs();
        _CharacterMotor = GetComponent<CharacterControllerMotor>();
    }

    private void OnEnable() {
        _PlayerInputs.Enable();
        _PlayerInputs.Gameplay.Enable();
        _PlayerInputs.UI.Disable();

        _PlayerInputs.Gameplay.Movement.performed += ctx => _CharacterMotor.MovementInput = ctx.ReadValue<Vector2>();
        _PlayerInputs.Gameplay.Movement.canceled += ctx => _CharacterMotor.MovementInput = Vector2.zero;
    }

    private void OnDisable() {
        _PlayerInputs.Disable();
        _PlayerInputs.Gameplay.Disable();
        _PlayerInputs.UI.Disable();
    }

}
