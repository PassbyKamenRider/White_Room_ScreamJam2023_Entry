using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptions = new List<string>();
    public TextMeshProUGUI displayText;
    public InputAction[] inputActions;
    private List<string> actionLog = new List<string>();

    private void Awake() {
        roomNavigation = GetComponent<RoomNavigation>();
    }

    private void Start() {
        DisplayRoomText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog);

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        ClearInteraction();
        
        UnpackRoom();

        string combineText = roomNavigation.currentRoom.description + "\n\n" + string.Join("\n", interactionDescriptions);

        LogStringWithReturn(combineText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    private void ClearInteraction()
    {
        interactionDescriptions.Clear();
        roomNavigation.ClearExits();
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitRoom();
    }
}
