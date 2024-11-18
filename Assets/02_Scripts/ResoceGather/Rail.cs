using UnityEngine;

public class Rail : MonoBehaviour
{
    bool isSkining = true;

    private void OnCollisionEnter(Collision other)
    {
        isSkining = false;
        Destroy(this);
    }
    private void Update()
    {
        if (!isSkining) return;
        this.transform.Translate(Vector3.down * 0.5f * Time.deltaTime);
    }

}
