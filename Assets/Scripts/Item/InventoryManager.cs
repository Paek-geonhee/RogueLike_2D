using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;

    bool invenOpened;

    // Start is called before the first frame update
    void Start()
    {
        invenOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventory();
    }


    void OpenInventory() {
        if (Input.GetKeyDown(KeyCode.E))
            invenOpened = !invenOpened;

        inventoryUI.SetActive(invenOpened);
    }
}
