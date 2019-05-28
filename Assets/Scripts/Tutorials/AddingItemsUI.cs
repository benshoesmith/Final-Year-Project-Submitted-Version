using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingItemsUI : MonoBehaviour {

    public GameObject infoPanels;
    [HideInInspector]
    public GameObject currentPanel;
    [HideInInspector]
    public GameObject nextPanel;
    [HideInInspector]
    public int index;
    public int numOfSlides;

    private void Start()
    {
        index = 0;
        currentPanel = infoPanels.transform.GetChild(index).gameObject;
    }

    public void OnNextBtn()
    {
        index++;
        if (index >numOfSlides - 1)
        {
            index = 0;
        }
        currentPanel.SetActive(false);
        infoPanels.transform.GetChild(index).gameObject.SetActive(true);
        currentPanel = infoPanels.transform.GetChild(index).gameObject;
    }

    public void OnPrevBtn()
    {
        index--;
        if (index <0)
        {
            index = numOfSlides - 1;
        }
        currentPanel.SetActive(false);
        infoPanels.transform.GetChild(index).gameObject.SetActive(true);
        currentPanel = infoPanels.transform.GetChild(index).gameObject;
    }
}
