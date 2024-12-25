using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 引入場景管理功能

public class PanelManager : MonoBehaviour
{
    public GameObject panel;          // Panel 物件
    public GameObject right;          // 正確的物件
    public GameObject wrong;          // 錯誤的物件
    public Button correctButton;      // 正確的按鈕
    public Button[] wrongButtons;     // 錯誤的按鈕陣列
    public Animator mageAnimator;     // Mage 的 Animator
    public string spellTriggerName = "spell"; // Trigger 名稱
    private int targetSceneIndex = 4; // 目標場景編號

    private void Start()
    {
        // 綁定按鈕的點擊事件
        correctButton.onClick.AddListener(OnCorrectButtonClick);

        foreach (Button button in wrongButtons)
        {
            button.onClick.AddListener(OnWrongButtonClick);
        }
    }

    // 當正確按鈕被按下
    private void OnCorrectButtonClick()
    {
        if (right != null) right.SetActive(true); // 激活正確的物件
        if (panel != null) panel.SetActive(false); // 關閉面板

        // 啟動延遲觸發動畫與切換場景的協程
        StartCoroutine(TriggerMageAnimationAfterDelay(7f)); // 延遲 7 秒觸發動畫
        StartCoroutine(SwitchSceneAfterDelay(11f));         // 延遲 11 秒切換場景
    }

    // 當其他按鈕被按下
    private void OnWrongButtonClick()
    {
        if (wrong != null)
        {
            wrong.SetActive(true); // 激活錯誤的物件
            StartCoroutine(DeactivateAfterDelay(wrong, 2f)); // 延遲 2 秒關閉
        }
    }

    // 協程：延遲關閉物件
    private IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定時間
        if (obj != null) obj.SetActive(false);  // 關閉物件
    }

    // 協程：延遲觸發 Mage 的動畫
    private IEnumerator TriggerMageAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定時間
        if (mageAnimator != null)
        {
            mageAnimator.SetTrigger(spellTriggerName); // 觸發動畫
            Debug.Log("Mage animation triggered: " + spellTriggerName);
        }
    }

    // 協程：延遲切換場景
    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定時間
        SceneManager.LoadScene(targetSceneIndex); // 切換到目標場景
    }
}

