using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class MoveLeft : MonoBehaviour
{
    private bool isCoroutineRunning = false; // 코루틴이 실행중인지 확인하는 변수
    [SerializeField] private float TrainSpeed = 1f; // 초당 이동 속도
    [SerializeField] private float radius = 3f; // 원의 반지름
    [SerializeField] private float angle = 0f; // 초기 각도
    [SerializeField] private float maxAngle = 90f; //90도 까지 이동  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoLeft()
    {
        StartCoroutine(TrainLeft());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TrainLeft()
    {
        yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
        isCoroutineRunning = true;

        while (angle < maxAngle)
        {
            angle += TrainSpeed * Time.deltaTime;
            float radians = Mathf.Deg2Rad * angle; // 각도를 라디안으로 변환 

            float x = -radius * Mathf.Cos(radians);
            float z = radius * Mathf.Sin(radians);

            transform.position = new Vector3(x, 0f, z);

            yield return null;
        }
        Debug.Log("목표 위치 도달");
        isCoroutineRunning = false;
    }
}