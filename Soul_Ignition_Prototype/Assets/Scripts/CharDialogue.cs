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
    public bool messagePlayed;
    public bool keyWasPressed;

    

    // TMP stuff
    public TextMeshProUGUI charFirstOne;
    //public TextMeshProUGUI charFirstTwo;

    [Header("Events")]
    public GameEvent onTextExhausted; // Once the dialogue has finished, start quest


    // Start is called before the first frame update
    void Start()
    {
        interactionScript = GetComponent<NPCInteract>();
        intScript = GetComponent<Interactable>();
        //charOneTextRend = false;
        messagePlayed = false;

        charFirstOne.text = initialMessage;
        textNumber = 0;

        //keyToAdvanceText = GetComponent<NPCInteract>().c_boundKey;
    }

    // Update is called once per frame
    void Update()
    {
        //keyWasPressed = false;
        //keyWasPressed = Input.GetKeyDown(keyToAdvanceText);

        //CharInteraction();
    }

    public void CharInteraction()
    {
        if (!messagePlayed)
        {
            if (textNumber >= charOneIntro.Length)
            {
                messagePlayed = true;
                ResetTextField();
            }
            if (textNumber < charOneIntro.Length)
            {
                charFirstOne.text = charOneIntro[textNumber];
                textNumber++;
            }
        }
    }

    private void ResetTextField()
    {
        charFirstOne.enabled = false;
    }

    public void CharOneQuestOne()
    {
        if (onTextExhausted)
        {

        }
    }
}
