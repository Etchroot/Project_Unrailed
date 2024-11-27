using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Ending : MonoBehaviour
{
    public GameObject Ending_Canvas;
    [SerializeField] GameObject Clear_Panel;
    [SerializeField] GameObject Over_Panel;

    Dictionary<string, Action> Collision_Action;
    AudioSource Ending_Sound;


    private void Awake()
    {
        Ending_Sound = GetComponent<AudioSource>();
    }

    void Start()
    {
        Ending_Canvas = GameObject.Find("Ending_Canvas");
        Clear_Panel = Ending_Canvas.transform.GetChild(0).gameObject;
        Over_Panel = Ending_Canvas.transform.GetChild(1).gameObject;

        Ending_Canvas.SetActive(false);
        Clear_Panel.SetActive(false);
        Over_Panel.SetActive(false);

        Collision_Action = new Dictionary<string, Action>
        {
            {"Destination", Clear_Event},
            {"Rock", Over_Event},
            {"Tree", Over_Event},
            {"Block", Over_Event}
        };
    }

    void Update()
    {

    }

    private void OnColliderEnter(Collision _collision)  // Clear and Over
    {
        string tag = _collision.gameObject.tag;

        if (Collision_Action.TryGetValue(tag, out Action action))
        {
            action?.Invoke();
        }

        StartCoroutine(Go_To_EndScene());
    }

    public void Clear_Event()
    {
        Ending_Canvas.SetActive(true);
        Clear_Panel.SetActive(true);
        Ending_Sound.clip = AudioManager.Instance.Clear;
        Ending_Sound.Play();
    }

    public void Over_Event()
    {
        Ending_Canvas.SetActive(true);
        Over_Panel.SetActive(true);
        Ending_Sound.clip = AudioManager.Instance.Over;
        Ending_Sound.Play();
    }

    IEnumerator Go_To_EndScene()
    {
        Debug.Log("Loading...");

        yield return new WaitForSeconds(3);

        Ending_Canvas.SetActive(false);
        Ending_Sound.Pause();
        //SceneManager.LoadScene("02_End");
    }
}
