using Photon.Pun;
using UnityEngine;

public class MakeTree : MonoBehaviour
{
    private int hp = 3;
    public GameObject Woodlog;
    PhotonView photonView;

    //AudioManager Instance_Audio = AudioManager.Instance;
    AudioSource Audio_Source;

    private void Awake()
    {
        AudioManager.Initialize();
        photonView = GetComponent<PhotonView>();
        Audio_Source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Audio_Source.clip = AudioManager.Instance.Tree;

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
        Debug.Log(2);
        Audio_Source.Play();
        HP -= v;
    }


}
