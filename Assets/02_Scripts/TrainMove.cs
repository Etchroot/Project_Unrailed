using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class TrainMove : MonoBehaviour
{
    [Header("Train")]
    [SerializeField] GameObject TrainHead;
    [SerializeField] GameObject CraftingBox;
    [SerializeField] GameObject Storage;



    public GameObject Train1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward moveForward = Train1.GetComponent<MoveForward>();
            moveForward.GoForward();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft moveLeft = Train1.GetComponent<MoveLeft>();
            moveLeft.GoLeft();
            //moveL.GoLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight moveRight = Train1.GetComponent<MoveRight>();
            moveRight.GoRight();
            //moveR.GoRight();
        }

    }

    // private bool isCoroutineRunning = false; // 코루틴이 실행중인지 확인하는 변수
    // // IEnumerator TrainForward()
    // // {
    // //     yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
    // //     isCoroutineRunning = true;
    // //     Debug.Log("전진 코루틴 실행");
    // //     float destination = transform.position.z + 6;
    // //     int de = Mathf.RoundToInt(destination);
    // //     float distanceToMove = TrainSpeed * Time.deltaTime; // 한 프레임 동안 이동할 거리
    // //     float remaindistance = Targetdistance - Movedistance; // 남은 이동 거리

    // //     while (remaindistance >= 0.1)
    // //     {
    // //         Debug.Log("앞으로 갓");
    // //         Debug.Log($"{remaindistance}");
    // //         float TrainMove = Mathf.Min(distanceToMove, remaindistance);
    // //         TrainHead.transform.Translate(Vector3.forward * TrainMove);
    // //         remaindistance -= TrainMove;

    // //         yield return null;
    // //     }
    // //     TrainHead.transform.Translate(Vector3.forward * 0.1f);
    // //     Debug.Log("전진 코루틴 종료");
    // //     isCoroutineRunning = false;
    // //     //TrainHead.transform.Translate(Vector3.forward * 6 * Time.deltaTime);

    // // }
    // IEnumerator TrainLeft()
    // {
    //     yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
    //     isCoroutineRunning = true;
    //     Debug.Log("좌회전 코루틴 실행");
    //     Targetdistance = 3.0f;
    //     float distanceToMove = TrainSpeed * Time.deltaTime; // 한 프레임 동안 이동할 거리
    //     float remaindistance = Targetdistance - Movedistance; // 남은 거리

    //     if (remaindistance > 0)
    //     {
    //         float TrainMove = Mathf.Min(distanceToMove, remaindistance);
    //         TrainHead.transform.Translate(Vector3.forward * TrainMove);
    //         Movedistance += TrainMove;
    //     }
    //     if (remaindistance == 0)
    //     {
    //         TrainHead.transform.Rotate(Vector3.down * 5f * Time.deltaTime);
    //         Debug.Log("좌로 회전");
    //         Targetdistance = 3.0f;
    //         Movedistance = 0f;
    //         float TrainMove = Mathf.Min(distanceToMove, remaindistance);
    //         TrainHead.transform.Translate(Vector3.forward * TrainMove);
    //         Movedistance += TrainMove;
    //     }
    //     Debug.Log("좌회전 코루틴 종료");
    //     isCoroutineRunning = false;
    //     //TrainHead.transform.Translate(Vector3.forward * 6 * Time.deltaTime);

    // }
    // IEnumerator TrainRight()
    // {
    //     yield return new WaitUntil(() => !isCoroutineRunning); // 기존 코루틴 끝날때까지 대기
    //     isCoroutineRunning = true;
    //     Debug.Log("우회전 코루틴 실행");
    //     Targetdistance = 3.0f;
    //     float distanceToMove = TrainSpeed * Time.deltaTime; // 한 프레임 동안 이동할 거리
    //     float remaindistance = Targetdistance - Movedistance; // 남은 거리

    //     if (remaindistance > 0)
    //     {
    //         float TrainMove = Mathf.Min(distanceToMove, remaindistance);
    //         TrainHead.transform.Translate(Vector3.forward * TrainMove);
    //         Movedistance += TrainMove;
    //     }
    //     if (remaindistance == 0)
    //     {
    //         TrainHead.transform.Rotate(Vector3.up * 5f * Time.deltaTime);
    //         Debug.Log("우로 회전");
    //         Targetdistance = 3.0f;
    //         Movedistance = 0f;
    //         float TrainMove = Mathf.Min(distanceToMove, remaindistance);
    //         TrainHead.transform.Translate(Vector3.forward * TrainMove);
    //         Movedistance += TrainMove;
    //     }
    //     Debug.Log("우회전 코루틴 종료");
    //     isCoroutineRunning = false;
    //     //TrainHead.transform.Translate(Vector3.forward * 6 * Time.deltaTime);

    // }

}
