using Unity.Netcode;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Private Variables

    private PlayerInputs _PlayerInputs;
    private CharacterControllerMotor _CharacterMotor;
    private CharacterRotor _CharacterRotor;

    #endregion

    private void Awake(){
        _PlayerInputs = new PlayerInputs();
        _CharacterMotor = GetComponent<CharacterControllerMotor>();
        _CharacterRotor = GetComponent<CharacterRotor>();
    }

    private void OnEnable() {
        _PlayerInputs.Enable();
        _PlayerInputs.Gameplay.Enable();
        _PlayerInputs.UI.Disable();

        _PlayerInputs.Gameplay.Movement.performed += ctx => _CharacterMotor.MovementInput = ctx.ReadValue<Vector2>();
        _PlayerInputs.Gameplay.Movement.canceled += ctx => _CharacterMotor.MovementInput = Vector2.zero;

        _PlayerInputs.Gameplay.MouseDelta.performed += ctx => _CharacterRotor.MouseDelta = ctx.ReadValue<Vector2>();
        _PlayerInputs.Gameplay.MouseDelta.canceled += ctx => _CharacterRotor.MouseDelta = Vector2.zero;
    }

    private void OnDisable() {
        _PlayerInputs.Disable();
        _PlayerInputs.Gameplay.Disable();
        _PlayerInputs.UI.Disable();
    }

}
