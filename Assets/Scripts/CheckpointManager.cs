using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject[] racers;
    public Dictionary<GameObject, int> checkpoints = new Dictionary<GameObject, int>();
    int index;
    int racer;
    int lapNum;

    //racer lapcounts
    public int r1, r2, r3, r4;

    void Start()
    {
        checkpoints.Add(racers[0], 0); //racer1
        checkpoints.Add(racers[1], 0); //racer2
        checkpoints.Add(racers[2], 0); //racer3
        checkpoints.Add(racers[3], 0); //racer4
    }

    public void changeCheckpoint(GameObject racer, int checkpointNum)
    {
        checkpoints[racer] = checkpointNum;
    }

    public void GetRacerNum(int racerNum)
    {
        racer = racerNum;
    }

    public void SetLapCount(int lapCount, RacerNav other)
    {
        switch (other.gameObject.name)
        {
            case "Racer1":
                r1 = other.lapCount;
                break;
            case "Racer2":
                r2 = other.lapCount;
                break;
            case "Racer3":
                r3 = other.lapCount;
                break;
            case "Racer4":
                r4 = other.lapCount;
                break;
        }
    }

    public void adjustUI(int trueCheckpoint)
    {
        
    }

}
