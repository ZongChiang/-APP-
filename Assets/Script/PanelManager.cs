using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �ޤJ�����޲z�\��

public class PanelManager : MonoBehaviour
{
    public GameObject panel;          // Panel ����
    public GameObject right;          // ���T������
    public GameObject wrong;          // ���~������
    public Button correctButton;      // ���T�����s
    public Button[] wrongButtons;     // ���~�����s�}�C
    public Animator mageAnimator;     // Mage �� Animator
    public string spellTriggerName = "spell"; // Trigger �W��
    private int targetSceneIndex = 4; // �ؼг����s��

    private void Start()
    {
        // �j�w���s���I���ƥ�
        correctButton.onClick.AddListener(OnCorrectButtonClick);

        foreach (Button button in wrongButtons)
        {
            button.onClick.AddListener(OnWrongButtonClick);
        }
    }

    // ���T���s�Q���U
    private void OnCorrectButtonClick()
    {
        if (right != null) right.SetActive(true); // �E�����T������
        if (panel != null) panel.SetActive(false); // �������O

        // �Ұʩ���Ĳ�o�ʵe�P������������{
        StartCoroutine(TriggerMageAnimationAfterDelay(7f)); // ���� 7 ��Ĳ�o�ʵe
        StartCoroutine(SwitchSceneAfterDelay(11f));         // ���� 11 ���������
    }

    // ���L���s�Q���U
    private void OnWrongButtonClick()
    {
        if (wrong != null)
        {
            wrong.SetActive(true); // �E�����~������
            StartCoroutine(DeactivateAfterDelay(wrong, 2f)); // ���� 2 ������
        }
    }

    // ��{�G������������
    private IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�ɶ�
        if (obj != null) obj.SetActive(false);  // ��������
    }

    // ��{�G����Ĳ�o Mage ���ʵe
    private IEnumerator TriggerMageAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�ɶ�
        if (mageAnimator != null)
        {
            mageAnimator.SetTrigger(spellTriggerName); // Ĳ�o�ʵe
            Debug.Log("Mage animation triggered: " + spellTriggerName);
        }
    }

    // ��{�G�����������
    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�ɶ�
        SceneManager.LoadScene(targetSceneIndex); // ������ؼг���
    }
}

