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

    private bool _MenuActive;

    #endregion

    private void Awake(){
        _PlayerInputs = new PlayerInputs();
        _CharacterMotor = GetComponent<CharacterControllerMotor>();
        _CharacterRotor = GetComponent<CharacterRotor>();
    }

    private void OnEnable() {
        _PlayerInputs.Enable();
        _PlayerInputs.Gameplay.Enable();
        _PlayerInputs.GlobalActions.Enable();
        _PlayerInputs.UI.Disable();

        _PlayerInputs.Gameplay.Movement.performed += ctx => _CharacterMotor.MovementInput = ctx.ReadValue<Vector2>();
        _PlayerInputs.Gameplay.Movement.canceled += ctx => _CharacterMotor.MovementInput = Vector2.zero;

        _PlayerInputs.Gameplay.MouseDelta.performed += ctx => _CharacterRotor.MouseDelta = ctx.ReadValue<Vector2>();
        _PlayerInputs.Gameplay.MouseDelta.canceled += ctx => _CharacterRotor.MouseDelta = Vector2.zero;

        _PlayerInputs.GlobalActions.DevConsole.performed += ctx => DevConsole.Instance.ToggleConsole();

        _PlayerInputs.GlobalActions.MenuToggle.performed += ctx => {if(!_MenuActive){ EnableUIControls(); } else { DisableUIControls(); }};
    }

    private void OnDisable() {
        _PlayerInputs.Disable();
        _PlayerInputs.Gameplay.Disable();
         _PlayerInputs.GlobalActions.Disable();
        _PlayerInputs.UI.Disable();
    }

    private void EnableUIControls(){
        _PlayerInputs.Gameplay.Disable();
        _PlayerInputs.UI.Enable();
        Cursor.lockState = CursorLockMode.None;
        _MenuActive = true;
    }

    private void DisableUIControls(){
        _PlayerInputs.Gameplay.Enable();
        _PlayerInputs.UI.Disable();
        Cursor.lockState = CursorLockMode.Locked;
        _MenuActive = false;
    }
}
