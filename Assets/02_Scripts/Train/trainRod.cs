using UnityEngine;

public class trainRod : MonoBehaviour
{
    //AudioManager Instance_Audio = AudioManager.Instance;
    AudioSource audio_source;
    Animator anim;
    private void Awake()
    {
        AudioManager.Initialize();
        anim = GetComponent<Animator>();
        audio_source = GetComponent<AudioSource>();
        audio_source.clip = AudioManager.Instance.Lever;
    }

    public void Doit()
    {
        audio_source.Play();
        anim.SetTrigger("Doit");
        App.Instance.traingo.Invoke();
    }

}
