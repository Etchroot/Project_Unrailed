using Photon.Pun;
using UnityEngine;

public class trainRod : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke1, smoke2;
    [SerializeField] GameObject TrainSign;
    AudioSource audio_source;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audio_source.clip = AudioManager.Instance.Lever;
    }

    [PunRPC]
    public void Doit()
    {
        audio_source.Play();
        anim.SetTrigger("Doit");
        smoke1.Play(); smoke2.Play();
        foreach (Transform child in TrainSign.transform)
        {
            if (child.gameObject.name == "Light_Green.R")
            {
                child.gameObject.SetActive(true);
            }
            if (child.gameObject.name == "Light_Red.L")
            {
                child.gameObject.SetActive(false);
            }
        }
        App.Instance.traingo.Invoke();
    }

}
