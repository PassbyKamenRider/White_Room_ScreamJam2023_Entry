using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    [TextArea] public string description;
    public string roomName;
    public Exit[] exits;
    public InteractableObject[] interactableObjects;

    public InteractableObject FindObjectByName(string noun)
    {
        foreach (InteractableObject obj in interactableObjects)
        {
            if (obj.noun == noun)
            {
                return obj;
            }
        }
        return null;
    }
}
