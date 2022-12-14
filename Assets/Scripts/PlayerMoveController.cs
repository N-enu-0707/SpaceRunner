using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 7f;
    [SerializeField] private float dump = 0.9f;   // ジャンプの速度の減衰
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private HitCheck hitCheck;

    private Rigidbody2D rigid2D = null;
    private Animator anime = null;

    GameDirector gameDirector;
    GameObject startPos;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        this.gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        startPos = GameObject.Find("RestartPosition");

        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);   //強制右スクロール
    }

    private void Update()
    {   
        // 地面にいる時
        if (groundCheck.IsGroundFlag)
        {
            anime.SetBool("jump", false);

            if (Input.GetMouseButtonDown(0))
            {
                this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);   // ジャンプ
                anime.SetBool("jump", true);
                // Debug.Log("ジャンプ");
            }
        }

        // 空中にいる時
        if (groundCheck.IsGroundFlag == false)
        {
            anime.SetBool("jump", true);

            if (Input.GetMouseButton(0) == false)
            {
                if (this.rigid2D.velocity.y > 0)
                {
                    this.rigid2D.velocity *= this.dump;
                }
            }
        }

        // ヒットアニメーションが完了したら
        if (hitCheck.IsHitAnimeEnd())
        {
            // スタート地点に戻る
            this.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
            anime.Play("Run");
            // Debug.Log("コンティニュー");
            this.gameDirector.AddAmount(-20);
        }

        // 落下ミスしたら
        if (this.transform.position.y < -7)
        {
            this.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
            // Debug.Log("落下ミス");
            this.gameDirector.AddAmount(-20);
        }
    }
}
