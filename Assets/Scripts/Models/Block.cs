using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Collider collider;
    public void StartMove()
    {
        collider.enabled = false;
    }

    public void ExitMove()
    {
        collider.enabled = true;
    }

    public void MoveItem(Vector3 vector3)
    {
        rigidbody.MovePosition(vector3);
    }

    public void RotateBlock()
    {
        Debug.Log(transform.localEulerAngles.y + 90);
        rigidbody.rotation = Quaternion.Euler(0, transform.localEulerAngles.y + 90, 0);
    }
}
