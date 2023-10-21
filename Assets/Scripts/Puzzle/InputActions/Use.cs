using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        gameController.interactableItems.Use(inputWords);
    }
}