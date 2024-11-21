using System;
using UnityEngine;
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
        InstantiateRail instantiateRail = FindAnyObjectByType<InstantiateRail>();
        Ray ray = new Ray(Controller.transform.position, Controller.transform.forward);
        RaycastHit hitinfo;

        // 레이 디버그 선 그리기
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red, 2f);

        if (triggerAcrion.action.WasPerformedThisFrame())
        {

            if (Physics.Raycast(ray, out hitinfo, rayLength))
            {
                if (hitinfo.collider.tag == "EMPTY")
                {
                    Vector3 hitposition = hitinfo.point;
                    instantiateRail.SetRail(hitposition);
                    hitinfo.collider.gameObject.tag = "INSTALL";
                }
                else
                {
                    Debug.Log("설치할 수 없는 타일입니다.");
                }
            }
        }
    }

    // public void selectRail()
    // {

    // }

    // public void selectUI()
    // {

    // }
}