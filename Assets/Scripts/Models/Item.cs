using UnityEngine;

public class Item : MonoBehaviour
{
    public int Number;
    public GameObject Prefabs;

    public void ExitToItem()
    {
        Debug.Log(Number);
    }
}
