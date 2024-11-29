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
    //public float TrainSpeed = 1f; // 초당 이동 속도
    private Vector3 destination; // 목표 위치\
    //private Vector3 currdes;
    private float TrainSpeedF;
    private void OnEnable()
    {
        TrainSpeedF = App.Instance.TrainSpeedF;
    }


    public void GoForward(Action endaction)
    {

        //de = Mathf.RoundToInt(transform.position.z + 6);
        StartCoroutine(TrainForward(endaction));
    }
    IEnumerator TrainForward(Action action)
    {

        //Debug.Log("전진 시작");
        yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
        //Vector3 destination = new Vector3(transform.position.x, transform.position.y, transform.position.z + 6);
        isCoroutineRunning = true;

        destination = transform.position + transform.forward * 6;
        while (Vector3.Distance(transform.position, destination) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, TrainSpeedF * Time.deltaTime);
            yield return null;
        }
        transform.position = destination;
        //Debug.Log("목표 위치 도달");
        isCoroutineRunning = false;
        action.Invoke();
    }

}
