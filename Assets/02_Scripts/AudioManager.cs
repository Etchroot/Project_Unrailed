using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Tree;
    public AudioClip Rock;
    public AudioClip Set_Rail;
    public AudioClip Starting_Train;
    public AudioClip Moving_Train;
    public AudioClip Lever;
    public AudioClip Success;
    public AudioClip Fail;

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

    public static void Initialize()
    {
        if (Instance == null)
        {
            GameObject obj = new GameObject("AudioManager");
            Instance = obj.AddComponent<AudioManager>();
        }
    }
}
