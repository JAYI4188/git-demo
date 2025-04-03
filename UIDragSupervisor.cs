using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIDragSupervisor : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;
    public List<UIResume> matchedResumes; // 该主管可匹配的简历列表

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // 变透明
        canvasGroup.blocksRaycasts = false; // 允许UI穿透
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; // 让 UI 位置跟随鼠标
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // 归位
        rectTransform.anchoredPosition = originalPosition;
    }
}
