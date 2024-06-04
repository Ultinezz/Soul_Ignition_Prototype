using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCFaceChange : MonoBehaviour
{
    public QuestPole poleScript;

    public GameObject charFaceObject;
    public RawImage charFrown;
    public RawImage charSmile;

    public bool changeCharFaceHappening;


    void Awake()
    {
        charSmile.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        changeCharFaceHappening = false;
        //charFrown = GameObject.Find("Frown1");
        //charSmile = GameObject.Find("Smile1");
        //charSmile.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharFace()
    {
        changeCharFaceHappening = true;
        Debug.Log("ChangeCharFace function called - Part 2");
        charFrown.gameObject.SetActive(false);
        charSmile.gameObject.SetActive(true);
    }
}
