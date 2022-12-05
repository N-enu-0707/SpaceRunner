using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 5f;
    //[SerializeField] private float dump = 0.9f;   // �W�����v�̑��x�̌���
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
        rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);   //�����E�X�N���[��
    }

    private void Update()
    {
        isGround = ground.IsGround();
        
        // �n�ʂɂ��鎞
        if (isGround)
        {
            anime.SetBool("jump", false);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))   // �W�����v
            {
                // this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, jump);
                rigid2D.AddForce(transform.up * jump, ForceMode2D.Impulse);
                anime.SetBool("jump", true);
                Debug.Log("�W�����v����");
            }
        }

        // �󒆂ɂ��鎞
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

        // �q�b�g�A�j���[�V����������������
        if (hit.IsHitAnimeEnd())
        {
            // �X�^�[�g�n�_�ɖ߂�
            this.transform.position = new Vector3(-8, 2, 0);
            anime.Play("Run");
            Debug.Log("�R���e�B�j���[");
        }
    }

    // �S�[��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == goalTag)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
