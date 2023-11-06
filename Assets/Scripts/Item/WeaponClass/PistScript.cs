using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistScript : Weapon
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
        // 이 함수의 사용은 WeaponManager에서 웨폰 컨테이너에 들어있는
        // Weapon class에 따라 다르게 사용된다.

        // Pist는 오직 직사각형 범위만 존재한다.

        // 레인지를 받아온다.
        // 파라미터로 들어온 방향벡터와 레인지를 병합한다.
        // 레인지 내부 모든 Enemy를 인식한다.
        // 인식된 모든 Enemy들을 공격한다.
        // 공격 시 이전 과정에서 최종적으로 결정된 playerDamage를 적용하여 피해를 준다
    }
}
