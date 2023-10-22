using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Take")]
public class Take : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        if (inputWords.Length < 2)
        {
            return;
        }
        Dictionary<string, string> TakeDict = gameController.interactableItems.Take(inputWords);

        if (TakeDict != null)
        {
            gameController.LogStringWithReturn(gameController.GetValidInteractVerb(TakeDict, inputWords[0], inputWords[1]));
        }
    }
}