using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public static IInteractable selected;

    public void Interact();

}
