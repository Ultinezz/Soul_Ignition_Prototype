using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// Allows player to move based on CharacterController
public class FirstPersonController : MonoBehaviour
{
    public CharDialogue charDialogue; // The CharDialogue script
    
    [Header("Controls")]
    public KeyCode m_forward; // W
    public KeyCode m_back; // S
    public KeyCode m_left; // A
    public KeyCode m_right; // D
    public KeyCode m_sprint; // Left Shift
    public KeyCode m_jump; // Space

    [Header("Movement and Gravity")]
    // Variables
    public UnityEngine.CharacterController m_charController; // Character Controller
    public float m_movementSpeed = 12f;
    public float m_runSpeed = 1.5f;
    private float m_finalSpeed = 0;

    // Jumping and air movement
    public float m_gravity = -9.81f; // Default gravity number
    public float m_jumpHeight = 1.5f;
    private Vector3 m_velocity; // Velocity is fall speed

    public Transform m_groundCheckPoint;
    public float m_groundDistance = 0.3f;
    public LayerMask m_groundMask;
    public bool m_isGrounded;
    public float m_horizontalAirScaling = 1f;

    // Game States
    //[Header("Game States")]
    //public bool interactMode;

    // NPC raycast setup variables
    /*[Header("Player NPC Raycast")]
    public Transform c_rayPoint; // Camera position
    private Ray c_ray = new Ray(); // Defines ray
    private RaycastHit c_rayHit; // Get object hit
    public bool c_isHit = false; // Has the NPC Layer been hit?                         // !!
    public LayerMask c_layerToHit;
    public float c_rayLength = 5f; // Length of the ray

    public KeyCode c_boundKey; // Make NPC interaction key E
    public Image Crosshair;
    public GameObject charOneObject; // Game object of NPC 1
    public bool c_didHit; // a bool to show if the raycast hit the npc - mostly for debugging stuff
    */

    void Awake() // Called before Start
    {
        m_finalSpeed = m_movementSpeed;
        m_charController.height = 1.8f;
    }

    void Update() // Called every frame
    {
        m_isGrounded = HitGroundCheck(); // Checks every frame if touching the ground
        MoveInputCheck();
        //InteractRay();
    }

    /*private void InteractRay()
    {
        c_ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creates the ray from mouse position. Only gets the direction of the ray.
        Debug.DrawRay(c_rayPoint.transform.position, c_rayPoint.transform.forward); 

        if (Physics.Raycast(c_ray, out c_rayHit, c_rayLength, c_layerToHit))
        {
            c_isHit = true;
            if (c_isHit)
            {
                InteractionMode();                              // !!
            }

            //Debug.Log("Player should be able to interact with the NPC");
            Debug.DrawRay(c_rayPoint.transform.position, c_rayPoint.transform.forward, Color.red);
        }
        else
        {
            c_isHit = false;
            interactMode = false;
        }
    }*/
    
    
    // Check if a button is pressed
    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal"); // Gets the x input value for the GameObject vector
        float z = Input.GetAxis("Vertical"); // Gets the z input value for the GameObject vector

        Vector3 move = Vector3.zero;

        if (m_isGrounded) // If the player is on ground surface, move at normal speed
        {
            if (Input.GetKey(m_forward) || Input.GetKey(m_back) || Input.GetKey(m_left) || Input.GetKey(m_right))
            {
                move = transform.right * x + transform.forward * z; // Calculate the move direction          
            }
        }

        if (m_isGrounded == false)
        {
            if (Input.GetKey(m_forward) || Input.GetKey(m_back) || Input.GetKey(m_left) || Input.GetKey(m_right))
            {
                move = (transform.right * x * m_horizontalAirScaling) + (transform.forward * z); // Calculate the move direction (with air scaling)          
            }
        }

        MovePlayer(move); // Run the MovePlayer function with the Vector3 value move
        RunCheck(); // Checks the input for running
        JumpCheck(); // Checks if player can jump
    }

    // MovePlayer function
    void MovePlayer(Vector3 move)
    {
        //Debug.Log(m_velocity.y);
        m_charController.Move(move * m_finalSpeed * Time.deltaTime); // Moves the GameObject using the Character Controller

        m_velocity.y += m_gravity * Time.deltaTime; // Gravity affects the jump velocity
        m_charController.Move(m_velocity * Time.deltaTime); // Actually move the player up
    }

    // Player run
    void RunCheck()
    {
        if (Input.GetKeyDown(m_sprint)) // if key is down, sprint
        {
            m_finalSpeed = m_movementSpeed * m_runSpeed;
        }
        else if (Input.GetKeyUp(m_sprint)) // if key is up, don't sprint
        {
            m_finalSpeed = m_movementSpeed;
        }
    }

    // Ground check
    bool HitGroundCheck()
    {
        bool isGrounded = Physics.CheckSphere(m_groundCheckPoint.position, m_groundDistance, m_groundMask);

        // Gravity
        if (isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }

        return isGrounded;
    }

    // Jump check
    void JumpCheck()
    {
        if (Input.GetKeyDown(m_jump))
        {
            if (m_isGrounded == true)
            {
                m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2f * m_gravity);
            }
        }
    }

    public void InteractionMode()
    {
        //interactMode = true;
    }
}
