using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 7f;
    [SerializeField] private float dump = 0.9f;   // ジャンプの速度の減衰
    [SerializeField] private GroundCheck ground;
    [SerializeField] private HitCheck hit;

    private Rigidbody2D rigid2D = null;
    private Animator anime = null;
    private bool isGround = false;

    GameObject startPos;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        startPos = GameObject.Find("RestartPosition");

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

            if (Input.GetMouseButtonDown(0))
            {
                this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);   // ジャンプ
                anime.SetBool("jump", true);
                // Debug.Log("ジャンプ");
            }
        }

        // 空中にいる時
        if (isGround == false)
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
        if (hit.IsHitAnimeEnd())
        {
            // スタート地点に戻る
            this.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
            anime.Play("Run");
            // Debug.Log("コンティニュー");
        }

        // 落下ミスしたら
        if (this.transform.position.y < -7)
        {
            this.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
            Debug.Log("落下ミス");
        }
    }
}
