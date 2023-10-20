using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        gameController.roomNavigation.ChangeRoom(inputWords[1]);
    }
}
