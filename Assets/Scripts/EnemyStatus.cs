using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStatus : MonoBehaviour
{
    public float e_maxHP;
    public float e_atk;
    public float e_def;
    public float e_spd;

    public Image barHP;
    public Image baseHP;

    float e_curHP;
    string e_type; 
    // "OFFS", "DFFS", "NTRL", "BOSS"
    // "OFFS" : found player and attack
    // "DFFS" : if player attack, run
    // "NTRL" : if player attack, counter
    // "BOSS" : high hp, high atk, special skill

    // Start is called before the first frame update
    void Start()
    {
        e_curHP = e_maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BarUpdate() {
        barHP.fillAmount = e_curHP / e_maxHP;
    }

    public void attacked(float playerDamage) {
        e_curHP -=playerDamage * (1 - 1/Mathf.Pow(e_def / 50 + 1, 2));
    }
}
