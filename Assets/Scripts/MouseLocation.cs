using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocation : MonoBehaviour
{
    public Vector2 mouseLocation;
    public Vector2 worldPosition;
    public Vector2 tilePosition;

    private void Update()
    {
        mouseLocation = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(mouseLocation);
        tilePosition = new Vector2(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y));
        
    }
}
