using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveImageWithMouse : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform centralPoint; // �߾� ��ġ�� ��Ÿ���� RectTransform
    private RectTransform imageRectTransform; // �̵��� �̹����� RectTransform
    private bool isDragging = false; // �巡�� ������ ���θ� ��Ÿ���� �÷���
    private Vector3 originalPosition; // ���� ��ġ ����
    private bool isAtCenter = false; // ���� �߾ӿ� �ִ��� ���θ� ��Ÿ���� �÷���
    public float speed = 500f; // �̵� �ӵ�
    public Text displayText; // UI �ؽ�Ʈ ��ü
    public string centerText; // �߾ӿ� �������� �� ǥ���� �ؽ�Ʈ
    public string originalText = ""; // ���� ��ġ�� ���ư��� �� ǥ���� �ؽ�Ʈ

    void Start()
    {
        // �̹��� RectTransform�� �������� ���� ��ġ�� ����
        imageRectTransform = GetComponent<RectTransform>();
        originalPosition = imageRectTransform.position;
        // �ؽ�Ʈ ��ü�� �ִٸ� �ʱ�ȭ
        if (displayText != null)
        {
            displayText.text = originalText;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // ���콺�� Ŭ���Ͽ� �巡�� ����
        isDragging = true;
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
            // �巡�� ����
            isDragging = false;
            // �߾� �Ǵ� ���� ��ġ�� �̵�
            Vector3 targetPosition = isAtCenter ? originalPosition : centralPoint.position;
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // �̹����� ��ǥ ��ġ�� ������ ������ �ݺ�
        while (Vector3.Distance(imageRectTransform.position, targetPosition) > 0.1f)
        {
            // ��ǥ ��ġ�� �̵��ϴ� ���� ���
            Vector3 direction = (targetPosition - imageRectTransform.position).normalized;
            // �̹��� ��ġ�� �̵�
            imageRectTransform.position += direction * speed * Time.deltaTime;
            // ���� �����ӱ��� ���
            yield return null;
        }
        // ���� ��ġ ����
        imageRectTransform.position = targetPosition;
        // �߾ӿ� ���������� ����
        isAtCenter = (targetPosition == centralPoint.position);

        // �߾ӿ� �����ϸ� �ؽ�Ʈ ������Ʈ
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
