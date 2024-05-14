using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //

    [Header("Events")]
    public GameEvent uniqueInteractionName;

    public void TriggerEvent()
    {
        uniqueInteractionName.Raise(this, null);
    }
}
