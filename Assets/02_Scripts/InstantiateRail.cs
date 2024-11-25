using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateRail : MonoBehaviour
{
    [SerializeField] private Button[] railbuttons; // 3개의 버튼 배열
    [SerializeField] private GameObject[] railPrefab; // rail 프리펩 3개 배열
    private Transform instantPoint; // 레일 생성 위치

    void Start()
    {
    }

    public void SetRail(Vector3 target)
    {
        for (int i = 0; i < railbuttons.Length; i++)
        {
            int index = i; // Lambda 캡쳐문제 방지
            if (railbuttons != null)
            {
                Debug.Log("set rail 도달");
                railbuttons[i].onClick.AddListener(() => instantRailPrefab(index, target));
            }
            else
            {
                Debug.Log("set rail 도달 실패");
            }
        }
    }
    private void instantRailPrefab(int index, Vector3 target)
    {
        if (railPrefab != null && index < railPrefab.Length && railPrefab[index] != null)
        {
            Debug.Log("프리펩 생성 도달");
            Instantiate(railPrefab[index], target, Quaternion.identity);

        }
        else
        {
            Debug.Log("레일 프리펩이나 인덱스 존재하지 않음");

        }
    }

    void Update()
    {

    }
}
