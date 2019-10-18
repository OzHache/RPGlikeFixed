using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hp;
    public int mp;
    public int AC;
    public int buffed;
    [SerializeField] MoveableCharacter moveableCharacter;
    //collection of potions

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //check for movement
        //check for buffed turn timer;


    }

    internal void MoveTo(Vector2 moveTo)
    {
        moveableCharacter.Move(moveTo);
    }

    internal void Defend()
    {
        int atk = UnityEngine.Random.Range(0, 10);
        if (atk < AC)
        {
            hp--;
        }
    }

    internal void Magic(bool attackMagic)
    {
        if (attackMagic)
        {
            int atk = UnityEngine.Random.Range(0, 10);
            if (atk < AC-2)
            {
                hp-=2;
            }
        }
        else if (buffed == 0)
        {
            AC++;
        }
    }

    internal void BuffTimer()
    {
        if(buffed > 0)
        {
            buffed--;
            if (buffed == 0)
            {
                AC--;
            }
        }
    }
}
