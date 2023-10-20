using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        gameController.LogStringWithReturn(gameController.GetValidInteractVerb(gameController.interactableItems.examineDict, inputWords[0], inputWords[1]));
    }
}
