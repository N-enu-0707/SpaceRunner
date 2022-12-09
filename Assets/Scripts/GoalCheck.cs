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

    GameObject player;
    GameObject distanceText;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.distanceText = GameObject.Find("Distance");
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
            this.player.GetComponent<PlayerMoveController>().enabled = false;
            this.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.player.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.player.GetComponent<Animator>().speed = 0;
            this.GetComponent<Animator>().speed = 0;

            this.distanceText.SetActive(false);
            this.stageClearText.SetActive(true);
            this.nextStageButton.SetActive(true);
            this.returnToTitleButton.SetActive(true);

            Debug.Log("ステージクリア");
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
        Debug.Log("次のステージへ");
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
        Debug.Log("タイトル画面に戻る");
    }
}
