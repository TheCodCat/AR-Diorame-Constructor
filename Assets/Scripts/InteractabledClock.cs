using UnityEngine;
using UnityEngine.InputSystem;

public class InteractabledClock : MonoBehaviour
{
    [SerializeField] private Camera cameraDelete;
    public void DeleteBlock(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Debug.Log("Тап");
            Block block = GetRayBlock();
            if (block != null)
            {
                Destroy(block.gameObject);
            }
        }
    }

    public void RotateBlock(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Block block = GetRayBlock();
            if (block != null)
            {
                Debug.Log(block.name);
                block.RotateBlock();
            }
        }
    }
    public Block GetRayBlock()
    {
        Ray ray = cameraDelete.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Block block = null;
            if (hitInfo.collider.transform.TryGetComponent(out Block blockNotParrent))
                block = blockNotParrent;
            if(hitInfo.collider.transform.parent != null)
            {
                if (hitInfo.collider.transform.parent.TryGetComponent(out Block blockParrent))
                    block = blockParrent;
            }
            return block;
        }
        else
            return null;
    }
}
