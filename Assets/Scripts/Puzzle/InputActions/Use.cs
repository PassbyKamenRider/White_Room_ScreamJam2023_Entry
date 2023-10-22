using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        if (inputWords.Length < 2)
        {
            return;
        }

        if (inputWords[1] == "flashlight")
        {
            if (!gameController.interactableItems.nounsInInventory.Contains("battery"))
            {
                gameController.LogStringWithReturn("The flashlight doesn't have <b>batteries</b>, maybe I should find some.");
                return;
            }
        }

        gameController.interactableItems.Use(inputWords);
    }
}