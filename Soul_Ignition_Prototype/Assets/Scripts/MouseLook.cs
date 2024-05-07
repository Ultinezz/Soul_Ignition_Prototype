using UnityEngine;
using UnityEngine.Animations;

public class MouseLook : MonoBehaviour
{
    public float m_sensitivity = 1f; // Mouse sensitivity
    public float m_clampAngle = 90f; // Limits look angle by 90 degrees
    public Transform m_playerObject; // Stores the transform of the player container
    public Transform m_camera; // Stores the transform of the camera

    private Vector2 m_mousePos; // Stores the mouse position
    private float m_zRotation = 0f; // Rotation value along Z axis when player looks up and down

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos(); // Calls function to get the mouse position
        FixXRotation(); // Function for the clamps looking up and down
        LookAtCursor(); // Looks at the cursor position
    }

    private void GetMousePos()
    {
        m_mousePos.x = Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
        m_mousePos.y = Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;
        //Debug.Log(m_mousePos);
    }

    private void FixXRotation()
    {
        m_zRotation -= m_mousePos.y;
        m_zRotation = Mathf.Clamp(m_zRotation, -m_clampAngle, m_clampAngle);
    }

    private void LookAtCursor()
    {
        m_camera.localRotation = Quaternion.Euler(m_zRotation, 0, 0);
        m_playerObject.Rotate(Vector3.up * m_mousePos.x);
    }
}
