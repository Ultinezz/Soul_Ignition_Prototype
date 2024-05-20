using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharDialogue : MonoBehaviour
{
    public NPCInteract interactionScript; // The NPCInteract script
    public Interactable intScript; // The Interactable script
    public Renderer charOneTextRend; // NPC 1's mesh renderer

    public bool rayInteract; // Has the player's interaction mode been activated (by ray hitting NPC)

    // TMP stuff
    public TextMeshProUGUI charFirstOne;
    //public TMP_Text charFirstTwo;


    // Start is called before the first frame update
    void Start()
    {
        interactionScript = GetComponent<NPCInteract>();
        intScript = GetComponent<Interactable>();
        //charOneTextRend = 


        //charFirstOne.text = "help me pls ^_^"; // The first line of text on NPC 1's text box
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CharInteraction()
    {
        //controllerScript.InteractionMode();       // OUTPUT function for NPC interaction goes here

        // if charOne, do the one dialogue progress function, if two, then do the two function etc


    }

    public void OneDialogueProgress()
    {

    }
}
