using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 20.0f;
    public Camera MainCamera;
    Vector3 currentRotation;
    AudioSource walkeffect;
    Animator an;
    void Start()
    {
        walkeffect = GetComponent<AudioSource>();
        an = GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals)) mouseSensitivity += 5.0f; // 增加靈敏度
        if (Input.GetKeyDown(KeyCode.Minus)) mouseSensitivity = Mathf.Max(0.5f, mouseSensitivity - 0.5f); // 限制最小值為 0.5

        MovePlayer();
        RotatePlayer();
        ControlCamera();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement.x + movement.z > 0.1f && !walkeffect.isPlaying) walkeffect.Play(); else walkeffect.Pause();
        transform.Translate(movement * Time.deltaTime * moveSpeed);

        if (Mathf.Abs(moveVertical) + Mathf.Abs(moveHorizontal) > 0.1f)
        {
            an.SetBool("walk", true);
            //an.SetFloat("forward", moveVertical);
            //an.SetFloat("leftright", moveHorizontal);
        }
        else an.SetBool("walk", false);
        if (Input.GetButtonDown("Fire1")) an.SetTrigger("attack1");
        if (Input.GetButtonDown("Fire2")) an.SetTrigger("attack2");
    }

    void RotatePlayer()
    {
        float rotationAmount = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, rotationAmount);
    }

    void ControlCamera()
    {
        // 鼠標輸入（增加靈敏度調整）
        float sensitivity = 2f; // 新增靈敏度參數
        float mouseVertical = -Input.GetAxis("Mouse Y") * sensitivity;
        float mouseHorizontal = Input.GetAxis("Mouse X") * sensitivity;

        // 控制角色的水平旋轉
        transform.Rotate(0, mouseHorizontal * rotateSpeed * Time.deltaTime, 0);

        // 控制攝影機的俯仰角（僅改變 x 軸）
        Vector3 cameraRotation = MainCamera.transform.localEulerAngles;
        float newCameraAngle = cameraRotation.x + mouseVertical * rotateSpeed * Time.deltaTime;

        // 修正角度範圍，確保在 -45 到 20 度之間
        if (newCameraAngle > 180) newCameraAngle -= 360; // 將大於 180 的角度轉換為負角度
        newCameraAngle = Mathf.Clamp(newCameraAngle, -45f, 20f);

        // 更新攝影機旋轉
        MainCamera.transform.localEulerAngles = new Vector3(newCameraAngle, 0, 0);
    }

}