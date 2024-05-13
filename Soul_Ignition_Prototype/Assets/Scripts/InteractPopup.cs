using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPopup : MonoBehaviour
{
    public string initialMessage; // The text that will show up
    public string[] popupTexts; // The amount of rounds of texts the player has to click through
    public KeyCode keyToAdvanceText; // E
    private int textNumber;
    private bool fieldIsActive; // Checks if player is in the collider area
    public Text textField; // The text that shows up
    public GameObject textFieldObject; // The text as a GameObject
    public bool isRepeatableMessage;
    private bool messagePlayed;
    private bool keyWasPressed;

    [Header("Events")]
    public GameEvent onTextExhausted; // Once the dialogue has finished, start quest

    // Start is called before the first frame update
    void Start()
    {
        textFieldObject = GameObject.Find("PopupNPC1"); // Looks for the popup text object for NPC 1 specifically
        textField = textFieldObject.GetComponent<Text>(); // Gets the text component on the popup text GameObject
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
            if (!messagePlayed)
            {

            }
        }
    }
}
