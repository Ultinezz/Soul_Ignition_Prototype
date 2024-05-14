using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    public bool playerDetect = false;

    // Update is called once per frame
    void Update()
    {
        if (playerDetect && Input.GetKeyDown(KeyCode.E))
        {
            print("NPC 1 dialogue test");
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
}
