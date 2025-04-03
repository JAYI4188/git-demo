using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIResumeManager : MonoBehaviour
{
    public List<GameObject> resumePrefabs; // 存放所有简历的预制体
    public Transform resumeParent; // UI中用于显示简历的父物体
    private GameObject currentResume; // 当前显示的简历
    private int resumeIndex = 0; // 当前简历索引

    void Start()
    {
        ShowNextResume(); // 开始时展示第一张简历
    }

    public void ShowNextResume()
    {
        if (currentResume != null)
        {
            Destroy(currentResume); // 销毁上一张简历
        }

        if (resumeIndex < resumePrefabs.Count)
        {
            currentResume = Instantiate(resumePrefabs[resumeIndex], resumeParent);
            UIResume resumeScript = currentResume.GetComponent<UIResume>();
            resumeScript.SetManager(this); // 传递管理器引用
            resumeIndex++;
        }
        else
        {
            Debug.Log("所有简历处理完成！");
        }
    }
}
