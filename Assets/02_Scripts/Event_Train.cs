using UnityEngine;

public class Event_Train : MonoBehaviour
{
    private void Awake()
    {

    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.collider.CompareTag("Train"))
        {
            Ending_Manager.Instance.Collision_Event(this.gameObject.tag);
        }
    }
}
