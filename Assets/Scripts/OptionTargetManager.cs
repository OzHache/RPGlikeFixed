using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTargetManager : MonoBehaviour
{
    private Vector2 playerLoc;
    public bool upToDate = false;
    public List<Location> locations = new List<Location>();
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
        playerLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerLoc = transform.position;
        if (!upToDate)
        {
            generateOptions();
        }
    }

    private void generateOptions()
    {
        locations.Clear();
        //start circle 3 times
        Vector2 startPoint = playerLoc + new Vector2(-3, +3);//upper left
        Vector2 endPoint = playerLoc + new Vector2(+3, -3); //lower left
        Vector2 checkPos = startPoint;

        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                checkPos = startPoint + new Vector2(x, y);
                Vector2 direction = checkPos - playerLoc;
                direction = direction.normalized;
                float distance = Vector2.Distance(playerLoc, checkPos);
                RaycastHit2D hit = Physics2D.Raycast(playerLoc, direction, distance);
                RaycastHit2D hitBack = Physics2D.Raycast(checkPos, -direction, distance);

                if (hit )
                {
                    Debug.Log(checkPos);
                    Debug.Log("Hit?: " + hit);
                    Debug.Log(hit.collider.name);
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        if (hit.distance < 1.5f)
                            locations.Add(new Location(checkPos, TargetFrame.Attack));
                        else
                            locations.Add(new Location(checkPos, TargetFrame.Magic));
                    }
                }

            }
        }
        PopulateOptions();

    }

    private void PopulateOptions()
    {
        foreach (var loc in locations)
        {
            GameObject gameObject = Instantiate(target, loc.pos, Quaternion.identity);
            Debug.Log("generated");
        }
        upToDate = true;
    }
}
