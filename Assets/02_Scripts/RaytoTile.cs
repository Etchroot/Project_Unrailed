using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.OpenXR.NativeTypes;
using UnityEngine.XR;
using UnityEngine.Subsystems;

public class RaytoTile : MonoBehaviour
{
    [SerializeField] private GameObject RayPos; // 레이 발사 지점
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindPossibleTile()
    {
        InstantiateRail instantiateRail = FindAnyObjectByType<InstantiateRail>();
        Ray ray = new Ray(RayPos.transform.position, RayPos.transform.forward);
        RaycastHit hitinfo;

        // 레이 디버그 선 그리기
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

        if (Physics.Raycast(ray, out hitinfo))
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

    // public void selectRail()
    // {

    // }

    // public void selectUI()
    // {

    // }
}