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

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
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
    }
}
