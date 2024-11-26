using UnityEngine;

public class trainRod : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke1, smoke2;
    AudioSource audio_source;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();
        audio_source.clip = AudioManager.Instance.Lever;
    }

    public void Doit()
    {
        audio_source.Play();
        anim.SetTrigger("Doit");
        smoke1.Play(); smoke2.Play();
        App.Instance.traingo.Invoke();
    }

}
