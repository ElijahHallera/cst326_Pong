using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Hand hand;

    void OnTriggerEnter(Collider collision)
    {

        if (this.name.Equals("LeftGoal") && collision.name.Equals("Ball"))
        {
            Debug.Log($"Right Paddle Scored");
           // Debug.Log($"Right Paddle Scored " + GameObject.Find("Scoreboard").GetComponent<Scoreboard>().playerTwoScore);

            GameObject.Find("Scoreboard").GetComponent<Scoreboard>().AddPlayerTwoScore();
            GameObject.Find("Scoreboard").GetComponent<Scoreboard>().DisplayPlayerScores();
}

        if (this.name.Equals("RightGoal") && collision.name.Equals("Ball"))
        {
            Debug.Log($"Left Paddle Scored");
            //Debug.Log($"Left Paddle Scored " + GameObject.Find("Scoreboard").GetComponent<Scoreboard>().playerOneScore);

            GameObject.Find("Scoreboard").GetComponent<Scoreboard>().AddPlayerOneScore();
            GameObject.Find("Scoreboard").GetComponent<Scoreboard>().DisplayPlayerScores();
        }

        hand.Reset();
    }
}