using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject mainCamera;
    public GameObject PlayerDeathPanel;
    public GameObject WinLevelPanel;

    private bool isGameOver;
    private bool hasWonLevel;
    private float enemyDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = player.GetComponent<PlayerController2>().Gameover;
        hasWonLevel = player.GetComponent<PlayerController2>().WinLevel;

        if ( isGameOver && !hasWonLevel)
        {
            PlayerDeathPanel.SetActive(true);

        }

        if ( hasWonLevel)
        {
            WinLevelPanel.SetActive(true);

        }
    }
}
