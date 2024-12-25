using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue4 : MonoBehaviour
{
    public GameObject dialoguePanel11;
    public GameObject dialoguePanel12;
    public GameObject dialoguePanel13;
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
            dialoguePanel11.SetActive(false);
            dialoguePanel12.SetActive(false);// �T�O���a���}��������ܮ�\
            dialoguePanel13.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���a���U E
        {
            dialoguePanel11.SetActive(true);
            dialoguePanel12.SetActive(true);
            dialoguePanel13.SetActive(true);// ��ܹ�ܮ�
            PressEto.SetActive(false);   // ���ô��ܦr��
        }

        // �i��G���U Escape �Ψ�L��������ܮ�

    }

}

