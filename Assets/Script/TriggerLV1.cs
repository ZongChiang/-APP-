using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLV1 : MonoBehaviour
{
    public GameObject dialoguePanel3;
    public GameObject PressYto;
    private bool isPlayerInTrigger = false; // �T�O�u���b�d�򤺮��T������
    public GameObject goddess;
    public MonoBehaviour oldScript; // NPC �W���¸}��
    public MonoBehaviour newScript; // NPC �W���s�}��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            isPlayerInTrigger = true;
            PressYto.SetActive(true); // ��ܴ��ܦr��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PressYto.SetActive(false); // ���ô��ܦr��
            dialoguePanel3.SetActive(false);// �T�O���a���}��������ܮ�
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // ���a���U E
        {
            dialoguePanel3.SetActive(true);// ��ܹ�ܮ�
            PressYto.SetActive(false);   // ���ô��ܦr��
        }
        // ���U Y ���� NPC ���}��
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y))
        {
            if (oldScript != null) oldScript.enabled = false; // �����¸}��
            if (newScript != null) newScript.enabled = true;  // �ҥηs�}��
        }
        // �i��G���U Escape �Ψ�L��������ܮ�
        // ���U Y ���� NPC2 ���}��
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y))
        {
            if (goddess != null) // �T�O�ؼ� NPC �s�b
            {
                if (oldScript != null) oldScript.enabled = false; // �����¸}��
                if (newScript != null) newScript.enabled = true;  // �ҥηs�}��
            }
            else
            {
                Debug.LogWarning("Target NPC is not assigned!");
            }
        }
    }
}

