using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        if (inputWords.Length < 2)
        {
            return;
        }

        // SOME HARD CODE BECAUSE NO TIME LEFT AHHHHHHHHHHHHH
        if (inputWords[1] == "couch" && !gameController.interactableItems.nounsInRoom.Contains("battery"))
        {
            gameController.LogStringWithReturn("It's just a normal couch.");
            return;
        }
        gameController.LogStringWithReturn(gameController.GetValidInteractVerb(gameController.interactableItems.examineDict, inputWords[0], inputWords[1]));
    }
}
