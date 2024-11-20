using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.SmartTweenableVariables;

public class FollowScript : MonoBehaviour
{
    [SerializeField] Transform train1;
    [SerializeField] Transform train2;
    [SerializeField] Transform train3;
    [SerializeField] float diameter = 6.1f; // 기차들 사이의 거리
    [SerializeField] float Trainspeed;
    private List<Vector3> followerPos = new List<Vector3>();
    private List<Transform> followers = new List<Transform>();
    private float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // followerPos.Add(train1.transform.position);
        // followers.Add(train2.transform);
        // followers.Add(train3.transform);
    }

    // Update is called once per frame 
    void Update()
    {
        MoveFollow();
        StartCoroutine(RotationFollow());
    }
    void MoveFollow()
    {
        float Distance = (train1.position - train2.position).magnitude; // 기차 1과 2사이의 거리 크기

        if (Distance > diameter)
        {
            Vector3 direction = (train1.position - train2.position).normalized; // 기차1과 2 사이의 방향 정보

            Vector3 TargetingPos = train2.position + direction * (Distance - diameter);
            //followerPos.RemoveAt(followerPos.Count - 1); // 마지막 위치정보 없애기

            train2.position = Vector3.Lerp(train2.position, TargetingPos, Distance / diameter);
            //Distance -= diameter;
        }
        // for (int i = 0; i < followers.Count; i++)
        // {
        //     if (1 + i >= followerPos.Count)
        //     {
        //         Debug.Log("followerPos 인덱스가 범위 벗어남");
        //         break;
        //     }
        //     followers[i].position = Vector3.Lerp(followerPos[1 + i], followerPos[i], Distance / diameter);
        // }
    }

    IEnumerator RotationFollow()
    {
        Debug.Log("따라가기 회전 실행");
        //delay = 6 / Trainspeed;
        Debug.Log($"delay:{delay}");
        yield return null;
        // yield return new WaitForSeconds(delay);
        // if (train1.rotation != train2.rotation)
        // {
        //     train2.rotation = train1.rotation;
        // }
        this.transform.rotation.SetLookRotation(train1.position);
    }
}
