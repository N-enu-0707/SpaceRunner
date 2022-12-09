using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    GameObject goalFlag;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.goalFlag = GameObject.Find("GoalFlag");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < goalFlag.transform.position.x)
        {
            this.transform.position = new Vector3(player.transform.position.x + 7, 2, -10);
        }
        else
        {
            this.transform.position = new Vector3(goalFlag.transform.position.x, 2, -10);
        }
    }
}
