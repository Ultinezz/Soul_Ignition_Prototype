using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject charOneText; // The dialogue text of NPC 1
    public CharDialogue charDialogue; // Script that progresses NPC dialogue

    public void CharacterInteract()
    {
        charDialogue.CharInteraction(); // If player has interacted with NPC, use CharDialogue script to change text
    }
}
