using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemID; 
    // ������ ID�� �ο�
    public string ItemDetails;
    // ������ ������ �ο�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetDetails() {
        return ItemDetails;
    }
}
