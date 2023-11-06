using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image dirLeft;
    public Image dirRight;
    public Image dirUp;
    public Image dirDown;

    public Sprite front;
    public Sprite back;

    SpriteRenderer mySpr;

    bool isDirLeft;
    bool isDirRight;
    bool isDirUp;
    bool isDirDown;

    Vector2 AttackDir;

    public GameObject weaponContainer;
    float checkingTime = 0.1f;
    float checkingTime_cur;

    int h_dir; // 수평방향 움직임을 정의
    int v_dir; // 수직방향 움직임을 정의

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
        mySpr = GetComponent<SpriteRenderer>();
        checkingTime_cur = checkingTime;
        // 초기 스프라이트 방향은 아래
        isDirLeft = false;
        isDirRight = false;
        isDirUp = false;
        isDirDown = true;

        AttackDir = new Vector2(0, 1);
        weaponContainer = Instantiate(weaponContainer, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        SelectDirection();
        SetAttackDirect();
        Move();
        SetWeaponPosition();
        RestoreSTA();
        UpdateSprite();
        UpdateSpriteDirection();
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

    void MoveHor() {
        rigid.velocity = new Vector2(Mathf.Abs(h_dir)*(rigid.velocity.x + h_dir * 3 * Time.deltaTime * curSpeed), rigid.velocity.y);
        if (Mathf.Abs(rigid.velocity.x) > curSpeed) rigid.velocity = new Vector2(h_dir*curSpeed, rigid.velocity.y);
    }

    void MoveVer()
    {
        rigid.velocity = new Vector2(rigid.velocity.x , Mathf.Abs(v_dir) * (rigid.velocity.y + v_dir * 3 * Time.deltaTime * curSpeed));
        if (Mathf.Abs(rigid.velocity.y) > curSpeed) rigid.velocity = new Vector2(rigid.velocity.x, v_dir * curSpeed);
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

        isDirLeft = Input.GetKey(KeyCode.LeftArrow);
        isDirRight = Input.GetKey(KeyCode.RightArrow);
        isDirUp = Input.GetKey(KeyCode.UpArrow);
        isDirDown = Input.GetKey(KeyCode.DownArrow);

        MoveHor();
        MoveVer();
        // 문제점 : 이 경우 공격 방향을 설정하는 플래그를 정의하기 어려움.
        // 해결방법 : 가장 최근 바라본 방향을 기억하는 새로운 플래그를 세우거나 1
        //            기존 변수를 이용하여 어떻게든 구현하는 것 2

        // de-accelation
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) rigid.velocity = new Vector2(0, rigid.velocity.y);
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) rigid.velocity = new Vector2(rigid.velocity.x, 0);
    }

    void UpdateSpriteDirection() {
        if (isDirLeft)
        {
            dirLeft.color = new Color(dirLeft.color.r, dirLeft.color.g, dirLeft.color.b, 1f);
        }
        else {
            dirLeft.color = new Color(dirLeft.color.r, dirLeft.color.g, dirLeft.color.b, 0f);
        }

        if (isDirRight)
        {
            dirRight.color = new Color(dirRight.color.r, dirRight.color.g, dirRight.color.b, 1f);
        }
        else
        {
            dirRight.color = new Color(dirRight.color.r, dirRight.color.g, dirRight.color.b, 0f);
        }

        if (isDirUp)
        {
            dirUp.color = new Color(dirUp.color.r, dirUp.color.g, dirUp.color.b, 1f);
        }
        else
        {
            dirUp.color = new Color(dirUp.color.r, dirUp.color.g, dirUp.color.b, 0f);
        }

        if (isDirDown)
        {
            dirDown.color = new Color(dirDown.color.r, dirDown.color.g, dirDown.color.b, 1f);
        }
        else
        {
            dirDown.color = new Color(dirDown.color.r, dirDown.color.g, dirDown.color.b, 0f);
        }
    }

    void SelectDirection() {
        int l,r,u,d;

        l = (isDirLeft) ? 1 : 0;
        r = (isDirRight) ? 1 : 0;
        u = (isDirUp) ? 1 : 0;
        d = (isDirDown) ? 1 : 0;

        h_dir = r - l;
        v_dir = u - d;
    }

    void SetAttackDirect() {

        checkingTime_cur -= Time.deltaTime;
        if (checkingTime_cur > 0)
            return;
        else {
            checkingTime_cur = checkingTime;
        }

        //if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) {
        //    AttackDir = new Vector2(-1, 1);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        //{
        //    AttackDir = new Vector2(-1, -1);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    AttackDir = new Vector2(-1, 0);
        //}


        //if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        //{
        //    AttackDir = new Vector2(1, 1);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        //{
        //    AttackDir = new Vector2(1, -1);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    AttackDir = new Vector2(1, 0);
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    AttackDir = new Vector2(0, 1);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    AttackDir = new Vector2(0, -1);
        //}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //AttackDir = new Vector2(-1, AttackDir.y);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                AttackDir = new Vector2(-1, 1);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                AttackDir = new Vector2(-1, -1);
            }
            else
            {
                AttackDir = new Vector2(-1, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //AttackDir = new Vector2(1, AttackDir.y);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                AttackDir = new Vector2(1, 1);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                AttackDir = new Vector2(1, -1);
            }
            else
            {
                AttackDir = new Vector2(1, 0);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //AttackDir = new Vector2(AttackDir.x, 1);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AttackDir = new Vector2(-1, 1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                AttackDir = new Vector2(1, 1);
            }
            else
            {
                AttackDir = new Vector2(0, 1);
            }

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //AttackDir = new Vector2(AttackDir.x, -1);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AttackDir = new Vector2(-1, -1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                AttackDir = new Vector2(1, -1);
            }
            else
            {
                AttackDir = new Vector2(0, -1);
            }

        }
    }

    void UpdateSprite() {
        if (v_dir == 1)
        {
            mySpr.sprite = back;
        }
        else if(v_dir == -1)
        {
            mySpr.sprite = front;
        }
        if (isDirLeft == true && h_dir < 0)
        {
            mySpr.flipX = true;
        }
        else if(isDirRight == true && h_dir >= 0) {
            mySpr.flipX = false;
        }
    }

    void SetWeaponPosition() {
        // 공격 방향 정규화 -> 스케일링 -> 각도 계산 -> 위치 결정
        float angle = Mathf.Atan2(AttackDir.y, AttackDir.x) ;

        weaponContainer.transform.position = new Vector2(transform.position.x + Mathf.Cos(angle), transform.position.y + Mathf.Sin(angle));
        weaponContainer.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}
