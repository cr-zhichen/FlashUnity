using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game>
{
    private void Awake()
    {
        Debug.Log("进入游戏场景");
    }
}