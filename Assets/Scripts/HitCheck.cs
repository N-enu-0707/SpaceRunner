using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    Animator playerAnime;
    private string groundTag = "Ground";

    private void Start()
    {
        this.playerAnime = GetComponentInParent<Animator>();
    }

    // �ǂɓ���������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == groundTag)
        {
            playerAnime.Play("Hit");
            // Debug.Log("�ǂɓ�������");
        }
    }

    // �v���C���[�̃q�b�g�A�j���[�V�������������Ă��邩�ǂ���
    public bool IsHitAnimeEnd()
    {
       
         AnimatorStateInfo currentState = playerAnime.GetCurrentAnimatorStateInfo(0);

         if (currentState.IsName("Hit"))
         {
              if (currentState.normalizedTime >= 1)
              {
                   return true;
              }
         }
         return false;
    }
}
