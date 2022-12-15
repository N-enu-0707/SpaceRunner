using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    GameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameDirector.AddAmount(10);
            Destroy(this.gameObject);
        }
    }
}
