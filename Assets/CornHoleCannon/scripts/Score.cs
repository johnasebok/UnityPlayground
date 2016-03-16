using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

    public int pointValue;
    private ScoreManager scoreRef;

    void Start()
    {
        scoreRef = (ScoreManager)FindObjectOfType<ScoreManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Garbage can! " + other.tag);
        if (other.tag == "unicorn")
        {
            scoreRef.changeScore(pointValue);
        }
    }

}
