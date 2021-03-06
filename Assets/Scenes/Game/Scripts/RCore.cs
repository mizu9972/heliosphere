﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------
//ターゲットを回転させる中心となる親オブジェクトのスクリプト
//----------------------------------------------------------
public class RCore : MonoBehaviour, ChangeActiveInterface
{
    private float Angle = 0;//角度(度数法)
    private float Radian;//ラジアン角
    public float RotateSpeed = 0;//回転速度(inspectorで調整)

    private float AngleToRadian = Mathf.PI / 180.0f;//ラジアンに変換
    public bool isActive;
    private Transform MyTrans;
    // Start is called before the first frame update
    void Start()
    {
        MyTrans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            AddAngle();
        }
        Angle = Angle % 360;//360度を超えないように

        Radian = Angle * AngleToRadian;

        MyTrans.rotation = Quaternion.Euler(0, Angle, 0);
    }

    private void AddAngle()
    {
        Angle += RotateSpeed;//回転
    }
    public void ChangeActive()
    {
        isActive = !isActive;
    }

    public void AddScale(float _Scale)
    {
        MyTrans.transform.localScale += new Vector3(_Scale, _Scale, _Scale);
    }

    public List<GameObject> FriendsAllGetter()
    {
        //全ての子Friend取得
        List<GameObject> MyFriends = new List<GameObject>();
        foreach(Transform _Friend in transform)
        {
            if(_Friend.GetComponent<FriendScript>() != null)
            {
            MyFriends.Add(_Friend.gameObject);
            }
        }
        
        return MyFriends;
    }

    public List<GameObject> EnemiesAllGetter()
    {
        //全ての子Enemy取得
        List<GameObject> MyEnemies = new List<GameObject>();
        foreach(Transform _Enemy in transform)
        {
            if(_Enemy.GetComponent<EnemyScript>() != null)
            {
                MyEnemies.Add(_Enemy.gameObject);
            }
        }

        return MyEnemies;
    }
}
