using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 5f;
    //[SerializeField] private float dump = 0.9f;   // ジャンプの速度の減衰
    [SerializeField] private GroundCheck ground;
    [SerializeField] private HitCheck hit;

    private Rigidbody2D rigid2D = null;
    private Animator anime = null;
    private bool isGround = false;
    private string goalTag = "Finish";

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);   //強制右スクロール
    }

    private void Update()
    {
        isGround = ground.IsGround();
        
        // 地面にいる時
        if (isGround)
        {
            anime.SetBool("jump", false);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))   // ジャンプ
            {
                // this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);
                rigid2D.AddForce(transform.up * jump, ForceMode2D.Impulse);
                anime.SetBool("jump", true);
                Debug.Log("ジャンプした");
            }
        }

        // 空中にいる時
        if (isGround == false)
        {
            anime.SetBool("jump", true);

            //if (Input.GetMouseButton(0) == false)
            {
                //if (this.rigid2D.velocity.y > 0)
                {
                    //this.rigid2D.velocity *= this.dump;
                }
            }
        }

        // ヒットアニメーションが完了したら
        if (hit.IsHitAnimeEnd())
        {
            // スタート地点に戻る
            this.transform.position = new Vector3(-8, 2, 0);
            anime.Play("Run");
            Debug.Log("コンティニュー");
        }
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
