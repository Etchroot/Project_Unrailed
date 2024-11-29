using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(3f, 0f, 3f); // 목표 위치 (3, 3, 0)
    public float speed = 3f; // 이동 속도
    private Vector3 center = new Vector3(3f, 0f, 0f); // 원의 중심 (3, 0, 0)
    private float radius = 3f; // 원의 반지름
    private float currentAngle = 180f; // 현재 각도 (시작은 0도)
    private float targetAngle; // 목표 각도
    private float spendtime = 0;
    void Start()
    {
        // 시작 위치는 (0, 0, 0)
        transform.position = Vector3.zero;

        // 목표 위치 (3, 3, 0)에 대한 각도 계산 (원 중심은 (3, 0, 0))
        targetAngle = Mathf.Atan2(targetPosition.z - center.z, targetPosition.x - center.x);
    }

    void Update()
    {
        Debug.Log($" {spendtime}");
        if (spendtime > speed) return;
        // 원 표면을 따라 목표 각도로 부드럽게 이동
        //currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, speed * Time.deltaTime);
        spendtime += Time.deltaTime;
        currentAngle = (90 - 180) * (spendtime / speed);
        Debug.Log($" cur angle {currentAngle} ");
        // 원 표면 상에서 (3, 0, 0)을 중심으로 이동할 새로운 좌표 계산
        float x = center.x + Mathf.Cos((currentAngle + 180) * Mathf.Deg2Rad) * radius;
        float z = center.z + Mathf.Sin((currentAngle + 180) * Mathf.Deg2Rad) * radius;

        // 부드럽게 목표 위치로 이동
        transform.position = new Vector3(x, 0f, z); // y는 0으로 고정

        // 디버그 로그 출력
        //Debug.Log($"Current Position: {transform.position}, currentAngle: {currentAngle}");
    }
}
