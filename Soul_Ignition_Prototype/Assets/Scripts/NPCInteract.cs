using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.CompilerServices;

public class NPCInteract : MonoBehaviour
{
    // NPC raycast setup variables
    [Header("Player NPC Raycast")]
    public Transform c_rayPoint; // Camera position
    private Ray c_ray = new Ray(); // Defines ray
    private RaycastHit c_rayHit; // Get object hit
    public bool c_isHit = false; // Has the NPC Layer been hit?
    public LayerMask c_layerToHit;
    public float c_rayLength = 5f; // Length of the ray

    public KeyCode c_boundKey; // Make NPC interaction key E
    public Image Crosshair;
    public GameObject charOneObject; // Game object of NPC 1

    [Header("Prompt UI Element")]
    public string i_intPrompt;
    public bool i_fieldIsActive;
    public Text i_textField;
    public GameObject i_textFieldObject;
    public bool isRepeatableMessage;
    public bool i_messagePlayed;

    // Start is called before the first frame update
    void Start()
    {
        Crosshair = GameObject.Find("CrosshairDot").GetComponent<Image>(); // Sets up the Crosshair UI for the player
        Crosshair.GetComponent<Renderer>();
        Crosshair.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        c_ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Sets ray start point and direction
        Debug.DrawRay(c_rayPoint.transform.position, c_rayPoint.transform.forward); // Makes a debug line showing the ray

        if (Physics.Raycast(c_ray, out c_rayHit, c_rayLength, c_layerToHit))
        {
            if (c_rayHit.collider.tag == "NPC") // If raycast hits NPC collider
            {
                //Debug.Log("NPC ray hit");

                // Turns crosshair green
                Crosshair.color = Color.green;

                charOneObject = c_rayHit.collider.gameObject; // Makes NPC 1's collider interactive

                // If the player presses E, interact with NPC 1
                if (Input.GetKeyDown(c_boundKey))
                {
                    charOneObject.GetComponent<Interactable>().CharacterInteract();
                }
            }
            c_isHit = true;

            //Debug.Log("Player should be able to interact with the NPC");
            Debug.DrawRay(c_rayPoint.transform.position, c_rayPoint.transform.forward, Color.red);
        }
        else
        {
            c_isHit = false;
            //interactMode = false;

            // Turns crosshair back to red when ray isn't hitting the button
            Crosshair.color = Color.red;

            charOneObject = null; // Makes it so the player can't interact with the NPC while looking away from it
        }
    }
}
