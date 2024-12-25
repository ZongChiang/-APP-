using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] bgmClips; // 存放不同場景的音樂
    private AudioSource audioSource;

    private void Awake()
    {
        // 確保只有一個 MusicManager 存在
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // 保持在場景切換間不被銷毀
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBGM(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        // 監聽場景加載事件
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 取消監聽場景加載事件
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
