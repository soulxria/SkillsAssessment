using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class RaceUI : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject[] racers;
    public TextMeshProUGUI racingText;
    public TextMeshProUGUI r1Placement, r2Placement, r3Placement, r4Placement;
    public CheckpointManager cpManager;
    public int placings = 1;
    public Dictionary<int, string> placements = new Dictionary<int, string>();

    void Start()
    {
        placements.Add(1, "1st");
        placements.Add(2, "2nd");
        placements.Add(3, "3rd");
        placements.Add(4, "4th");
    }
    // Update is called once per frame
    void Update()
    {
        racingText.text = "Racer 1 | Lap: " + cpManager.r1 + " Checkpoint: " + cpManager.checkpoints[racers[0]] + "\n"
        + "Racer 2 | Lap: " + cpManager.r2 + " Checkpoint: " + cpManager.checkpoints[racers[1]] + "\n"
        + "Racer 3 | Lap: " + cpManager.r3 + " Checkpoint: " + cpManager.checkpoints[racers[2]] + "\n"
        + "Racer 4 | Lap: " + cpManager.r4 + " Checkpoint: " + cpManager.checkpoints[racers[3]];
    }

    public void showPlacement(RacerNav racer)
    {
        
        switch (racer.gameObject.name)
        {
            case "Racer1":
                r1Placement.text = " " + placements[placings];
                break;
            case "Racer2":
                r2Placement.text = " " + placements[placings];
                break;
            case "Racer3":
                r3Placement.text = " " + placements[placings];
                break;
            case "Racer4":
                r4Placement.text = " " + placements[placings];
                break;
        }
        placings += 1;
    }
}
