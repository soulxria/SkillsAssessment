using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RacerNav : MonoBehaviour
{
    public Transform[] checkPoints;
    public int index;
    Transform curCheckpoint;
    public int lapCount = 1;
    private bool finLine = false;

    public CheckpointManager checkpointManager;
    private UnityEngine.AI.NavMeshAgent racerAgent;
    public Vector3 target;

    string racerNumString;
    // Start is called before the first frame update
    void Start()
    {
        
        racerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetRandomSpeed();
        target = checkPoints[0].position; 
        racerAgent.SetDestination(target);
    }

    void SearchNextCheckpoint()
    {
        target = curCheckpoint.position;
        racerAgent.SetDestination(target);
    }

    void SetRandomSpeed()
    {
        racerAgent.speed = Random.Range(3.0f,5.0f);
    }


    void CheckRacer() //give a racer number to checkpoint manager
    {
        var match = Regex.Match(this.gameObject.name, @"\d+");
        
        racerNumString += match;
        if (int.TryParse(racerNumString, out int racerNum)){
            checkpointManager.GetRacerNum(racerNum);
        }
        
    }

    void OnTriggerEnter(Collider other) //check if passing a checkpoint or finish line
    {
        Debug.Log("contact made");
        int trueCheckpoint = 1;
        if (other.gameObject.name == "Checkpoint" + trueCheckpoint)
        {
            Debug.Log("checkpoint 1 hit");
            finLine = true; //turns on ability to change lap
            CheckRacer(); //gives racer number to manager
            checkpointManager.changeCheckpoint(this.gameObject, trueCheckpoint);
            if (trueCheckpoint < 3)
            {
                trueCheckpoint += 1;
            }
            else
            {
                trueCheckpoint = 1;
            }
            curCheckpoint = checkPoints[trueCheckpoint-1];
            SearchNextCheckpoint();
        }

        if(other.gameObject.name == "Finish Line" && finLine)
        {
            lapCount += 1;
            checkpointManager.SetLapCount(lapCount, this);

            if (lapCount == 3)
            {
                racerAgent.isStopped = true;
            }
        }
    }

    
}
