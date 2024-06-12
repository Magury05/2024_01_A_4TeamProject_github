using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public GameObject[] prefabs; // �������� ������ �����յ��� �迭�� �����մϴ�.

    public GameObject slotParent; // ������ �θ� ��ü�� �����մϴ�. 5x4 �׸����� �θ� ������Ʈ���� �մϴ�.

    public void SpawnRandomPrefab()
    {
        // �������� ������ ����
        GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

        // �� ���� ã��
        Slot[] slots = slotParent.GetComponentsInChildren<Slot>();
        List<Slot> emptySlots = new List<Slot>();
        foreach (Slot slot in slots)
        {
            if (slot.GetIcon() == null)
            {
                emptySlots.Add(slot);
            }
        }

        // �� ������ �ִٸ� ������ ���Կ� ������ ��ġ
        if (emptySlots.Count > 0)
        {
            Slot randomSlot = emptySlots[Random.Range(0, emptySlots.Count)];
            GameObject spawnedPrefab = Instantiate(randomPrefab, randomSlot.transform.position, Quaternion.identity, randomSlot.transform);
        }
        else
        {
            Debug.Log("��� ���Կ� �̹����� �����մϴ�!");
        }
    }
}
