using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 引入場景管理命名空間

public class core3hint : MonoBehaviour
{
    public GameObject core3hinttext;
    public GameObject cleareffect;
    public GameObject right;
    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            isPlayerInTrigger = true;
            core3hinttext.SetActive(true); // 顯示提示字幕
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            core3hinttext.SetActive(false); // 隱藏提示字幕
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // 玩家按下 Y
        {
            right.SetActive(true);        // 顯示對話框
            cleareffect.SetActive(true); // 啟用效果
            core3hinttext.SetActive(false); // 隱藏提示字幕
            StartCoroutine(SwitchSceneAfterDelay(7f)); // 呼叫協程，延遲 10 秒切換場景
        }
    }

    // 協程：延遲切換場景
    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定的秒數
        SceneManager.LoadScene(2); // 切換到場景編號為 2
    }
}

