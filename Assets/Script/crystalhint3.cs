using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalhint3 : MonoBehaviour
{
    public GameObject PressEtoclam; // ���ܦr��
    public GameObject effect3;      // �S�Ī���
    public GameObject awake;        // ��L�ݭn�ҥΪ�����
    public GameObject giant;        // ���H����

    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            isPlayerInTrigger = true;
            PressEtoclam.SetActive(true); // ��ܴ��ܦr��
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            PressEtoclam.SetActive(false); // ���ô��ܦr��
            awake.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���a���U E
        {
            // ���÷�e����]�N�ۨ��]�m�����i���^
            gameObject.SetActive(false);

            // ��� effect3
            if (effect3 != null)
                effect3.SetActive(true);

            // ���ô��ܦr��
            PressEtoclam.SetActive(false);

            // �ҥ� awake
            if (awake != null)
                awake.SetActive(true);

            // Ĳ�o giant ���ʵe
            if (giant != null)
            {
                Animator giantAnimator = giant.GetComponent<Animator>();
                if (giantAnimator != null)
                {
                    giantAnimator.SetTrigger("awake"); // �]�m Trigger ���A
                }

                // �ҥ� giant �W�� TriggerDialogue3 �}��
                TriggerDialogue3 dialogueScript = giant.GetComponent<TriggerDialogue3>();
                if (dialogueScript != null)
                {
                    dialogueScript.enabled = true; // �E���}��
                }
            }
        }
    }
}
