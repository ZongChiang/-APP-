using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue3 : MonoBehaviour
{
    public GameObject dialoguePanel8;
    public GameObject dialoguePanel9;
    public GameObject dialoguePanel10;
    public GameObject PressEto;
    public GameObject awake;
    public GameObject teleporter1;
    public GameObject teleporter2;
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
            dialoguePanel8.SetActive(false);
            dialoguePanel9.SetActive(false);// 確保玩家離開時關閉對話框\
            dialoguePanel10.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // 玩家按下 E
        {
            dialoguePanel8.SetActive(true);
            dialoguePanel9.SetActive(true);
            dialoguePanel10.SetActive(true);// 顯示對話框
            teleporter1.SetActive(true);
            teleporter2.SetActive(true);
            awake.SetActive(false);
            PressEto.SetActive(false);   // 隱藏提示字幕
        }

        // 可選：按下 Escape 或其他鍵關閉對話框

    }

}

