using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveImageWithMouse : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform centralPoint; // �߾� ��ġ�� ��Ÿ����RectTransform
    private RectTransform imageRectTransform; // �̵��� �̹����� RectTransform
    private bool isDragging = false; // �巡�� ������ ���θ� ��Ÿ���� �÷���
    private Vector3 originalPosition; // ���� ��ġ ����
    private bool isAtCenter = false; // ���� �߾ӿ� �ִ��� ���θ� ��Ÿ���� �÷���
    public float speed = 1000f; // �̵� �ӵ�

    void Start()
    {
        imageRectTransform = GetComponent<RectTransform>();
        originalPosition = imageRectTransform.position; // ���� ��ġ�� ���� ��ġ�� ����
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true; // ���콺�� Ŭ���Ͽ� �巡�� ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            // �̹����� ���콺 ��ġ�� �̵�
            imageRectTransform.position = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            // ���콺�� ������ �߾� ��ġ�� �̵�
            imageRectTransform.position = centralPoint.position;
            isDragging = false; // �巡�� ����
        }
        if (isAtCenter)
        {
            // ���� ��ġ�� ���ư���
            StartCoroutine(MoveToPosition(originalPosition));
            isAtCenter = false; // �÷��� ����
        }
        else
        {
            // �߾� ��ġ�� �̵�
            StartCoroutine(MoveToPosition(centralPoint.position));
            isAtCenter = true; // �÷��� ����
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(imageRectTransform.position, targetPosition) > 0.1f)
        {
            Vector3 direction = (targetPosition - imageRectTransform.position).normalized;
            imageRectTransform.position += direction * speed * Time.deltaTime;
            yield return null; // ���� �����ӱ��� ���
        }
        imageRectTransform.position = targetPosition; // ���� ��ġ ����
    }
}