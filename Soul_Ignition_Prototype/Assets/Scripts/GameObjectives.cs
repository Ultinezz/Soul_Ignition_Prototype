using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectives : MonoBehaviour
{
    /*
    public int objectiveID;
    public string objectiveName;
    public bool objectiveActive;
    public bool objectiveCompleted;
    public int objectivePartsTotal;
    public int objectiveStep;

    [Header("Events")]
    public GameEvent onObjectiveActivated;
    public GameEvent onObjectiveCompleted;

    private GameObject objManager;
    private void Awake()
    {
        objManager = GameObject.Find("ObjectiveManager");
        if (objectiveActive)
        {
            StartQuest();
        }
    }

    public void StartQuest()
    {
        Debug.Log("New Objective: " + objectiveName);
        objectiveActive = true;
        objManager.GetComponent<ObjectiveTracker>().AddObjective(this);
        onObjectiveActivated.Raise(this, null);
    }

    public void AddQuestStep()
    {
        objectiveStep++;
        if (objectiveStep == objectivePartsTotal)
        {
            objectiveCompleted = true;
            objManager.GetComponent<ObjectiveTracker>().RemoveObj(objectiveID);
            Debug.Log("Objective " + objectiveName + " complete.");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
