using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalhint3 : MonoBehaviour
{
    public GameObject PressEtoclam; // 提示字幕
    public GameObject effect3;      // 特效物件
    public GameObject awake;        // 其他需要啟用的物件
    public GameObject giant;        // 巨人物件

    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保只有玩家觸發
        {
            isPlayerInTrigger = true;
            PressEtoclam.SetActive(true); // 顯示提示字幕
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PressEtoclam.SetActive(false); // 隱藏提示字幕
            awake.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // 玩家按下 E
        {
            // 隱藏當前物件（將自身設置為不可見）
            gameObject.SetActive(false);

            // 顯示 effect3
            if (effect3 != null)
                effect3.SetActive(true);

            // 隱藏提示字幕
            PressEtoclam.SetActive(false);

            // 啟用 awake
            if (awake != null)
                awake.SetActive(true);

            // 觸發 giant 的動畫
            if (giant != null)
            {
                Animator giantAnimator = giant.GetComponent<Animator>();
                if (giantAnimator != null)
                {
                    giantAnimator.SetTrigger("awake"); // 設置 Trigger 狀態
                }

                // 啟用 giant 上的 TriggerDialogue3 腳本
                TriggerDialogue3 dialogueScript = giant.GetComponent<TriggerDialogue3>();
                if (dialogueScript != null)
                {
                    dialogueScript.enabled = true; // 激活腳本
                }
            }
        }
    }
}
