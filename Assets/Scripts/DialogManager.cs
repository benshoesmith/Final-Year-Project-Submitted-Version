using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public static DialogManager dialogManagerInstance;
    [HideInInspector] public List<string> dialogLinesList = new List<string>();

    [HideInInspector] public string npcName;
    public GameObject dialogPanel;

    int dialogIndex;

    Button continueBtn;
    [HideInInspector] Text dialogText, nameText;

    // Use this for initialization
    void Awake ()
    {
        // Link UI elements
        continueBtn = dialogPanel.transform.Find("ContinueBtn").GetComponent<Button>();
        dialogText = dialogPanel.transform.Find("DialogText").GetComponent<Text>();
        nameText = dialogPanel.transform.Find("NPCNamePanel").GetChild(0).GetComponent<Text>(); // Gtes first child of NPCNamePanel, which is the NPCNameText

        // On continue click, run continue function
        continueBtn.onClick.AddListener(delegate { Continue(); });

        // Disable dialog UI on awake
        dialogPanel.SetActive(false);

        // If there's another dialog manager instance running, destroy this one 
		if(dialogManagerInstance != null && dialogManagerInstance != this)
        {
            Destroy(gameObject);
        }
        // Else, set this as the instance
        else
        {
            dialogManagerInstance = this;
        }
	}
	
    public void AddDialog(string[] dialogLines, string npcName)
    {
        // Reset Dialog Index
        dialogIndex = 0;

        // Set number of dialog lines in the DL list to the length of the lines being passed
        dialogLinesList = new List<string>(dialogLines.Length);
        dialogLinesList.AddRange(dialogLines);
        this.npcName = npcName;

        SetUpDialog();
        Debug.Log(dialogLinesList.Count);
    }

    public void SetUpDialog()
    {
        // Show next dialog line from dialog line list
        dialogText.text = dialogLinesList[dialogIndex];
        // Set npc name text as npcName
        nameText.text = npcName;
        // Activate dialog panel
        dialogPanel.SetActive(true);
        // Enable cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continue()
    {
        Debug.Log("Continue Pressed");
        // If dialog index is less than the total lines
        if (dialogIndex < dialogLinesList.Count - 1)
        {
            // Increase index
            dialogIndex++;
            // Set dialog UI text to the next line in the list
            dialogText.text = dialogLinesList[dialogIndex];
        }
        else
        {
            // If no more dialog, disable dialog panel
            dialogPanel.SetActive(false);
            // Disable cursor
           // Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
    }
}
