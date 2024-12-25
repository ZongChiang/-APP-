using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statehint : MonoBehaviour
{

    public GameObject PressEto;
    private bool isPlayerInTrigger = false;
    public GameObject Dialogue6;
    public GameObject Dialogue7;
    // Start is called before the first frame update
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
            Dialogue6.SetActive(false);
            Dialogue7.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // 玩家按下 E
        {
            Dialogue6.SetActive(true);
            Dialogue7.SetActive(true);// 顯示對話框
            PressEto.SetActive(false);   // 隱藏提示字幕
        }

        // 可選：按下 Escape 或其他鍵關閉對話框

    }
}
