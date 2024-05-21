using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class CharDialogue : MonoBehaviour
{
    public NPCInteract interactionScript; // The NPCInteract script
    public Interactable intScript; // The Interactable script
    public Renderer charOneTextRend; // NPC 1's mesh renderer

    public string initialMessage;
    public string[] charOneIntro;
    public KeyCode keyToAdvanceText;
    private int textNumber;
    private bool messagePlayed;
    private bool keyWasPressed;


    // TMP stuff
    public TextMeshProUGUI charFirstOne;
    //public TextMeshProUGUI charFirstTwo;




    // Start is called before the first frame update
    void Start()
    {
        interactionScript = GetComponent<NPCInteract>();
        intScript = GetComponent<Interactable>();
        //charOneTextRend = false;

        charFirstOne.text = initialMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharInteraction()
    {
        // if charOne, do the one dialogue progress function, if two, then do the two function etc

        //charFirstOne.SetText("line two test");
        //charFirstOne.SetText("line THREE test");


    }

    public void OneDialogueProgress()
    {

    }
}
