using System;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static Action OnSpawn;

    public void SpawnButton()
    {
        OnSpawn?.Invoke();
    }
}
