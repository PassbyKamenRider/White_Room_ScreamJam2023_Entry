using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/ChangeRoom")]
public class ChangeRoomResponse : ActionResponse
{
    public Room changeTarget;
    public override bool DoActionResponse(GameController gameController)
    {
        if (gameController.roomNavigation.currentRoom.roomName == requiredString)
        {
            gameController.roomNavigation.currentRoom = changeTarget;
            gameController.roomNavigation.currentRoomImage.texture = changeTarget.image;
            gameController.DisplayRoomText();
            return true;
        }

        return false;
    }
}
