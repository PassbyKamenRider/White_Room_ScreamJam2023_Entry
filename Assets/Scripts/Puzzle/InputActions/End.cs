using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/End")]
public class End : InputAction
{
    public override void RespondToInput(GameController gameController, string[] inputWords)
    {
        if (gameController.roomNavigation.currentRoom.roomName == "EndA" && inputWords[1] == "game")
        {
            // Bad end music here
            gameController.puzzleScreen.SetActive(false);
            gameController.endScreen.SetActive(true);
            gameController.endAPlate.SetActive(true);

            audioPlayer.instance.play_audio_music_bad();
        }
    }
}