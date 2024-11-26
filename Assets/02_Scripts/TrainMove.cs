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
    public Action endaction;
    private bool endbool;
    MoveForward moveForward;
    MoveLeft moveLeft;
    MoveRight moveRight;
    [SerializeField] int numoftrain;
    Coroutine pathfollowing;

    [SerializeField] AudioSource Audio_Source;


    public GameObject Train1;
    private void Awake()
    {
        moveForward = GetComponent<MoveForward>();
        moveLeft = GetComponent<MoveLeft>();
        moveRight = GetComponent<MoveRight>();

        if(this.transform.name != "Train")
        {
            return;
        }
        else
        {
            Audio_Source = GetComponent<AudioSource>();
            Audio_Source.clip = AudioManager.Instance.Train_Horn;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endaction += () =>
        {
            endbool = false;
            numoftrain++;
            TrainGo();
        };
        App.Instance.traingo += TrainGo;
        //pathfollowing = StartCoroutine(TrainStart());    

    }

    [PunRPC]
    void TrainGo()
    {
        if (App.Instance.pathofRails.Count == numoftrain)
        {
            Debug.Log($" waring end of rail");
            return;
        }
        int k = App.Instance.pathofRails[numoftrain];
        Play_Audio();
        switch (k)
        {
            case 0:
                moveForward.GoForward(endaction);
                break;
            case 1:
                moveLeft.GoLeft(endaction);
                break;
            case 2:
                moveRight.GoRight(endaction);
                break;
            default:
                break;
        }
    }

    public void Play_Audio()
    {
        if(this.transform.name != "Train")
        {
            return;
        }
        else
        {
            if(Audio_Source.clip == AudioManager.Instance.Train_Horn)
            {
                Audio_Source.Play();
                Invoke("Setting_Audio", 2.0f);
            }

            Audio_Source.Play();
        }
    }

    public void Setting_Audio()
    {
        Audio_Source.clip = AudioManager.Instance.Train_Go;
    }

    /*private IEnumerator TrainStart()
    {
        while (true)
        {
            yield return null;
            if (!endbool)
            {
                endbool = true;
                if (App.Instance.pathofRails.Count == numoftrain)
                {
                    //Debug.Log($" waring end of rail");
                    StopCoroutine(pathfollowing);
                    break;
                }
                int k = App.Instance.pathofRails[numoftrain];
                switch (k)
                {
                    case 0:
                        moveForward.GoForward(endaction);
                        break;
                    case 1:
                        moveLeft.GoLeft(endaction);
                        break;
                    case 2:
                        moveRight.GoRight(endaction);
                        break;
                    default:
                        break;
                }
            }
        }
        Debug.Log($" path follow is end");
    }*/


    // Update is called once per frame
    // void Update()
    // {
    //     if (endbool) return;
    //     if (Input.GetKeyDown(KeyCode.UpArrow))
    //     {
    //         endbool = true;
    //         moveForward.GoForward(endaction);
    //     }
    //     if (Input.GetKeyDown(KeyCode.LeftArrow))
    //     {
    //         endbool = true;
    //         moveLeft.GoLeft(endaction);
    //     }
    //     if (Input.GetKeyDown(KeyCode.RightArrow))
    //     {
    //         endbool = true;
    //         moveRight.GoRight(endaction);
    //     }

    // }

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
