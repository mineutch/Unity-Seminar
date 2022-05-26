using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    Rigidbody rb;
    int direction = 0;
    int speed = 10;
    int p = 0;//前後用
    float speedR = 4f;
    float step;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ここで移動を行う0,1,2,3で処理
        if (direction % 4 == 0 || direction % 4 == 2)
        {
            if (direction % 4 == 2)
            {//後ろ
                transform.position += new Vector3(-speed * p * Time.deltaTime, 0, 0);
            }
            else
            {//前
                transform.position += new Vector3(speed * p * Time.deltaTime, 0, 0);
            }
        }
        else if (direction % 4 == 1 || direction % 4 == 3)
        {
            if (direction % 4 == 1)
            {//後ろ
                transform.position += new Vector3(0, 0, -speed * p * Time.deltaTime);
            }
            else
            {//前
                transform.position += new Vector3(0, 0, speed * p * Time.deltaTime);
            }
        }
        step = speedR * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, (direction % 4) * 90f, 0), step);
    }

    //前進ボタンの押下イベント
    public void forwardButtonDown()
    {
        p = 1;
    }

    public void forwardButtonUp()
    {
        p = 0;
    }

    public void backButtonDown()
    {
        p = -1;
    }

    public void backButtonUp()
    {
        p = 0;
    }
    public void rightButton()
    {
        if (direction == 4) direction = 0;
        direction += 1;
    }
    public void leftButton()
    {
        if (direction == 0) direction = 4;
        direction -= 1;
    }


}
