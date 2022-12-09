using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 7f;
    [SerializeField] private float dump = 0.9f;   // �W�����v�̑��x�̌���
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
        rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);   //�����E�X�N���[��
    }

    private void Update()
    {
        isGround = ground.IsGround();
        
        // �n�ʂɂ��鎞
        if (isGround)
        {
            anime.SetBool("jump", false);

            if (Input.GetMouseButtonDown(0))
            {
                this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);   // �W�����v
                anime.SetBool("jump", true);
                // Debug.Log("�W�����v");
            }
        }

        // �󒆂ɂ��鎞
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

        // �q�b�g�A�j���[�V����������������
        if (hit.IsHitAnimeEnd())
        {
            // �X�^�[�g�n�_�ɖ߂�
            this.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
            anime.Play("Run");
            // Debug.Log("�R���e�B�j���[");
        }

        // �����~�X������
        if (this.transform.position.y < -7)
        {
            this.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, 0);
            Debug.Log("�����~�X");
        }
    }
}
