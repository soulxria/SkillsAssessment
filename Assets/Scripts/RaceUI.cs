using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class RaceUI : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject[] racers;
    public TextMeshProUGUI racingText;
    public CheckpointManager cpManager;

    // Update is called once per frame
    void Update()
    {
        racingText.text = "Racer 1 | Lap: " + cpManager.r1 + " Checkpoint: " + cpManager.checkpoints[racers[0]] + "\n"
        + "Racer 2 | Lap: " + cpManager.r2 + " Checkpoint: " + cpManager.checkpoints[racers[1]] + "\n"
        + "Racer 3 | Lap: " + cpManager.r3 + " Checkpoint: " + cpManager.checkpoints[racers[2]] + "\n"
        + "Racer 4 | Lap: " + cpManager.r4 + " Checkpoint: " + cpManager.checkpoints[racers[3]];
    }
}
