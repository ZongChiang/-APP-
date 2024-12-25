using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statehint : MonoBehaviour
{

    public GameObject PressEto;
    private bool isPlayerInTrigger = false;
    public GameObject Dialogue6;
    public GameObject Dialogue7;
    // Start is called before the first frame update
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
            Dialogue6.SetActive(false);
            Dialogue7.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���a���U E
        {
            Dialogue6.SetActive(true);
            Dialogue7.SetActive(true);// ��ܹ�ܮ�
            PressEto.SetActive(false);   // ���ô��ܦr��
        }

        // �i��G���U Escape �Ψ�L��������ܮ�

    }
}
