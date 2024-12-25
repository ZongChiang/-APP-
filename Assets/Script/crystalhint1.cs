using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalhint1 : MonoBehaviour
{
    public GameObject PressEtoclam; // 提示字幕
    public GameObject greencrystal; // 名為 greencrystal 的物件
    public GameObject effect1;      // 名為 effect1 的物件
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
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // 玩家按下 E
        {
            // 隱藏當前物件（將自身設置為不可見）
            gameObject.SetActive(false);

            // 顯示 greencrystal 和 effect1
            if (greencrystal != null)
                greencrystal.SetActive(true);

            if (effect1 != null)
                effect1.SetActive(true);

            // 隱藏提示字幕
            PressEtoclam.SetActive(false);
        }
    }
}
