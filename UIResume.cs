using UnityEngine;
using UnityEngine.EventSystems;

public class UIResume : MonoBehaviour, IDropHandler
{
    public UIDragSupervisor correctSupervisor; // 该简历的唯一正确主管
    private UIResumeManager resumeManager; // 关联的管理器

    public void SetManager(UIResumeManager manager)
    {
        resumeManager = manager;
    }

    public void OnDrop(PointerEventData eventData)
    {
        UIDragSupervisor draggedSupervisor = eventData.pointerDrag.GetComponent<UIDragSupervisor>();

        if (draggedSupervisor != null)
        {
            if (draggedSupervisor == correctSupervisor)
            {
                Debug.Log("{gameObject.name} 匹配成功！");
                resumeManager.ShowNextResume(); // 展示下一张简历
                Destroy(gameObject); // 移除当前简历
            }
            else
            {
                Debug.Log("{gameObject.name} 匹配失败！");
            }
        }
    }
}
