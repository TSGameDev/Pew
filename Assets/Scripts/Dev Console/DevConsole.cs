using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DevConsole : MonoBehaviour
{
    [SerializeField] private GameObject devConsole;
    [SerializeField] private TMP_InputField devInput;
    [SerializeField] private TextMeshProUGUI textField;

    public static DevConsole Instance;
    private void Awake() {
        if(Instance == null){
            Instance = this;
        } else{ Destroy(this); }
    }

    private void EnterCommand(string call){

    }
    public void DisplayDebug(string _Message){
        textField.text += $"\n {_Message}";
    }

    public void ToggleConsole(){
        devConsole.SetActive(!devConsole.activeInHierarchy);
        if(devConsole.activeInHierarchy){
            devInput.onSubmit.AddListener(EnterCommand);
        }else{
            devInput.onSubmit.RemoveListener(EnterCommand);
        }
    }
}
