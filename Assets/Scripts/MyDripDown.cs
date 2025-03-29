using UnityEngine;
using TMPro;

[System.Serializable]
public class MyDripDown : TMP_Dropdown
{
    int count = 0;
    public GameObject[] prefabs;

    protected override DropdownItem CreateItem(DropdownItem itemTemplate)
    {
        if(itemTemplate.gameObject.TryGetComponent(out Item component))
        {
            component.Prefabs = prefabs[count];
            component.Number = count;
            count++;
        }
        return base.CreateItem(itemTemplate);
    }

    protected override void DestroyDropdownList(GameObject dropdownList)
    {
        Debug.Log("Удаление");
        count = 0;
        base.DestroyDropdownList(dropdownList);
    }
}
