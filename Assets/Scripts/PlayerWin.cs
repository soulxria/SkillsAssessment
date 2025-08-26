using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerWin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int winVal = 0;
    public PlayerDeath playerDeath;
    public PlayerMove thePlayer;
    public TextMeshProUGUI winText;
    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene.name == "Puzzle2")
        {
            winVal = 1;
        }
        bool win = (Physics.Raycast(thePlayer.gameObject.transform.position, Vector3.down, 1.5f, LayerMask.GetMask("EndPlatform")));
        if (win && winVal == 0)
        {
            Debug.Log("your mom");
            SceneManager.LoadScene("Puzzle2", LoadSceneMode.Single);
        }
        else if (win && winVal == 1)
        {
            playerDeath.Respawn();
            if (winVal == 1 && winText != null)
            {
                winText.text = "You win! Enjoy the race :3";
                winVal += 1;
            }
        }
    }
}
