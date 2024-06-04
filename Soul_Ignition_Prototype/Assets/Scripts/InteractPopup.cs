using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPopup : MonoBehaviour
{
    public string initialMessage; // The text that will show up
    public string[] popupTexts; // The amount of rounds of texts the player has to click through
    public KeyCode keyToAdvanceText; // E
    private int textNumber; // The round of text the player is currently on
    private bool fieldIsActive; // Checks if player is in the trigger area
    public Text textField; // The text that shows up
    public GameObject textFieldObject; // The text as a GameObject
    public bool isRepeatableMessage;
    private bool messagePlayed;
    private bool keyWasPressed; // Was key to advance text pressed?

    public QuestPole questPole;
    public NPCFaceChange faceChangerScript;

    public bool inQuestCollider;
    public bool doFaceChange;
    public KeyCode questOneAction;

    //[Header("Events")]
    //public GameEvent onTextExhausted; // Once the dialogue has finished, start quest

    // Start is called before the first frame update
    void Start()
    {
        textFieldObject = GameObject.Find("CharPopupText"); // Looks for the popup text object for NPC 1 specifically
        textField = textFieldObject.GetComponent<Text>(); // Gets the text component on the popup text GameObject
        
        // Sets the text to not show on start
        fieldIsActive = false;
        textField.enabled = false;
        messagePlayed = false;
        textNumber = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        keyWasPressed = false;
        keyWasPressed = Input.GetKeyDown(keyToAdvanceText);

        if (fieldIsActive == true && keyWasPressed)
        {
            if (!messagePlayed) // if message is NOT already being played
            {
                if (textNumber >= popupTexts.Length) // If the player is on the last round of text, end dialogue
                {
                    messagePlayed = true;
                    //onTextExhausted.Raise(this, null); // Repeatable message shouldn't fire this again
                    ResetTextField();
                }
                if (textNumber < popupTexts.Length) // If the player hasn't ended dialogue, go to next round of text
                {
                    textField.text = popupTexts[textNumber];
                    textNumber++;
                }
            }

            faceChangerScript.ChangeCharFace();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && fieldIsActive == false) // if player is in collider but the text field isnt on
        {
            textField.enabled = true; // TURN IT ON
            if (textNumber == 0) // if interaction message isn't showing
            {
                textField.text = initialMessage; // SHOW

                //if (Input.GetKeyDown(questOneAction))
                {
                    faceChangerScript.ChangeCharFace();
                }
            }
            fieldIsActive = true; // thing that stores the fact that player is in the trigger

            //questPole.QuestPoleFunction();
            //Debug.Log("ChangeCharFace function called - Part 1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && fieldIsActive == true) // if player left collider and text field is still true
        {
            ResetTextField(); // do the turn it off thing
        }
    }

    private void ResetTextField() // the turn it off thing
    {
        Debug.Log("Collider left");
        if (isRepeatableMessage) // if it's ticked as repeatable it will reset it as if it was new again
        {
            textNumber = 0;
            textField.text = initialMessage;
        }
        else
        {
            textField.text = (""); // but if not repeatable it stops showing
        }

        textField.enabled = false;
        fieldIsActive = false;

        inQuestCollider = false;
    }
}
