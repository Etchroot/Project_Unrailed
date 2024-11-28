using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Manager : MonoBehaviour
{
    [SerializeField] GameObject Ending_Canvas;
    [SerializeField] List<GameObject> Trains;
    [SerializeField] GameObject Clear_Panel;
    [SerializeField] GameObject Over_Panel;

    Dictionary<string, Action> Collision_Action;

    public static Ending_Manager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Ending_Canvas = GameObject.FindGameObjectWithTag("Ending_UI");
    }

    void Start()
    {
        Clear_Panel = Ending_Canvas.transform.GetChild(0).gameObject;
        Over_Panel = Ending_Canvas.transform.GetChild(1).gameObject;
        Trains = GameObject.FindGameObjectsWithTag("Train").OrderBy(train => train.name).ToList();

        Ending_Canvas.SetActive(false);
        Clear_Panel.SetActive(false);
        Over_Panel.SetActive(false);

        Collision_Action = new Dictionary<string, Action>
        {
            {"Destination", Clear_Event},
            {"Rock", Over_Event},
            {"Tree", Over_Event},
            {"BLOCK", Over_Event}
        };
    }

    public void Collision_Event(string _collision_tag)
    {
        if (_collision_tag != null)
        {
            if (Collision_Action.TryGetValue(_collision_tag, out Action action))
            {
                action?.Invoke();
            }
            StartCoroutine(Go_To_EndScene());
        }
    }

    public void Clear_Event()
    {
        Ending_Canvas.SetActive(true);
        Clear_Panel.SetActive(true);

        StartCoroutine(Destory_Train());
    }

    public void Over_Event()
    {
        Ending_Canvas.SetActive(true);
        Over_Panel.SetActive(true);

        StartCoroutine(Destory_Train());
    }

    IEnumerator Go_To_EndScene()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("0_Title");
    }

    IEnumerator Destory_Train()
    {
        foreach (var train in Trains)
        {
            if (train != null)
            {
                Destroy(train);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
