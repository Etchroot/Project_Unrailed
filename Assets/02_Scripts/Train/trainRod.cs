using UnityEngine;

public class trainRod : MonoBehaviour
{
    AudioSource audio_source;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();
    }

    public void Doit()
    {
        audio_source.clip = AudioManager.Instance.Lever;
        audio_source.Play();
        anim.SetTrigger("Doit");
        App.Instance.traingo.Invoke();
    }

}
