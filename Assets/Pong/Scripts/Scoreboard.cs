using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{

    public int playerOneScore;
    public int playerTwoScore;

    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    public void DisplayPlayerScores()
    {
        Debug.Log($"{playerOneScore} - {playerTwoScore}");
    }

    public void AddPlayerOneScore()
    {
        playerOneScore++;
    }

    public void AddPlayerTwoScore()
    {
        playerTwoScore++;
    }

    public void ResetScores()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void Update()
    {
        if(playerOneScore == 11)
        {
            Debug.Log("Game Over, Left Paddle Wins");
            ResetScores();

        } else if(playerTwoScore == 11)
        {
            Debug.Log("Game Over, Right Paddle Wins");
            ResetScores();
        }
    }
}
