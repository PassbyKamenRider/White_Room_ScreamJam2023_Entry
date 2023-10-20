using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string, string> examineDict = new Dictionary<string, string>();
    public Dictionary<string, string> takeDict = new Dictionary<string, string>();
    [HideInInspector] public List<string> nounsInRoom = new List<string>();
    private List<string> nounsInInventory = new List<string>();
    private GameController gameController;

    private void Awake() {
        gameController = GetComponent<GameController>();
    }

    public string GetAvailableItem(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjects[i];

        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }

        return null;
    }

    public void ClearCollection()
    {
        examineDict.Clear();
        takeDict.Clear();
        nounsInRoom.Clear();
    }

    public Dictionary<string, string> Take(string[] inputWords)
    {
        string noun = inputWords[1];

        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            nounsInRoom.Remove(noun);
            return takeDict;
        }
        else
        {
            gameController.LogStringWithReturn("There is no " + noun + " in the room.");
            return null;
        }
    }
}
