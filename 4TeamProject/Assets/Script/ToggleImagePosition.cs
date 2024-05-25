using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveImageWithMouse : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform centralPoint; // 중앙 위치를 나타내는 RectTransform
    private RectTransform imageRectTransform; // 이동할 이미지의 RectTransform
    private bool isDragging = false; // 드래그 중인지 여부를 나타내는 플래그
    private Vector3 originalPosition; // 원래 위치 저장
    private bool isAtCenter = false; // 현재 중앙에 있는지 여부를 나타내는 플래그
    public float speed = 500f; // 이동 속도
    public Text displayText; // UI 텍스트 객체
    public string centerText; // 중앙에 도달했을 때 표시할 텍스트
    public string originalText = ""; // 원래 위치로 돌아갔을 때 표시할 텍스트

    void Start()
    {
        // 이미지 RectTransform을 가져오고 원래 위치를 저장
        imageRectTransform = GetComponent<RectTransform>();
        originalPosition = imageRectTransform.position;
        // 텍스트 객체가 있다면 초기화
        if (displayText != null)
        {
            displayText.text = originalText;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 마우스를 클릭하여 드래그 시작
        isDragging = true;
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
            // 드래그 종료
            isDragging = false;
            // 중앙 또는 원래 위치로 이동
            Vector3 targetPosition = isAtCenter ? originalPosition : centralPoint.position;
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // 이미지가 목표 위치에 도달할 때까지 반복
        while (Vector3.Distance(imageRectTransform.position, targetPosition) > 0.1f)
        {
            // 목표 위치로 이동하는 방향 계산
            Vector3 direction = (targetPosition - imageRectTransform.position).normalized;
            // 이미지 위치를 이동
            imageRectTransform.position += direction * speed * Time.deltaTime;
            // 다음 프레임까지 대기
            yield return null;
        }
        // 최종 위치 설정
        imageRectTransform.position = targetPosition;
        // 중앙에 도달했음을 설정
        isAtCenter = (targetPosition == centralPoint.position);

        // 중앙에 도달하면 텍스트 업데이트
        if (isAtCenter && displayText != null)
        {
            displayText.text = centerText;
        }
        else if (!isAtCenter && displayText != null)
        {
            displayText.text = originalText;
        }
    }
}
