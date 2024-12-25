using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    public GameObject objectToActivate; // 將此字段在Unity编辑器中分配给需要启动的对象

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 您可以检查其他对象是否带有特定的标签
        {
            ActivateGameObject(); // 如果满足条件，则调用激活对象的函数
            //this.gameObject.SetActive(false); // 禁用自己
        }
    }

    void ActivateGameObject()
    {
        objectToActivate.SetActive(true); // 启动指定的游戏对象
    }
}