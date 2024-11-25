using UnityEngine;

public class trainRod : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Doit()
    {
        anim.SetTrigger("Doit");
        App.Instance.traingo.Invoke();
    }

}
