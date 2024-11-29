using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.OpenXR.NativeTypes;
using UnityEngine.XR;
using UnityEngine.Subsystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RaytoTile : MonoBehaviour
{
    [SerializeField] private Transform Controller; // 레이 발사 지점
    [SerializeField] private float rayLength = 100f; // 레이 길이
    [SerializeField] private InputActionProperty triggerAcrion; // 트리거 버튼 액션
    [SerializeField] private Button[] railbuttons; // 3개의 버튼 배열
    [SerializeField] private GameObject[] railPrefab; // rail 프리펩 3개 배열
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FindPossibleTile();
    }

    void OnEnable()
    {

    }

    void FindPossibleTile()
    {
        //InstantiateRail instantiateRail = FindAnyObjectByType<InstantiateRail>();
        Ray ray = new Ray(Controller.transform.position, Controller.transform.forward);
        RaycastHit hitinfo;

        // 레이 디버그 선 그리기
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red, 2f);

        if (triggerAcrion.action.WasPerformedThisFrame())
        {

            if (Physics.Raycast(ray, out hitinfo, rayLength))
            {
                Debug.Log($"{hitinfo.collider.gameObject.tag}");
                if (hitinfo.collider.CompareTag("EMPTY"))
                {
                    Debug.Log("empty타일");
                    Vector3 hitposition = hitinfo.collider.bounds.center;
                    hitinfo.collider.gameObject.tag = "INSTALL";
                    SetRail(hitposition);
                }
                else
                {
                    Debug.Log("설치할 수 없는 타일입니다.");
                    // Debug.Log($"{hitinfo.collider.gameObject.tag}");
                }
            }
        }

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


}