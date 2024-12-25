using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel1;
    public GameObject dialoguePanel2;
    public GameObject PressEto;
    private bool isPlayerInTrigger = false; // 確保只有在範圍內時響應按鍵
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            isPlayerInTrigger = true;
            PressEto.SetActive(true); // 顯示提示字幕
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PressEto.SetActive(false); // 隱藏提示字幕
            dialoguePanel1.SetActive(false);
            dialoguePanel2.SetActive(false);// 確保玩家離開時關閉對話框
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // 玩家按下 E
        {
            dialoguePanel1.SetActive(true);
            dialoguePanel2.SetActive(true);// 顯示對話框
            PressEto.SetActive(false);   // 隱藏提示字幕
        }

        // 可選：按下 Escape 或其他鍵關閉對話框

    }

}

