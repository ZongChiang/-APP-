using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue2 : MonoBehaviour
{
    public GameObject dialoguePanel4; // 第一個對話框
    public GameObject dialoguePanel5; // 第二個對話框
    public GameObject PressEto;       // 提示玩家按下 E 的字幕
    public GameObject PressEYto;
    public GameObject[] coreObjects;  // 包含 core1、core2、core3 的陣列

    private bool isPlayerInTrigger = false; // 確保只有在範圍內時響應按鍵
    private bool hasInteracted = false;    // 是否已完成對話

    private void Start()
    {
        // 初始化道具為不可見
        foreach (GameObject core in coreObjects)
        {
            if (core != null)
                core.SetActive(false);
        }
    }

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
            PressEYto.SetActive(false);
            dialoguePanel4.SetActive(false);
            dialoguePanel5.SetActive(false); // 確保玩家離開時關閉對話框
        }
    }

    private void Update()
    {
        // 玩家按下 E 顯示對話框
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel4.SetActive(true);
            dialoguePanel5.SetActive(true); // 顯示對話框
            PressEto.SetActive(false);     // 隱藏提示字幕
            PressEYto.SetActive(true);
        }

        // 玩家按下 Y 完成對話並顯示道具
        if ((dialoguePanel4.activeSelf || dialoguePanel5.activeSelf) && Input.GetMouseButtonDown(0))
        {
            dialoguePanel4.SetActive(false);
            dialoguePanel5.SetActive(false); // 關閉對話框
            ShowCores();                     // 顯示道具
            hasInteracted = true;            // 標記為已完成對話
        }
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y))
        {
            dialoguePanel4.SetActive(false);
            dialoguePanel5.SetActive(true); // 顯示對話框
            PressEto.SetActive(false);     // 隱藏提示字幕
            PressEYto.SetActive(false);
        }
    }

    private void ShowCores()
    {
        foreach (GameObject core in coreObjects)
        {
            if (core != null)
                core.SetActive(true); // 啟用道具
        }

        Debug.Log("Cores are now visible!");
    }
}
