using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

    public Interactable currentInteraction;
    public CharacterController characterController;
    Camera camera;

	// Use this for initialization
	void Start ()
    {
        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If E is pressed
		if(Input.GetKeyDown(KeyCode.E))
        {
            // Declare new ray at centre of camera
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                // Get interactable component from collided object
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                // If there was interactable component
                if(interactable != null)
                {
                    // Start interaction
                    StartInteraction(interactable);
                }
            }
        }

        else
        {
            EndInteraction();
        }
	}

    void StartInteraction(Interactable newInteraction)
    {
        // If this interaction is differnt to last interaction
        if(newInteraction != currentInteraction)
        {
            // If last interaction isn't null
            if(currentInteraction != null)
            {
                // Disable that interaction
                currentInteraction.OffInteracting();
            }
            // Make new interaction the current one
            currentInteraction = newInteraction;
        }
        // Call oninteraction with player transform
        newInteraction.OnInteracting(transform);

    }

    void EndInteraction()
    {
        // If current interaction is enabled
        if(currentInteraction != null)
        {
            // Call Offinteraction
            currentInteraction.OffInteracting();
        }
        // Disable current interaction
        currentInteraction = null;
    }

    public void FreezeMovement(bool freeze)
    {
        if(freeze)
        {
            // Disable character controller
            characterController.enabled = false;
            characterController.GetComponent<FirstPersonController>().enabled = false;
        }
        else if(!freeze)
        {
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;
        }

    }

}
