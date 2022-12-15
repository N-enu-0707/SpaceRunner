using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        // Debug.Log("ƒ^ƒCƒgƒ‹‰æ–Ê‚É–ß‚é");
    }
}
