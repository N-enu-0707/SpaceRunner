using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // GameObject hitCheck;
    GameObject gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        // this.hitCheck = GameObject.Find("HitCheck");
        this.gameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameDirector.GetComponent<GameDirector>().AddAmount(10);
            Destroy(this.gameObject);
        }
    }
}
