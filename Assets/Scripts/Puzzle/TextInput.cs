using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;
    private GameController gameController;

    private void Awake() {
        gameController = GetComponent<GameController>();
    }

    public void AcceptTextInput(string input)
    {
        input = input.ToLower();
        gameController.LogStringWithReturn(input);

        char[] delimeters = {' '};
        string[] inputWords = input.Split(delimeters);

        foreach(InputAction inputAction in gameController.inputActions)
        {
            // REMEMBER: HANDLE ILEGAL CASES!!!!!!!
            if (inputAction.keyWord == inputWords[0])
            {
                inputAction.RespondToInput(gameController, inputWords);
            }
        }

        gameController.DisplayLoggedText();
        inputField.text = "";
    }
}
