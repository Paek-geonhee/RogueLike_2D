using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(int dir_x, int dir_y, float playerDamage)
    {
        // �� �Լ��� ����� WeaponManager���� ���� �����̳ʿ� ����ִ�
        // Weapon class�� ���� �ٸ��� ���ȴ�.

        // Sword�� ���簢�� ����, ��ä�� ������ ���� ������ �����Ѵ�.

        // �������� �޾ƿ´�.
        // �Ķ���ͷ� ���� ���⺤�Ϳ� �������� �����Ѵ�.
        // ������ ���� ��� Enemy�� �ν��Ѵ�.
        // �νĵ� ��� Enemy���� �����Ѵ�.
        // ���� �� ���� �������� ���������� ������ playerDamage�� �����Ͽ� ���ظ� �ش�
    }
}