using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RacerNav : MonoBehaviour
{
    public Transform[] checkPoints;
    public int index;
    Transform curCheckpoint;
    private double speed;
    public int lapCount = 1;
    private bool finLine = false;

    public CheckpointManager checkpointManager;
    public int racerNum;
    private UnityEngine.AI.NavMeshAgent racerAgent;
    public Transform target;

    string racerNumString;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomSpeed();
        racerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        racerAgent.SetDestination(checkPoints[0].position);
    }

    void SearchNextCheckpoint()
    {
        racerAgent.SetDestination(curCheckpoint.position);
    }

    void SetRandomSpeed()
    {
        racerAgent.speed = Random.Range(3.0f,5.0f);
    }


    void CheckRacer() //give a racer number to checkpoint manager
    {
        var match = Regex.Match(this.gameObject.name, @"\d+");
        
        racerNumString += match;
        if (int.TryParse(racerNumString, out racerNum)){
            checkpointManager.GetRacerNum(racerNum);
        }
        
    }

    void OnTriggerEnter(Collider other) //check if passing a checkpoint or finish line
    {
        int trueCheckpoint = 0;
        if (other.gameObject.name == string.Format("Checkpoint{0}", trueCheckpoint) )
        {
            trueCheckpoint = index + 1;
            finLine = true; //turns on ability to change lap
            CheckRacer(); //gives racer number to manager
            checkpointManager.changeCheckpoint(this.gameObject, trueCheckpoint);
            if (index != 2)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
            curCheckpoint = checkPoints[index];
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
