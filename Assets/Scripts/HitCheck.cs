using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isHit = false;
    private bool isHitEnter = false;

    [SerializeField] private Player p;
    
    public bool IsHit()
    {
        if (isHitEnter == true)
        {
            isHitEnter = false;
            isHit = true;
        }
        return isHit;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == groundTag)
        {
            isHitEnter = true;
        }
    }
}
