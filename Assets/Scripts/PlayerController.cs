using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// update ���� �Լ� �빮�ڷ� ����
// update �ܺ� �� ��ũ��Ʈ �ܺ� ���� �ҹ��� ����
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

   
    bool isDirLeft;
    bool isDirRight;
    bool isDirUp;
    bool isDirDown;

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
        // �ʱ� ��������Ʈ ������ �Ʒ�
        isDirLeft = false;
        isDirRight = false;
        isDirUp = false;
        isDirDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RestoreSTA();
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



    void MoveLeft() {
        rigid.velocity = new Vector2(rigid.velocity.x - 3*Time.deltaTime* curSpeed, rigid.velocity.y);
        if (Mathf.Abs(rigid.velocity.x) > curSpeed) rigid.velocity = new Vector2(-curSpeed, rigid.velocity.y);
            
    }
    void MoveRight()
    {
        rigid.velocity = new Vector2(rigid.velocity.x + 3*Time.deltaTime * curSpeed, rigid.velocity.y);
        if (Mathf.Abs(rigid.velocity.x) > curSpeed) rigid.velocity = new Vector2(curSpeed, rigid.velocity.y);
    }
    void MoveUp()
    {
        rigid.velocity = new Vector2(rigid.velocity.x , rigid.velocity.y + 3*Time.deltaTime * curSpeed);
        if (Mathf.Abs(rigid.velocity.y) > curSpeed) rigid.velocity = new Vector2(rigid.velocity.x, curSpeed);
    }
    void MoveDown()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y - 3*Time.deltaTime * curSpeed);
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
        if (isDirLeft = Input.GetKey(KeyCode.LeftArrow)) 
        { 
            MoveLeft();
        }
        if (isDirRight = Input.GetKey(KeyCode.RightArrow)) 
        {
            MoveRight();
        }

        if (isDirUp = Input.GetKey(KeyCode.UpArrow)) 
        {
            MoveUp();
        }

        if (isDirDown = Input.GetKey(KeyCode.DownArrow)) 
        {
            MoveDown();
        }
 
        // ���� �������� : ������ ���� ���� �ʰ� x��y�� �������� ������ �� ���⿡ ���ؼ��� �����ϱ�
        // ���ȿ�� -> ������ ������ �� �־� ���� ���� ���� ������ ������

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
}
