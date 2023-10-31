using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// update 내부 함수 대문자로 시작
// update 외부 및 스크립트 외부 참조 소문자 시작
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    public float Speed;
    float curSpeed;
    bool isRunning;

    // Player expendable status
    public float maxHP;
    float curHP;
    public float maxMP;
    float curMP;
    public float maxSTA;
    float curSTA;

    private void Awake()
    {
        curHP = maxHP;
        curMP = maxMP;
        curSTA = maxSTA;

        curSpeed = Speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RestoreSTA();
    }

    void RestoreSTA() {
        if (!isRunning && curSTA < maxSTA) {
            curSTA += 5*Time.deltaTime;
        }

        if (curSTA > maxSTA) {
            curSTA = maxSTA;
        }
    }

    public float getHPrate() {
        return curHP/maxHP;
    }
    public float getMPrate()
    {
        return curMP/maxMP;
    }
    public float getSTArate()
    {
        return curSTA/maxSTA;
    }



    void MoveLeft() {
        rigid.velocity = new Vector2(rigid.velocity.x - 2*Time.deltaTime* curSpeed, rigid.velocity.y);
        if (Mathf.Abs(rigid.velocity.x) > curSpeed) rigid.velocity = new Vector2(-curSpeed, rigid.velocity.y);
    }
    void MoveRight()
    {
        rigid.velocity = new Vector2(rigid.velocity.x + 2*Time.deltaTime * curSpeed, rigid.velocity.y);
        if (Mathf.Abs(rigid.velocity.x) > curSpeed) rigid.velocity = new Vector2(curSpeed, rigid.velocity.y);
    }
    void MoveUp()
    {
        rigid.velocity = new Vector2(rigid.velocity.x , rigid.velocity.y + 2*Time.deltaTime * curSpeed);
        if (Mathf.Abs(rigid.velocity.y) > curSpeed) rigid.velocity = new Vector2(rigid.velocity.x, curSpeed);
    }
    void MoveDown()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y - 2*Time.deltaTime * curSpeed);
        if (Mathf.Abs(rigid.velocity.y) > curSpeed) rigid.velocity= new Vector2(rigid.velocity.x, -curSpeed);
    }
    void Move() {
        if (Input.GetKey(KeyCode.Space) && curSTA > 0)
        {
            curSpeed = Speed * 1.5f;
            curSTA -= 10f * Time.deltaTime;
            isRunning = true;
        }
        else
        {
            curSpeed = Speed;
            isRunning = false;
        }

        // accelation
        if (Input.GetKey(KeyCode.LeftArrow)) MoveLeft();
        if (Input.GetKey(KeyCode.RightArrow)) MoveRight();
        if (Input.GetKey(KeyCode.UpArrow)) MoveUp();
        if (Input.GetKey(KeyCode.DownArrow)) MoveDown();

        // de-accelation
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) rigid.velocity = new Vector2(0, rigid.velocity.y);
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) rigid.velocity = new Vector2(rigid.velocity.x, 0);
    } 
}
