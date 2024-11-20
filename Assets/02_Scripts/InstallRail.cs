using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class InstallRail : MonoBehaviour
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
        Ray ray = new Ray(RayPos.transform.position, RayPos.transform.forward);
        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo))
        {
            if (hitinfo.collider.tag == "EMPTY")
            {
                selectRail();
            }
        }
    }

    private void selectRail()
    {
        throw new NotImplementedException();
    }
}