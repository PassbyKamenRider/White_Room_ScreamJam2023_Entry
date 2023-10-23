using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptions = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;
    public TextMeshProUGUI displayText;
    public InputAction[] inputActions;
    private List<string> actionLog = new List<string>();

    // hard coded for endings
    public GameObject endScreen;
    public GameObject puzzleScreen;
    public GameObject endAPlate;
    public GameObject banana;

    private void Awake() {
        roomNavigation = GetComponent<RoomNavigation>();
        interactableItems = GetComponent<InteractableItems>();
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
        ClearCollections();
        
        UnpackRoom();

        //string combineText = roomNavigation.currentRoom.description + "\n\n" + string.Join("\n", interactionDescriptions);

        LogStringWithReturn(roomNavigation.currentRoom.description);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    public string GetValidInteractVerb(Dictionary<string, string> verbDict, string verb, string noun)
    {
        if (verbDict.ContainsKey(noun))
        {
            return verbDict[noun];
        }

        return "You can't " + verb + " " + noun;
    }

    private void InteractableObjectsInRoom(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjects.Length; i++)
        {
            string descriptionAvailableItem = interactableItems.GetAvailableItem(currentRoom, i);
            if (descriptionAvailableItem != null)
            {
                interactionDescriptions.Add(descriptionAvailableItem);
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjects[i];
            foreach (ItemInteraction itemInteraction in interactableInRoom.itemInteractions)
            {
                if (itemInteraction.inputAction.keyWord == "examine")
                {
                    interactableItems.examineDict.Add(interactableInRoom.noun, itemInteraction.textResponse);
                }
                if (itemInteraction.inputAction.keyWord == "take")
                {
                    interactableItems.takeDict.Add(interactableInRoom.noun, itemInteraction.textResponse);
                }
            }
        }
    }

    private void ClearCollections()
    {
        interactionDescriptions.Clear();
        roomNavigation.ClearExits();
        interactableItems.ClearCollection();
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitRoom();
        InteractableObjectsInRoom(roomNavigation.currentRoom);
    }
}
