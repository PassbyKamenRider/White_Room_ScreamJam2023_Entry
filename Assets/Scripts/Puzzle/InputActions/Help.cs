using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Help")]
public class Help : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        if (inputWords.Length < 2)
        {
            return;
        }

        if (inputWords[1] == "1")
        {
            gameController.LogStringWithReturn("Examine\nYou can use <b>Examine Around</b> to check interactables inside a room. You can also use <b>Examine <object></b> to take a close look at objects or any interactables inside a particular object.");
            gameController.DisplayLoggedText();
        }
        else if (inputWords[1] == "2")
        {
            // go
            gameController.LogStringWithReturn("Go\nYou can go to other rooms or get closer to a particular interactables to get items inside something by the command <b>Go <object></b>.");
            gameController.DisplayLoggedText();
        }
        else if (inputWords[1] == "3")
        {
            // take
            gameController.LogStringWithReturn("Take\nYou can pick up an item in your current room by the command <b>Take <object></b>.");
            gameController.DisplayLoggedText();
        }
        else if (inputWords[1] == "4")
        {
            // use
            gameController.LogStringWithReturn("Use\nYou can use a particular object in your inventory by the command <b>Use <object></b>. Note that some objects can only be useful when you use them in the correct place.");
            gameController.DisplayLoggedText();
        }
        else
        {
            gameController.LogStringWithReturn("This help page doesn't exist.");
            gameController.DisplayLoggedText();
        }
    }
}