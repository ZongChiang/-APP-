using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core1hint : MonoBehaviour
{

    public GameObject core1hinttext;
    private bool isPlayerInTrigger = false;
    public GameObject wrong;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            isPlayerInTrigger = true;
            core1hinttext.SetActive(true); // 顯示提示字幕
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            core1hinttext.SetActive(false); // 隱藏提示字幕
            wrong.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // 玩家按下 E
        {
            wrong.SetActive(true);// 顯示對話框
            core1hinttext.SetActive(false);   // 隱藏提示字幕
        }

        // 可選：按下 Escape 或其他鍵關閉對話框

    }
}
