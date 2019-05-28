using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour {

    public RectTransform quitScreen;

	// Use this for initialization
	void Start ()
    {
        quitScreen.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        quitScreen.gameObject.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void DenyQuit()
    {
        quitScreen.gameObject.SetActive(false);
    }
}
