using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemID; 
    // 아이템 ID를 부여
    public string ItemDetails;
    // 아이템 설명을 부여

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
