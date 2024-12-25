using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telehint2 : MonoBehaviour
{

    public GameObject teleporter2;
    private bool isPlayerInTrigger = false;
    public GameObject right;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �T�O�u�����aĲ�o
        {
            isPlayerInTrigger = true;
            teleporter2.SetActive(true); // ��ܴ��ܦr��
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            teleporter2.SetActive(false); // ���ô��ܦr��
            right.SetActive(false);
        }
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Y)) // ���a���U E
        {
            right.SetActive(true);// ��ܹ�ܮ�
            teleporter2.SetActive(false);
            StartCoroutine(SwitchSceneAfterDelay(7f));// ���ô��ܦr��
        }

        // �i��G���U Escape �Ψ�L��������ܮ�

    }
    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w�����
        SceneManager.LoadScene(3); // ����������s���� 3
    }
}
