using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telehint2 : MonoBehaviour
{

    public GameObject teleporter2;
    private bool isPlayerInTrigger = false;
    public GameObject right;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            isPlayerInTrigger = true;
            teleporter2.SetActive(true); // 顯示提示字幕
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            teleporter2.SetActive(false); // 隱藏提示字幕
            right.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // 玩家按下 E
        {
            right.SetActive(true);// 顯示對話框
            teleporter2.SetActive(false);
            StartCoroutine(SwitchSceneAfterDelay(7f));// 隱藏提示字幕
        }

        // 可選：按下 Escape 或其他鍵關閉對話框

    }
    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定的秒數
        SceneManager.LoadScene(3); // 切換到場景編號為 3
    }
}
