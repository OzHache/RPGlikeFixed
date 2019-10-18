using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public PlayerController enemy;
    public static GameManager GetGameManager;
    public TargetManager targetManager;
    public int step = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetGameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (step >= 3)
        {
            step = 0;
            Debug.Log("ENEMY TURN");
            Enemy();
            ManageBuffs();
        }
        
    }

    private void Enemy()
    {
        //activate Enemy AI
        step++;

    }

    //move
    public void Action(Vector2 moveTo)
    {
        player.MoveTo(moveTo);
        targetManager.rebuild = true;
        step++;
    }
    //attack
    public void Action()
    {
        //attack enemy
        enemy.Defend();
        step++;
    }
    //magic
    public void Action(bool attackMagic)
    {
        if (attackMagic)
        {
            enemy.Magic(attackMagic);
        }
        else
        {
            player.Magic(attackMagic);
        }
        step++;
    }

    private void ManageBuffs()
    {
        player.BuffTimer();
        enemy.BuffTimer();
        
    }
}
