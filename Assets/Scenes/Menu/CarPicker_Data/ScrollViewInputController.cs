using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScrollViewInputController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float snapSpeed = 10f;
    [SerializeField] private float snapThreshold = 0.1f;

    private RectTransform contentRect;
    private bool isDragging = false;
    private float[] itemPositions;
    private float targetPosition;

    void Start()
    {
        if (scrollRect == null)
            scrollRect = GetComponent<ScrollRect>();

        contentRect = scrollRect.content;

        // Calculate normalized positions for each child item
        int itemCount = contentRect.childCount;
        itemPositions = new float[itemCount];
        float step = 1f / (itemCount - 1);
        for (int i = 0; i < itemCount; i++)
            itemPositions[i] = step * i;
    }

    void Update()
    {
        if (!isDragging)
        {
            // Smoothly move to the target position
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(
                scrollRect.horizontalNormalizedPosition,
                targetPosition,
                Time.deltaTime * snapSpeed
            );
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        isDragging = false;

        float pos = scrollRect.horizontalNormalizedPosition;
        Debug.Log("Scroll position when released: " + pos);

        float closest = float.MaxValue;
        int closestIndex = 0;

        for (int i = 0; i < itemPositions.Length; i++)
        {
            float dist = Mathf.Abs(itemPositions[i] - pos);
            if (dist < closest)
            {
                closest = dist;
                closestIndex = i;
            }
        }

        targetPosition = itemPositions[closestIndex];
        Debug.Log("Snapping to index " + closestIndex + " at pos " + targetPosition);
    }
}