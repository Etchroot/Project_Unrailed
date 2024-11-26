using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.InputSystem;
using Photon.Pun;

public class RaytoTile_N_InstantRail : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform Controller; // 레이 발사 지점
    [SerializeField] private float rayLength = 10f; // 레이 길이
    [SerializeField] private InputActionProperty triggerAction; // 트리거 버튼 액션
    [SerializeField] private Button[] railButtons; // 3개의 버튼 배열
    [SerializeField] private GameObject[] railPrefabs; // 레일 프리팹 배열
    private int selectedRailIndex = -1; // 선택된 레일 종류 (-1은 선택되지 않음을 의미)

    AudioSource Audio_Source;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        // 초기 버튼 클릭 이벤트 설정
        SetButtonListeners();
        Audio_Source = GetComponent<AudioSource>();
        Audio_Source.clip = AudioManager.Instance.Set_Rail;
    }

    void OnEnable()
    {
        // triggerAction이 활성화될 때 이벤트 등록
        triggerAction.action.performed += TryPlaceRail;
    }

    void OnDisable()
    {
        // triggerAction 비활성화 시 이벤트 해제
        triggerAction.action.performed -= TryPlaceRail;
    }

    void Update()
    {
        // 트리거 버튼 입력에 따라 레일 설치 시도
        //TryPlaceRail();
    }

    /// <summary>
    /// 트리거가 활성화될 때 호출되는 메서드
    /// </summary>
    private void OnTriggerActivated(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger activated. Updating button listeners.");
        //UpdateButtonListeners();
    }

    /// <summary>
    /// 각 버튼 클릭 시 선택된 레일 인덱스를 설정
    /// </summary>
    private void SetButtonListeners()
    {
        for (int i = 0; i < railButtons.Length; i++)
        {
            int index = i; // 람다 캡처 문제 방지
            railButtons[i].onClick.AddListener(() => SelectRail(index));
        }
    }

    /// <summary>
    /// 버튼 리스너를 업데이트
    /// </summary>
    // private void UpdateButtonListeners()
    // {
    //     // 기존 리스너 제거
    //     // foreach (var button in railButtons)
    //     // {
    //     //     if (button != null)
    //     //         button.onClick.RemoveAllListeners();
    //     // }

    //     // 새로운 리스너 추가
    //     //SetButtonListeners();
    //     Debug.Log("Button listeners updated.");
    // }

    /// <summary>
    /// 선택된 레일 인덱스 설정
    /// </summary>
    private void SelectRail(int index)
    {
        selectedRailIndex = index;
        Debug.Log($"레일 {index} 선택됨");
    }

    /// <summary>
    /// 트리거 버튼을 눌렀을 때 레일 설치
    /// </summary>
    private void TryPlaceRail(InputAction.CallbackContext context)
    {
        if (selectedRailIndex != -1)
        {
            //triggerAction.action.WasPerformedThisFrame() &&
            Ray ray = new Ray(Controller.transform.position, Controller.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red, 2f);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
            {
                if (hitInfo.collider.CompareTag("EMPTY"))
                {
                    Debug.Log("타일이 EMPTY 상태입니다.");
                    PlaceRail(hitInfo.collider.gameObject, hitInfo.collider.bounds.center);
                }
                else
                {
                    Debug.Log("설치할 수 없는 타일입니다.");
                }
            }
        }
    }

    /// <summary>
    /// 레일 설치 로직
    /// </summary>
    private void PlaceRail(GameObject tile, Vector3 position)
    {
        if (selectedRailIndex >= 0 && railPrefabs[selectedRailIndex] != null)
        {
            WASDPlaceRail(tile, position);
            //selectedRailIndex < railPrefabs.Length &&
            //Instantiate(railPrefabs[selectedRailIndex], position, Quaternion.identity);
            //tile.tag = "INSTALL"; // 타일 상태를 INSTALL로 변경
            //Debug.Log($"레일 {selectedRailIndex} 설치 완료.");
        }
        else
        {
            Debug.Log("선택된 레일 프리팹이 존재하지 않음");
        }
    }

    #region 레일 연속성 판단
    private void WASDPlaceRail(GameObject tile, Vector3 position)
    {
        // 주변 타일을 감지할 때 사용할 Collider 배열
        Collider[] nearbyColliders = Physics.OverlapSphere(position, 6.1f);

        // 각 방향에 대한 레일 설치 여부 변수
        bool hasRailUp = false;    // 위에 레일이 있는지 여부
        bool hasRailDown = false;  // 아래에 레일이 있는지 여부
        bool hasRailLeft = false;  // 왼쪽에 레일이 있는지 여부
        bool hasRailRight = false; // 오른쪽에 레일이 있는지 여부

        // 주변 타일들 중 레일이 설치되어 있는지 확인
        foreach (var collider in nearbyColliders)
        {
            if (collider.CompareTag("RAIL")) // 레일인 타일만 체크
            {
                Vector3 direction = collider.transform.position - position;
                Debug.Log($"{direction}");
                // 위쪽에 레일이 있으면
                if (direction.z > 0)
                    hasRailUp = true;

                // 아래쪽에 레일이 있으면
                else if (direction.z < 0)
                    hasRailDown = true;

                // 왼쪽에 레일이 있으면
                else if (direction.x < 0)
                    hasRailLeft = true;

                // 오른쪽에 레일이 있으면
                else if (direction.x > 0)
                    hasRailRight = true;
            }
            Debug.Log($"{hasRailUp} + {hasRailDown} + {hasRailLeft} + {hasRailRight}");
        }

        // 레일을 설치할 조건 설정
        //int railToPlace = -1;  // 설치할 레일 타입을 결정할 변수

        switch (selectedRailIndex)
        {

            case 0:
                Debug.Log("0으로 서치중");
                if (hasRailUp || hasRailDown)
                {
                    Instantiate(railPrefabs[0], position, Quaternion.identity);
                    App.Instance.pathofRails.Add(0);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailLeft || hasRailRight)
                {
                    Instantiate(railPrefabs[0], position, Quaternion.Euler(0f, 90f, 0f));
                    App.Instance.pathofRails.Add(0);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                break;
            case 1:
                if (hasRailDown)
                {
                    Instantiate(railPrefabs[1], position, Quaternion.identity);
                    App.Instance.pathofRails.Add(1);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailLeft)
                {
                    Instantiate(railPrefabs[1], position, Quaternion.Euler(0f, 90f, 0f));
                    App.Instance.pathofRails.Add(1);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailUp)
                {
                    Instantiate(railPrefabs[1], position, Quaternion.Euler(0f, 180f, 0f));
                    App.Instance.pathofRails.Add(1);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailRight)
                {
                    Instantiate(railPrefabs[1], position, Quaternion.Euler(0f, 270f, 0f));
                    App.Instance.pathofRails.Add(1);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                break;
            case 2:
                if (hasRailDown)
                {
                    Instantiate(railPrefabs[2], position, Quaternion.identity);
                    App.Instance.pathofRails.Add(2);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailLeft)
                {
                    Instantiate(railPrefabs[2], position, Quaternion.Euler(0f, 90f, 0f));
                    App.Instance.pathofRails.Add(2);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailUp)
                {
                    Instantiate(railPrefabs[2], position, Quaternion.Euler(0f, 180f, 0f));
                    App.Instance.pathofRails.Add(2);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                else if (hasRailRight)
                {
                    Instantiate(railPrefabs[2], position, Quaternion.Euler(0f, 270f, 0f));
                    App.Instance.pathofRails.Add(2);
                    Audio_Source.Play();
                    tile.tag = "INSTALL";
                }
                break;
            default:
                Debug.Log("주변 레일을 감지하지 못해 레일을 설치하지 않음");
                break;

        }
    }
    // 각 방향에 따라 설치할 레일 종류 결정
    // if (hasRailUp || hasRailDown) // 위나 아래에 레일이 있으면 상하 레일
    // {
    //     railToPlace = 2; // 2번 레일 (상하 직선)
    // }
    // else if (hasRailLeft || hasRailRight) // 왼쪽이나 오른쪽에 레일이 있으면 좌우 레일
    // {
    //     railToPlace = 3; // 3번 레일 (좌우 직선)
    // }

    // 선택된 레일을 설치
    //     if (railToPlace != -1)
    //     {
    //         if (railToPlace == 4)  // 가로 레일은 1번 레일을 90도 회전시켜 설치
    //         {
    //             Instantiate(railPrefabs[0], position, Quaternion.Euler(0f, 90f, 0f));  // 1번 레일 회전
    //             Debug.Log("가로 레일(4번) 설치 완료");
    //         }
    //         else
    //         {
    //             Instantiate(railPrefabs[railToPlace], position, Quaternion.identity);
    //             Debug.Log($"레일 {railToPlace} 설치 완료");
    //         }

    //         tile.tag = "INSTALL"; // 타일 상태 변경
    //     }
    //     else
    //     {
    //         Debug.Log("주변 레일을 감지하지 못해 레일을 설치하지 않음");
    //     }
    // }

    #endregion
}
