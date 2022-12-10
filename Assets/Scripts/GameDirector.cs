using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject player;
    GameObject goal;
    GameObject scoreText;
    GameObject distance;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.goal = GameObject.Find("GoalFlag");
        this.scoreText = GameObject.Find("ScoreText");
        this.distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.goal.transform.position.x - this.player.transform.position.x;
        this.distance.GetComponent<TextMeshProUGUI>().text = "Distance:" + length.ToString("F1") + "m";
    }

    public void AddAmount(int point)
    {
        this.score += point;
        if (this.score < 0)
        {
            this.score = 0;
        }
        this.scoreText.GetComponent<TextMeshProUGUI>().text = "Score " + score + "pt";
    }
}
