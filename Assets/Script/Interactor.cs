using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Transform pov;
    private float interactionRange = 7f;
    private void Start()
    {
        pov = Camera.main.transform;
    }
    private void Update()
    {
        if(Physics.Raycast(pov.position, pov.forward*interactionRange, out RaycastHit hit))
        {
            Debug.DrawRay(pov.position, pov.forward * interactionRange, Color.red);
            if(InputHandler.HasInteracted && hit.transform.TryGetComponent(out Interactor interactable))
            {
                interactable.Interact();
            }
        }
    }

    public void Interact()
    {
       
    }
}
