using Photon.Pun;
using UnityEngine;


public class MakeRock : MonoBehaviour
{
    private int hp = 3;
    public GameObject stone;
    PhotonView photonView;

    AudioSource Audio_Source;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        Audio_Source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        // Audio_Source.clip = AudioManager.Instance.Rock;
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
                //PhotonNetwork.Instantiate("Stone", this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                Instantiate(stone, this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                //PhotonNetwork.Destroy(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    //[PunRPC]
    public void Doit(int v)
    {
        Audio_Source.Play();
        HP -= v;
    }


}
