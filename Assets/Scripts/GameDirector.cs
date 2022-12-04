using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject player;
    GameObject goal;
    GameObject distance;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.goal = GameObject.Find("GoalFlag");
        this.distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.goal.transform.position.x - this.player.transform.position.x;
        this.distance.GetComponent<TextMeshProUGUI>().text = "Distance:" + length.ToString("F1") + "m";
    }
}
