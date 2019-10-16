using System;
using UnityEngine;

public class Location
{
    public Vector2 pos;
    public TargetFrame tf;

    public Location(Vector2 Position, TargetFrame targetFrame)
    {
        pos = Position;
        tf = targetFrame;
    }
}
