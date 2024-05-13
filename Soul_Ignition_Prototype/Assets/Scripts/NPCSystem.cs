using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool playerDetect = false;


    // Update is called once per frame
    void Update()
    {
        if (playerDetect && Input.GetKeyDown(KeyCode.E))
        {
            print("Dialogue Start");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBody")
        {
            playerDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetect = false;
    }
}
