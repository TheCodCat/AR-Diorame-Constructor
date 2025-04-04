using UnityEngine;
using UnityEngine.EventSystems;

public class CreateToDragItem : MonoBehaviour
{
    [SerializeField] Block createItem;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera camera;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector3 hitsInfo = new Vector3();
    public void CreateToItem(BaseEventData baseEventData)
    {
        if (baseEventData.selectedObject.TryGetComponent(out Item component))
        {
            Block gameObject = Instantiate(component.Prefabs).GetComponent<Block>();
            createItem = gameObject;
            createItem.StartMove();
        }
    }
    private void Update()
    {
        if (createItem != null && Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, layerMask))
            {
                hitsInfo.x = Mathf.Round(hitInfo.point.x / cellSize) * cellSize;
                hitsInfo.y = Mathf.Round(hitInfo.point.y / cellSize) * cellSize;
                hitsInfo.z = Mathf.Round(hitInfo.point.z / cellSize) * cellSize;
                createItem.MoveItem(hitsInfo);
            }
        }
        else
        {
            createItem?.ExitMove();
            createItem = null;
        }
    }
}
