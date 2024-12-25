using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue3 : MonoBehaviour
{
    public GameObject dialoguePanel8;
    public GameObject dialoguePanel9;
    public GameObject dialoguePanel10;
    public GameObject PressEto;
    public GameObject awake;
    public GameObject teleporter1;
    public GameObject teleporter2;
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
            dialoguePanel8.SetActive(false);
            dialoguePanel9.SetActive(false);// �T�O���a���}��������ܮ�\
            dialoguePanel10.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���a���U E
        {
            dialoguePanel8.SetActive(true);
            dialoguePanel9.SetActive(true);
            dialoguePanel10.SetActive(true);// ��ܹ�ܮ�
            teleporter1.SetActive(true);
            teleporter2.SetActive(true);
            awake.SetActive(false);
            PressEto.SetActive(false);   // ���ô��ܦr��
        }

        // �i��G���U Escape �Ψ�L��������ܮ�

    }

}

