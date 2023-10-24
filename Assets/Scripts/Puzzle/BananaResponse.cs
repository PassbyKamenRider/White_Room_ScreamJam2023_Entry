using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/ActionResponses/Banana")]
public class BananaResponse : ActionResponse
{
    public Room changeTarget;
    public override bool DoActionResponse(GameController gameController)
    {
        gameController.banana.SetActive(true);
        return true;
    }
}
