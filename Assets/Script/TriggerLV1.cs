using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLV1 : MonoBehaviour
{
    public GameObject dialoguePanel3;
    public GameObject PressYto;
    private bool isPlayerInTrigger = false; // 確保只有在範圍內時響應按鍵
    public GameObject goddess;
    public MonoBehaviour oldScript; // NPC 上的舊腳本
    public MonoBehaviour newScript; // NPC 上的新腳本

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            isPlayerInTrigger = true;
            PressYto.SetActive(true); // 顯示提示字幕
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PressYto.SetActive(false); // 隱藏提示字幕
            dialoguePanel3.SetActive(false);// 確保玩家離開時關閉對話框
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // 玩家按下 E
        {
            dialoguePanel3.SetActive(true);// 顯示對話框
            PressYto.SetActive(false);   // 隱藏提示字幕
        }
        // 按下 Y 切換 NPC 的腳本
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y))
        {
            if (oldScript != null) oldScript.enabled = false; // 關閉舊腳本
            if (newScript != null) newScript.enabled = true;  // 啟用新腳本
        }
        // 可選：按下 Escape 或其他鍵關閉對話框
        // 按下 Y 切換 NPC2 的腳本
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y))
        {
            if (goddess != null) // 確保目標 NPC 存在
            {
                if (oldScript != null) oldScript.enabled = false; // 關閉舊腳本
                if (newScript != null) newScript.enabled = true;  // 啟用新腳本
            }
            else
            {
                Debug.LogWarning("Target NPC is not assigned!");
            }
        }
    }
}

