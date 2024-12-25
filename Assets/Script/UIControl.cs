using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LV1");
            }
    public void QuitGame()
    {
        // 在編輯模式下退出需要用 EditorApplication.isPlaying
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在實際遊戲中關閉應用程式
        Application.Quit();
#endif
    }
    public void BackGame()
    {
        SceneManager.LoadScene("GameMenu");
    }
}   

