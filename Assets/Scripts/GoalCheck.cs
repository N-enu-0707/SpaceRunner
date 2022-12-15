using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalCheck : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private GameObject stageClearText = null;
    [SerializeField] private GameObject nextStageButton = null;
    [SerializeField] private GameObject returnToTitleButton = null;
    [SerializeField] private GameObject player;

    GameObject distanceText;
    PlayerMoveController playerMoveController;
    Rigidbody2D playerRigid;
    Animator playerAnim;
    Animator flagAnim;

    // Start is called before the first frame update
    void Start()
    {
        this.distanceText = GameObject.Find("Distance");
        this.playerMoveController = player.GetComponent<PlayerMoveController>();
        this.playerRigid = player.GetComponent<Rigidbody2D>();
        this.playerAnim = player.GetComponent<Animator>();
        this.flagAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // プレイヤーがゴールしたら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.playerMoveController.enabled = false;
            this.playerRigid.velocity = Vector2.zero;
            this.playerRigid.gravityScale = 0;
            this.playerAnim.speed = 0;
            this.flagAnim.speed = 0;

            this.distanceText.SetActive(false);
            this.stageClearText.SetActive(true);
            this.nextStageButton.SetActive(true);
            this.returnToTitleButton.SetActive(true);

            // Debug.Log("ステージクリア");
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
        // Debug.Log("次のステージへ");
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
        // Debug.Log("タイトル画面に戻る");
    }
}
