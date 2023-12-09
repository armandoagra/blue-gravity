using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float lookRange;
    private PlayerMovement playerMovement;

    public static Action OnToggleInventory;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        HandleInteraction();
        HandleInventory(); // Maybe HandleWindows and deal with all shortcut inputs for windows?
    }

    private void HandleInteraction()
    {
        Vector3 lookDirection = playerMovement.lookDirection;
        Debug.DrawRay(transform.position + lookDirection, lookDirection);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + lookDirection, lookDirection);
        if (hits.Length > 0)
        {
            foreach (RaycastHit2D c in hits)
            {
                if (c.collider.TryGetComponent(out IInteractable interactable))
                {
                    IInteractable.selected = interactable;
                    break;
                }
            }
        }
        else
        {
            IInteractable.selected = null;
        }

        if (Input.GetKeyDown(KeyCode.E) && IInteractable.selected != null)
        {
            IInteractable.selected.Interact();
        }
    }

    private void HandleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnToggleInventory?.Invoke();
        }
    }
}
