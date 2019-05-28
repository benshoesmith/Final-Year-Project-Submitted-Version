using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    
    public float radius = 6f;

    bool isInteracting = false;
    bool hasInteracted = false;
    Transform player;

    void Update()
    {
        // If interaction is called and hasn't been completed
        if (isInteracting && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            // If distance is less than radius
            if (distance <= radius)
            {
                // Call interaction
                Interact();
                // Set interacted bool to true
                hasInteracted = true;
            }
        }
    }

    // Can override this method in other interactable objects - it's meant to be overwritten
    public virtual void Interact()
    {
        Debug.Log("Interacting");
    }

    public void OnInteracting(Transform playerTransform)
    {
        isInteracting = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OffInteracting()
    {
        isInteracting = false;
        player = null;
        hasInteracted = false;
    }


    private void OnDrawGizmosSelected()
    {
        //Draw wire frame around object
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
