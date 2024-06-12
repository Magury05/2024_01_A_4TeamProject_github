using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public GameObject[] prefabs; // 랜덤으로 선택할 프리팹들을 배열로 저장합니다.

    public GameObject slotParent; // 슬롯의 부모 객체를 참조합니다. 5x4 그리드의 부모 오브젝트여야 합니다.

    public void SpawnRandomPrefab()
    {
        // 랜덤으로 프리팹 선택
        GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

        // 빈 슬롯 찾기
        Slot[] slots = slotParent.GetComponentsInChildren<Slot>();
        List<Slot> emptySlots = new List<Slot>();
        foreach (Slot slot in slots)
        {
            if (slot.GetIcon() == null)
            {
                emptySlots.Add(slot);
            }
        }

        // 빈 슬롯이 있다면 랜덤한 슬롯에 프리팹 배치
        if (emptySlots.Count > 0)
        {
            Slot randomSlot = emptySlots[Random.Range(0, emptySlots.Count)];
            GameObject spawnedPrefab = Instantiate(randomPrefab, randomSlot.transform.position, Quaternion.identity, randomSlot.transform);
        }
        else
        {
            Debug.Log("모든 슬롯에 이미지가 존재합니다!");
        }
    }
}
