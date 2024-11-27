using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Tree;
    public AudioClip Rock;
    public AudioClip Set_Rail;
    public AudioClip Make_Rail;
    public AudioClip Train_Horn;
    public AudioClip Train_Go;
    public AudioClip Lever;
    public AudioClip Clear;
    public AudioClip Over;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
