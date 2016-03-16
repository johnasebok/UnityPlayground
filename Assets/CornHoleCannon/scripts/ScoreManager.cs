using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    int score;
	// Use this for initialization
	void Start () {
        scoreText.text = "Points:";
	}

    public void changeScore(int points)
    {
        score += points;
        scoreText.text = "Points: " + score.ToString();
    }

}
