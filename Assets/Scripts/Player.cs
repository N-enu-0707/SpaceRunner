using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 5f;
    [SerializeField] private GroundCheck ground;
    [SerializeField] private HitCheck hit;

    private Rigidbody2D rigid2D = null;
    private Animator anime = null;
    private bool isGround = false;
    private bool isHit = false;
    private string goalTag = "Finish";

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        if (isHit == false)
        {
            rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);   //強制右スクロール
        }
    }

    private void Update()
    {
        isGround = ground.IsGround();
        isHit = hit.IsHit();
        
        // 地面にいる時
        if (isGround == true)
        {
            anime.SetBool("jump", false);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))   // ジャンプ
            {
                rigid2D.AddForce(transform.up * jump, ForceMode2D.Impulse);
                anime.SetBool("jump", true);
                Debug.Log("ジャンプした");
            }
        }
        // 空中にいる時
        else
        {
            anime.SetBool("jump", true);
        }

        // 壁に当たった時
        if (isHit == true)
        {
            anime.Play("Hit");
            Debug.Log("壁に当たった");
        }

        // ヒットアニメーションが完了したら
        if (IsHitAnimeEnd() == true)
        {
            isHit = false;
            SceneManager.LoadScene("GameScene");
            Debug.Log("コンティニュー");
        }
    }

    // ヒットアニメーションが完了しているかどうか
    public bool IsHitAnimeEnd()
    {
        if (isHit && anime != null)
        {
            AnimatorStateInfo currentState = anime.GetCurrentAnimatorStateInfo(0);

            if (currentState.IsName("Hit"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // ゴールしたら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == goalTag)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
