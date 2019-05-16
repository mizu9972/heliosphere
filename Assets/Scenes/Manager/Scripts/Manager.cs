﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject gameobject;
    [SerializeField, Header("オプションボタン全体")]
    GameObject Option;
    [SerializeField, Header("最初に選択状態にするボタン")]
    GameObject InitialButton;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameobject);
    }
    private void Update()
    {
        //ESCキーが押されたらオプション呼び出し
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CallOption();
        }
    }

    void CallOption()
    {
        //オプションボタン呼び出し

        var Selectable = InitialButton.GetComponent<IOnSelected>();

        Option.SetActive(true);//オプション有効化

        if (Selectable != null)
        {
            //ボタン選択状態に
            InitialButton.GetComponent<IOnSelected>().OnSelected();
        }

    }
}
