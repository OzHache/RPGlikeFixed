using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public PlayerController enemy;
    private int steps = 2;
    private float thinkTimer = 0;
    public bool myTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thinkTimer > 0f && myTurn)
        {
            thinkTimer -= Time.deltaTime;
        }
        else if (myTurn)
        {
            ActivateTurn();
            steps--;
            if (steps == 0)
            {
                myTurn = false;
            }
        }
    }
    private void Reset()
    {
        enemy = GetComponent<PlayerController>();
    }


    public void ActivateTurn()
    {
        //decision tree
        //if health < 50%
        if(enemy.hp < 10)
        {
            Move(true);
            return;
        }
            //if within move away

        
    }
    private void Move(bool away)
    {
        
    }

}
