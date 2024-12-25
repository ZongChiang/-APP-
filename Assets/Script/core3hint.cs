using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �ޤJ�����޲z�R�W�Ŷ�

public class core3hint : MonoBehaviour
{
    public GameObject core3hinttext;
    public GameObject cleareffect;
    public GameObject right;
    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            isPlayerInTrigger = true;
            core3hinttext.SetActive(true); // ��ܴ��ܦr��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            core3hinttext.SetActive(false); // ���ô��ܦr��
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // ���a���U Y
        {
            right.SetActive(true);        // ��ܹ�ܮ�
            cleareffect.SetActive(true); // �ҥήĪG
            core3hinttext.SetActive(false); // ���ô��ܦr��
            StartCoroutine(SwitchSceneAfterDelay(7f)); // �I�s��{�A���� 10 ���������
        }
    }

    // ��{�G�����������
    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�����
        SceneManager.LoadScene(2); // ����������s���� 2
    }
}

