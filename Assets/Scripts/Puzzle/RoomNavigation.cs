using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    private GameController gameController;
    private Dictionary<string, Room> exitsDict = new Dictionary<string, Room>();

    private void Awake() {
        gameController = GetComponent<GameController>();
    }

    public void UnpackExitRoom()
    {
        foreach (Exit exit in currentRoom.exits)
        {
            exitsDict.Add(exit.keyString, exit.valueRoom);
            gameController.interactionDescriptions.Add(exit.exitDescription);
        }
    }

    public void ChangeRoom(string direction)
    {
        if (exitsDict.ContainsKey(direction))
        {
            currentRoom = exitsDict[direction];
            gameController.LogStringWithReturn("You go to the " + direction);
            gameController.DisplayRoomText();
        }
        else
        {
            gameController.LogStringWithReturn("There is no path in the " + direction);
        }
    }

    public void ClearExits()
    {
        exitsDict.Clear();
    }
}
