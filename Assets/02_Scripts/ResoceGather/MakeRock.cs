using UnityEngine;


public class MakeRock : MonoBehaviour
{
    private int hp = 3;
    public GameObject stone;

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            Debug.Log($" {hp}");
            if (hp <= 0)
            {
                Instantiate(stone, this.transform.position + Vector3.up * 2.2f, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    public void Doit(int v)
    {
        HP -= v;
    }


}
