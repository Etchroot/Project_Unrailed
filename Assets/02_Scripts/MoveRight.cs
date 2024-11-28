using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class MoveRight : MonoBehaviour
{
    private bool isCoroutineRunning = false; // 코루틴이 실행중인지 확인하는 변수
                                             //[SerializeField] private float TrainSpeed = 2f; // 초당 이동 속도
                                             //[SerializeField] private float radius = 3f; // 원의 반지름
                                             //[SerializeField] private float rotationduration = 2f; // 회전 시간
                                             //[SerializeField] private float fwspeed = 3f; // 전진 속도
                                             //[SerializeField] private float duration = 3f; // 지속시간
    private float transpeedR;

    private void OnEnable()
    {
        transpeedR = App.Instance.TrainSpeedR;
    }

    public void GoRight(Action endaction)
    {
        //StartCoroutine(TraingoForward());
        StartCoroutine(TrainRight(endaction));
    }
    IEnumerator TrainRight(Action action)
    {
        yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
        isCoroutineRunning = true;

        StartCoroutine(RotateTrain());
        //Debug.Log("우회전 코루틴 시작");

        float time = 0f;
        Vector3 t1, t2, t3;
        t1 = transform.position;
        t2 = transform.position + (transform.forward * 3f);
        t3 = transform.position + (transform.forward * 3f) + (transform.right * 3f);


        while (time <= 1f)
        {


            Vector3 t4 = Vector3.Lerp(t1, t2, time);
            Vector3 t5 = Vector3.Lerp(t2, t3, time);
            transform.position = Vector3.Lerp(t4, t5, time);

            time += Time.deltaTime / transpeedR;

            yield return null;
        }
        transform.position = t3;
        // Vector3 startposition = transform.localPosition;
        // Vector3 center = transform.position + (transform.right * 3f);
        // Vector3 localTargetPoint = transform.position +
        //                    (transform.forward * 3f) +    // 로컬 기준 위 방향 (Y축)으로 3
        //                    (transform.right * 3f); // 로컬 기준 오른쪽 방향 (X축)으로 3
        // Debug.Log($"{center}");

        // float angle = 0.0f; // 초기 각도
        // float endangle = 90f;

        // while (angle > (Mathf.PI / 2))
        // {
        //     angle += TrainSpeed * Time.deltaTime;

        //     float z = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        //     float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        //     transform.position = new Vector3(x, transform.position.y, z);
        //     yield return null;

        // }
        //transform.position = localTargetPoint;
        //Debug.Log("목표 위치 도달");
        isCoroutineRunning = false;
        action.Invoke();
    }
    IEnumerator RotateTrain()
    {
        //Debug.Log("회전 코루틴 시작");
        float elapsedtime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0); //오른쪽 90도  

        while (elapsedtime < transpeedR)
        {
            elapsedtime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedtime / transpeedR);
            yield return null;
        }
        transform.rotation = endRotation;
        //Debug.Log("회전 완료");
    }
    // IEnumerator TraingoForward()
    // {

    //     Debug.Log("전진 시작");

    //     //Vector3 destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
    //     isCoroutineRunning = true;
    //     Vector3 destination = transform.position + transform.forward * 3;
    //     while (Vector3.Distance(transform.position, destination) > 0.01)
    //     {
    //         transform.position = Vector3.MoveTowards(transform.position, destination, fwspeed * Time.deltaTime);
    //         yield return null;
    //     }
    //     transform.position = destination;
    //     Debug.Log("목표 위치 도달");
    //     isCoroutineRunning = false;

    // }
}