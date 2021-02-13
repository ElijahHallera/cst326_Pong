using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text leftTextScore;
    [SerializeField] private Text rightTextScore;

    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;

    [SerializeField] private GameManager gameManager;


    private int leftScore = 0;
    private int rightScore = 0;

    //public Color[] colors = {Color.blue, Color.red, Color.cyan, Color.green, Color.magenta, Color.yellow, Color.gray};

    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    private void RefreshScore()
    {
        leftScore = 0;
        rightScore = 0;
        rightTextScore.GetComponent<Text>().text = rightScore.ToString();
        leftTextScore.GetComponent<Text>().text = leftScore.ToString();
        rightTextScore.GetComponent<Text>().color = Color.white;
        leftTextScore.GetComponent<Text>().color = Color.white;
    }

    public void AddScore(Goal scoringSide)
    {

        //Check for score and change color depending on score.

        if (scoringSide == leftGoal)
        {
            rightScore += 1;
            rightTextScore.GetComponent<Text>().text = rightScore.ToString();
            if(rightScore == 1){
                rightTextScore.GetComponent<Text>().color = Color.blue;
            }  if (rightScore == 4) {
                rightTextScore.GetComponent<Text>().color = Color.red;
            }  if (rightScore == 7) {
                rightTextScore.GetComponent<Text>().color = Color.green;
            }  if (rightScore == 10){
                rightTextScore.GetComponent<Text>().color = Color.yellow;
            }
        }
        
        if (scoringSide == rightGoal){
            leftScore += 1;
            leftTextScore.GetComponent<Text>().text = leftScore.ToString();
            if (leftScore == 1){
                leftTextScore.GetComponent<Text>().color = Color.blue;
            }
            if (leftScore == 4){
                leftTextScore.GetComponent<Text>().color = Color.red;
            }
            if (leftScore == 7){
                leftTextScore.GetComponent<Text>().color = Color.green;
            }
            if (leftScore == 10){
                leftTextScore.GetComponent<Text>().color = Color.yellow;
            }
        }

        if(rightScore == 11)
        { 
            RefreshScore();
        }

        if(leftScore == 11)
        {
            RefreshScore();
        }

    }
}
