using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class StackRailroad : MonoBehaviour
{
    [SerializeField] GameObject railroad;
    [SerializeField] Transform targetposition;
    List<GameObject> LoadedRail = new();
    Transform spawnpoint;
    Vector3 stackposition = new Vector3(0, 0.18f, 0);
    int numofrails = 0;
    AudioSource Audio_Source;

    private void Awake()
    {
        Audio_Source = GetComponent<AudioSource>();
        Audio_Source.clip = AudioManager.Instance.Make_Rail;
    }

    public void AddRail()
    {
        if (PhotonNetwork.IsMasterClient)
        GetComponent<PhotonView>().RPC("Addrailrpc", RpcTarget.All, 1);
    }
    [PunRPC]
    public void Addrailrpc()
    {
        if (LoadedRail.Count > 8)
        {
            targetposition.position += stackposition;
        }
        GameObject rail = PhotonNetwork.Instantiate("RailRoad", targetposition.position, Quaternion.identity);
        // GameObject rail = Instantiate(railroad, targetposition.position, Quaternion.identity);
        rail.transform.parent = transform;
        rail.GetComponent<Rail>().Train(this);
        rail.name = railroad.name + numofrails++;

        LoadedRail.Add(rail);

        Audio_Source.Play();
    }

    public void TakeRail(GameObject rail)
    {
        //EditorApplication.Beep();
        LoadedRail.Remove(rail);
        if (targetposition.position.y > 6.21f)
        {
            targetposition.position -= stackposition;
        }
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         Debug.Log($" aabbcc");
    //         AddRail();
    //     }
    // }
}
