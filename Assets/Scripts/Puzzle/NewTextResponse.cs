using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/NewText")]
public class NewTextResponse : ActionResponse
{
    public string newText;
    public override bool DoActionResponse(GameController gameController)
    {
        if (gameController.roomNavigation.currentRoom.roomName == requiredString)
        {
            gameController.LogStringWithReturn(newText);
            return true;
        }

        return false;
    }
}
