using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속용 클래스입니다.
// 해당 클래스를 단독으로 가지는 오브젝트는 없습니다.
public class Weapon : Item
{
    // 무기
    public float AttackCoefficient;     // 무기 순수 공격력 계수
    public float AttackSpeed;           // 무기 순수 공격 딜레이
    public float AttackRange;           // 무기 순수 공격 범위
    public float CriticalPossibility;   // 무기 치명타 확률
    public float CriticalCoefficient;   // 무기 치명타 계수
    public string WeaponDetails;        // 무기 설명

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getAttCo()
    {
        return AttackCoefficient;
    }

    public float getRange()
    {
        return AttackRange;
    }

    // 치명타 확률 계산
    public bool isCritical()
    {
        float pos = Random.Range(0, 100);
        return (pos <= CriticalPossibility);
    }

    // 실제 무기 데미지 결정
    // Weapon 하위 클래스에서 사용되며 플레이어 스텟과 결합하여
    // Weapon 하위 클래스의 Attack에서 실제 데미지로 제공됨.
    public float getPracticalDamage() {
        if (isCritical())
        {
            return getAttCo();
        }
        else {
            return getAttCo() * (1 + CriticalCoefficient);
        }
    }
    
}
