using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LV1");
            }
    public void QuitGame()
    {
        // �b�s��Ҧ��U�h�X�ݭn�� EditorApplication.isPlaying
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �b��ڹC�����������ε{��
        Application.Quit();
#endif
    }
    public void BackGame()
    {
        SceneManager.LoadScene("GameMenu");
    }
}   

