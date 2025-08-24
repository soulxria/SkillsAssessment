using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    
    public Transform[] racers;
    int index;
    int racer;
    int lapNum;

    //racer lapcounts
    int r1;
    int r2;
    int r3;
    int r4;

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
        //text stuff using racers[racer-1] and trueCheckpoint
    }

}
