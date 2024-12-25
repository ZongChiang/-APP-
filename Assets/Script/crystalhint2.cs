using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalhint2 : MonoBehaviour
{
    public GameObject PressEtoclam; // ���ܦr��
    public GameObject cavecrystal; // �W�� greencrystal ������
    public GameObject effect2;      // �W�� effect1 ������
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
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���a���U E
        {
            // ���÷�e����]�N�ۨ��]�m�����i���^
            gameObject.SetActive(false);

            // ��� greencrystal �M effect1
            if (cavecrystal != null)
                cavecrystal.SetActive(true);

            if (effect2 != null)
                effect2.SetActive(true);

            // ���ô��ܦr��
            PressEtoclam.SetActive(false);
        }
    }
}
