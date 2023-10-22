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

    // play keyboard sound
    private void Update()
    {
        // Check if the input field is currently selected/focused
        if (inputField.isFocused)
        {
            // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                // Play the sound
                audioPlayer.instance.play_audio_keyboard();
            }
        }
    }

    public void AcceptTextInput(string input)
    {
        input = input.ToLower();
        gameController.LogStringWithReturn(input);

        int deliPos = input.IndexOf(' ');
        if (deliPos == -1)
        {
            Debug.Log("Invalid action");
            return;
        }
        string[] inputWords = {input.Substring(0, deliPos), input.Substring(deliPos + 1, input.Length - deliPos - 1)};

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

        //play audio_keyboard when pressing enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
                // Play the sound
            audioPlayer.instance.play_audio_keyboard();
        }
    }
}
