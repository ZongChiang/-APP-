using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] bgmClips; // �s�񤣦P����������
    private AudioSource audioSource;

    private void Awake()
    {
        // �T�O�u���@�� MusicManager �s�b
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // �O���b�������������Q�P��
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBGM(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        // ��ť�����[���ƥ�
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ������ť�����[���ƥ�
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGM(scene.buildIndex);
    }

    private void PlayBGM(int sceneIndex)
    {
        if (bgmClips.Length > sceneIndex && bgmClips[sceneIndex] != null)
        {
            audioSource.clip = bgmClips[sceneIndex];
            audioSource.Play();
        }
    }
}
