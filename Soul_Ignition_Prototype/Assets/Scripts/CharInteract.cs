using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Runtime.CompilerServices;

public class CharInteract : MonoBehaviour
{
    // NPC raycast setup variables
    private Ray c_ray = new Ray(); // Defines the raycast to talk to the npc
    private RaycastHit c_hitObject; // Checks if the ray has hit an object
    public float c_rayLength = 5f; // Length of the ray
    public KeyCode c_boundKey; // Make NPC interaction key E
    public Image Crosshair;
    public GameObject charOneObject; // Game object of NPC 1
    public bool c_didHit; // a bool to show if the raycast hit the npc - mostly for debugging stuff
    
    // Start is called before the first frame update
    void Start()
    {
        Crosshair = GameObject.Find("CrosshairDot").GetComponent<Image>(); // Sets up the Crosshair UI for the player
    }

    // Update is called once per frame
    void Update()
    {
        c_ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Sets the ray start point and direction
        if (Physics.Raycast(c_ray, out c_hitObject, c_rayLength)) // Cast ray from where camera is looking
        {
            if (c_hitObject.collider.tag == "NPC") // If raycast hits the NPC's collider...
            {
                Debug.Log("Ray hit the NPC");

                // Turns crosshair green
                Crosshair.GetComponent<Renderer>();
                Crosshair.color = Color.green;

                charOneObject = c_hitObject.collider.gameObject; // Makes NPC 1's collider interactive

                // If the player clicks E, interact with NPC
                if (Input.GetKeyDown(c_boundKey))
                {
                    charOneObject.GetComponent<Interactable>().DialogueProgress();
                }
            }
        }
        else
        {
            // Turns crosshair back to red when the ray isn't hitting the button
            Crosshair.GetComponent<Renderer>();
            Crosshair.color = Color.red;

            charOneObject = null; // Makes it so the player can't interact with NPC 1 while looking away from them
        }
    }
}
