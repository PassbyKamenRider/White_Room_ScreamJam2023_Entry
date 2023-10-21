using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInteraction
{
    public InputAction inputAction;
    [TextArea]
    public string textResponse;
    public ActionResponse actionResponse;
}
