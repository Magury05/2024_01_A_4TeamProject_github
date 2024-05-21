using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveImageWithMouse : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform centralPoint; // 중앙 위치를 나타내는RectTransform
    private RectTransform imageRectTransform; // 이동할 이미지의 RectTransform
    private bool isDragging = false; // 드래그 중인지 여부를 나타내는 플래그
    private Vector3 originalPosition; // 원래 위치 저장
    private bool isAtCenter = false; // 현재 중앙에 있는지 여부를 나타내는 플래그
    public float speed = 1000f; // 이동 속도

    void Start()
    {
        imageRectTransform = GetComponent<RectTransform>();
        originalPosition = imageRectTransform.position; // 시작 위치를 원래 위치로 저장
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true; // 마우스를 클릭하여 드래그 시작
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            // 이미지를 마우스 위치로 이동
            imageRectTransform.position = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            // 마우스를 놓으면 중앙 위치로 이동
            imageRectTransform.position = centralPoint.position;
            isDragging = false; // 드래그 종료
        }
        if (isAtCenter)
        {
            // 원래 위치로 돌아가기
            StartCoroutine(MoveToPosition(originalPosition));
            isAtCenter = false; // 플래그 설정
        }
        else
        {
            // 중앙 위치로 이동
            StartCoroutine(MoveToPosition(centralPoint.position));
            isAtCenter = true; // 플래그 설정
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(imageRectTransform.position, targetPosition) > 0.1f)
        {
            Vector3 direction = (targetPosition - imageRectTransform.position).normalized;
            imageRectTransform.position += direction * speed * Time.deltaTime;
            yield return null; // 다음 프레임까지 대기
        }
        imageRectTransform.position = targetPosition; // 최종 위치 설정
    }
}