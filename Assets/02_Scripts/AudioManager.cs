using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip Tree;
    public AudioClip Rock;
    public AudioClip Set_Rail;
    public AudioClip Starting_Train;
    public AudioClip Moving_Train;
    public AudioClip Background;
    public AudioClip Lever;
    public AudioClip Success;
    public AudioClip Fail;

    void Start()
    {
        Instance = this;
    }
}
