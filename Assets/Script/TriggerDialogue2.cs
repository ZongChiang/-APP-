using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue2 : MonoBehaviour
{
    public GameObject dialoguePanel4; // �Ĥ@�ӹ�ܮ�
    public GameObject dialoguePanel5; // �ĤG�ӹ�ܮ�
    public GameObject PressEto;       // ���ܪ��a���U E ���r��
    public GameObject PressEYto;
    public GameObject[] coreObjects;  // �]�t core1�Bcore2�Bcore3 ���}�C

    private bool isPlayerInTrigger = false; // �T�O�u���b�d�򤺮��T������
    private bool hasInteracted = false;    // �O�_�w�������

    private void Start()
    {
        // ��l�ƹD�㬰���i��
        foreach (GameObject core in coreObjects)
        {
            if (core != null)
                core.SetActive(false);
        }
    }

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
            PressEYto.SetActive(false);
            dialoguePanel4.SetActive(false);
            dialoguePanel5.SetActive(false); // �T�O���a���}��������ܮ�
        }
    }

    private void Update()
    {
        // ���a���U E ��ܹ�ܮ�
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel4.SetActive(true);
            dialoguePanel5.SetActive(true); // ��ܹ�ܮ�
            PressEto.SetActive(false);     // ���ô��ܦr��
            PressEYto.SetActive(true);
        }

        // ���a���U Y ������ܨ���ܹD��
        if ((dialoguePanel4.activeSelf || dialoguePanel5.activeSelf) && Input.GetMouseButtonDown(0))
        {
            dialoguePanel4.SetActive(false);
            dialoguePanel5.SetActive(false); // ������ܮ�
            ShowCores();                     // ��ܹD��
            hasInteracted = true;            // �аO���w�������
        }
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y))
        {
            dialoguePanel4.SetActive(false);
            dialoguePanel5.SetActive(true); // ��ܹ�ܮ�
            PressEto.SetActive(false);     // ���ô��ܦr��
            PressEYto.SetActive(false);
        }
    }

    private void ShowCores()
    {
        foreach (GameObject core in coreObjects)
        {
            if (core != null)
                core.SetActive(true); // �ҥιD��
        }

        Debug.Log("Cores are now visible!");
    }
}
