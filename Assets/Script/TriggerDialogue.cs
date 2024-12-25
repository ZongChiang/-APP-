using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel1;
    public GameObject dialoguePanel2;
    public GameObject PressEto;
    private bool isPlayerInTrigger = false; // �T�O�u���b�d�򤺮��T������
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            isPlayerInTrigger = true;
            PressEto.SetActive(true); // ��ܴ��ܦr��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PressEto.SetActive(false); // ���ô��ܦr��
            dialoguePanel1.SetActive(false);
            dialoguePanel2.SetActive(false);// �T�O���a���}��������ܮ�
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���a���U E
        {
            dialoguePanel1.SetActive(true);
            dialoguePanel2.SetActive(true);// ��ܹ�ܮ�
            PressEto.SetActive(false);   // ���ô��ܦr��
        }

        // �i��G���U Escape �Ψ�L��������ܮ�

    }

}

