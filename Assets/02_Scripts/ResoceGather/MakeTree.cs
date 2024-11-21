using Photon.Pun;
using UnityEngine;

public class MakeTree : MonoBehaviour
{
    private int hp = 3;
    public GameObject Woodlog;
    PhotonView photonView;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            Debug.Log($" {hp}");
            if (hp <= 0
            //&& photonView.IsMine
            )
            {
                //PhotonNetwork.Instantiate("Log", this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                Instantiate(Woodlog, this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                //PhotonNetwork.Destroy(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    //[PunRPC]
    public void Doit(int v)
    {
        HP -= v;
    }


}
