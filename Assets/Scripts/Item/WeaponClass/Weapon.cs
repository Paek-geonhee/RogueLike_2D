using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ӿ� Ŭ�����Դϴ�.
// �ش� Ŭ������ �ܵ����� ������ ������Ʈ�� �����ϴ�.
public class Weapon : Item
{
    // ����
    public float AttackCoefficient;     // ���� ���� ���ݷ� ���
    public float AttackSpeed;           // ���� ���� ���� ������
    public float AttackRange;           // ���� ���� ���� ����
    public float CriticalPossibility;   // ���� ġ��Ÿ Ȯ��
    public float CriticalCoefficient;   // ���� ġ��Ÿ ���
    public string WeaponDetails;        // ���� ����

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

    // ġ��Ÿ Ȯ�� ���
    public bool isCritical()
    {
        float pos = Random.Range(0, 100);
        return (pos <= CriticalPossibility);
    }

    // ���� ���� ������ ����
    // Weapon ���� Ŭ�������� ���Ǹ� �÷��̾� ���ݰ� �����Ͽ�
    // Weapon ���� Ŭ������ Attack���� ���� �������� ������.
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
