using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core1hint : MonoBehaviour
{

    public GameObject core1hinttext;
    private bool isPlayerInTrigger = false;
    public GameObject wrong;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            isPlayerInTrigger = true;
            core1hinttext.SetActive(true); // ��ܴ��ܦr��
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            core1hinttext.SetActive(false); // ���ô��ܦr��
            wrong.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // ���a���U E
        {
            wrong.SetActive(true);// ��ܹ�ܮ�
            core1hinttext.SetActive(false);   // ���ô��ܦr��
        }

        // �i��G���U Escape �Ψ�L��������ܮ�

    }
}
