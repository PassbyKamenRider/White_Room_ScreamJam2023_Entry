using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    public RawImage currentRoomImage;
    public Texture2D normalFridge;
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
            if (exitsDict[direction].image != null)
            {
                if (exitsDict[direction].roomName == "Fridge")
                {
                    Invoke("ImageChange", 0.2f);
                }
                currentRoomImage.texture = exitsDict[direction].image;
            }
            gameController.LogStringWithReturn("You go to the " + direction);
            gameController.DisplayRoomText();
        }
        else
        {
            gameController.LogStringWithReturn("There is no path in the " + direction);
        }
    }

    public void ImageChange()
    {
        currentRoomImage.texture = normalFridge;
    }

    public void ClearExits()
    {
        exitsDict.Clear();
    }
}
