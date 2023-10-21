using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItems = new List<InteractableObject>();
    public Dictionary<string, string> examineDict = new Dictionary<string, string>();
    public Dictionary<string, string> takeDict = new Dictionary<string, string>();
    [HideInInspector] public List<string> nounsInRoom = new List<string>();
    private Dictionary<string, ActionResponse> useDict = new Dictionary<string, ActionResponse>();
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

    public void FillUseDictionary()
    {
        foreach (string nounInInventory in nounsInInventory)
        {
            InteractableObject interactableObjectInInventory = getUsableInteractable(nounInInventory);

            if (interactableObjectInInventory == null)
            {
                continue;
            }

            foreach (ItemInteraction interaction in interactableObjectInInventory.itemInteractions)
            {
                if (interaction.actionResponse == null)
                {
                    continue;
                }

                if (!useDict.ContainsKey(nounInInventory))
                {
                    useDict.Add(nounInInventory, interaction.actionResponse);
                }
            }
        }
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
            FillUseDictionary();
            nounsInRoom.Remove(noun);
            return takeDict;
        }
        else
        {
            gameController.LogStringWithReturn("There is no " + noun + " in the room.");
            return null;
        }
    }

    public void Use(string[] inputWords)
    {
        string nounToUse = inputWords[1];

        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDict.ContainsKey(nounToUse))
            {
                bool actionResult = useDict[nounToUse].DoActionResponse(gameController);

                if (!actionResult)
                {
                    gameController.LogStringWithReturn("Nothing happens.");
                }
            }
            else
            {
                gameController.LogStringWithReturn("You can't use " + nounToUse + ".");
            }
        }
        else
        {
            gameController.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use.");
        }
    }

    private InteractableObject getUsableInteractable(string noun)
    {
        foreach (InteractableObject obj in usableItems)
        {
            if (obj.noun == noun)
            {
                return obj;
            }
        }

        return null;
    }
}
