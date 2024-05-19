using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public bool playerDetect = false;

    // Update is called once per frame
    void Update()
    {
        if (playerDetect && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("NPC interaction test");


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            playerDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetect = false;
    }

    public void DetectingPlayer()
    {

    }
}
