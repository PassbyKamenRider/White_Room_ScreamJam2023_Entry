using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Wakeup")]
public class Wakeup : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        if (gameController.roomNavigation.currentRoom.roomName == "EndB" && inputWords[1] == "up")
        {
            gameController.puzzleScreen.SetActive(false);
            gameController.endBScreen.SetActive(true);
        }
    }
}