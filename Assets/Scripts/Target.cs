using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TargetFrame { Magic, Move, Attack, Available}

public class Target : MonoBehaviour
{
    private SpriteRenderer ren;
    public Sprite Magic;
    public Sprite Move;
    public Sprite Attack;
    public Sprite Available;
    public bool active = true;
    public float scaleSmall = .75f;
    public Transform player;
    private Collider2D collider;
    private Vector2 directionToPlayer;
    private Vector2 distanceToPlayer;
    public TargetFrame targetFrame = TargetFrame.Available;
    private bool attackMagic = false;

    // Start is called before the first frame update
    void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
        collider = gameObject.GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        if (active)
        {
            float scale = scaleSmall + Mathf.PingPong(Time.time, .25f);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void ChangeFrame(TargetFrame tf)
    {
        switch (tf){
            case TargetFrame.Attack:
                ren.sprite = Attack;
                break;
            case TargetFrame.Available:
                ren.sprite = Available;
                break;
            case TargetFrame.Magic:
                ren.sprite = Magic;
                break;
            case TargetFrame.Move:
                ren.sprite = Move;
                break;
        }
        targetFrame = tf;
    }
    public void ColliderSwitch(bool onOff)
    {
        collider.enabled = onOff;
    }

    internal void Sweep()
    {
        Vector3 direction = player.position - transform.position;
        float distance = Vector2.Distance(player.position, transform.position);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
        if (distance <= 1.75f && distance> 0)
        {
            ChangeFrame(TargetFrame.Move);
            if (hit)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    ChangeFrame(TargetFrame.Attack);
                }
                else if(hit.collider.CompareTag("Player"))
                {
                    ChangeFrame(TargetFrame.Move);
                    directionToPlayer = direction;
                }
                else
                {
                    ChangeFrame(TargetFrame.Available);
                }
            }
        }else if ((hit.distance  == 0 && hit.collider.CompareTag("Enemy")) && distance<5){
            ChangeFrame(TargetFrame.Magic);
              attackMagic = true;
        }else if (distance == 0)
        {
            ChangeFrame(TargetFrame.Magic);
            attackMagic = false;
        }
        else{
            ChangeFrame(TargetFrame.Available);
        }
        
    }
    private void OnMouseDown()
    {
        switch (targetFrame)
        {
            case TargetFrame.Move:
                GameManager.GetGameManager.Action(-directionToPlayer);
                break;
            case TargetFrame.Attack:
                GameManager.GetGameManager.Action();
                break;
            case TargetFrame.Magic:
                //attackMagic
                GameManager.GetGameManager.Action(attackMagic);
                break;
            case TargetFrame.Available:
                break;
        }
    }

}
