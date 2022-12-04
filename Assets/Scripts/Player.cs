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
            rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);   //�����E�X�N���[��
        }
    }

    private void Update()
    {
        isGround = ground.IsGround();
        isHit = hit.IsHit();
        
        // �n�ʂɂ��鎞
        if (isGround == true)
        {
            anime.SetBool("jump", false);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))   // �W�����v
            {
                rigid2D.AddForce(transform.up * jump, ForceMode2D.Impulse);
                anime.SetBool("jump", true);
                Debug.Log("�W�����v����");
            }
        }
        // �󒆂ɂ��鎞
        else
        {
            anime.SetBool("jump", true);
        }

        // �ǂɓ���������
        if (isHit == true)
        {
            anime.Play("Hit");
            Debug.Log("�ǂɓ�������");
        }

        // �q�b�g�A�j���[�V����������������
        if (IsHitAnimeEnd() == true)
        {
            isHit = false;
            SceneManager.LoadScene("GameScene");
            Debug.Log("�R���e�B�j���[");
        }
    }

    // �q�b�g�A�j���[�V�������������Ă��邩�ǂ���
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

    // �S�[��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == goalTag)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
