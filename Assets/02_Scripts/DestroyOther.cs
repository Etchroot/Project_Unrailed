using System;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    private GameObject destroyEffect;
    void Start()
    {
        destroyEffect = Resources.Load<GameObject>("CFXR Explosion 1");
    }

    void OnDisable()
    {
        GameObject[] trains = GameObject.FindGameObjectsWithTag("Train");

        // Invoke("destroyAll", 1f);
        foreach (GameObject train in trains)
        {

            Instantiate(destroyEffect, new Vector3(train.transform.position.x, train.transform.position.y + 5, train.transform.position.z), Quaternion.identity);
            Destroy(train);
        }

    }

    // private void destroyAll(GameObject gameObject)
    // {
    //     Instantiate(destroyEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z), Quaternion.identity);
    //     Destroy(gameObject);
    // }


}
