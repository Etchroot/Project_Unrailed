using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class MakeTree : MonoBehaviour
{
    private int hp = 3;
    public GameObject Woodlog;
    PhotonView photonView;

    [SerializeField] AudioSource Audio_Source;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        Audio_Source = GetComponent<AudioSource>();
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
            if (hp <= 0 && PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate("Log", this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                // Instantiate(Woodlog, this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                PhotonNetwork.Destroy(this.gameObject);
                // Destroy(this.gameObject);
            }
        }
    }

    [PunRPC]
    public void Doit(int v)
    {
        Audio_Source.Play();
        HP -= v;
    }


}
