using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : Interactable { // This script is derived from the interactable script - allows use of functions from here

    public string[] dialog__SizeIsNumOfSpeechLines__ElementIsEachLine;
    public string npcName;

	public override void Interact() // This overrides the interactable "Interact" fucntion
    {
        // Add Dialog
        DialogManager.dialogManagerInstance.AddDialog(dialog__SizeIsNumOfSpeechLines__ElementIsEachLine, npcName);

        // Give Quest


        Debug.Log("Interact with NPC");
    }
}
