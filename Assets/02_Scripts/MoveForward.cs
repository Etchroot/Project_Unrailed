using System;
using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Timeline;

public class MoveForward : MonoBehaviour
{
    private bool isCoroutineRunning = false; // 코루틴이 실행중인지 확인하는 변수
    public float TrainSpeed = 1f; // 초당 이동 속도
    private Vector3 destination; // 목표 위치\
    private Vector3 currdes;
    //private float posx, posy, posz;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoForward()
    {

        //de = Mathf.RoundToInt(transform.position.z + 6);
        StartCoroutine(TrainForward());
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TrainForward()
    {

        Debug.Log("전진 시작");
        yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
        Vector3 destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 6);
        isCoroutineRunning = true;

        while (Vector3.Distance(transform.position, destination) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, TrainSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = destination;
        Debug.Log("목표 위치 도달");
        isCoroutineRunning = false;
    }



    // Debug.Log("전진 코루틴 실행");
    // float destination = transform.position.z + 6;
    // int de = Mathf.RoundToInt(destination);
    // float distanceToMove = TrainSpeed * Time.deltaTime; // 한 프레임 동안 이동할 거리
    // float remaindistance = Targetdistance - Movedistance; // 남은 이동 거리

    // while (remaindistance >= 0.1)
    // {
    //     Debug.Log("앞으로 갓");
    //     Debug.Log($"{remaindistance}");
    //     float TrainMove = Mathf.Min(distanceToMove, remaindistance);
    //     TrainHead.transform.Translate(Vector3.forward * TrainMove);
    //     remaindistance -= TrainMove;

    //     yield return null;
    // }
    // TrainHead.transform.Translate(Vector3.forward * 0.1f);
    // Debug.Log("전진 코루틴 종료");
    // //TrainHead.transform.Translate(Vector3.forward * 6 * Time.deltaTime);

}
