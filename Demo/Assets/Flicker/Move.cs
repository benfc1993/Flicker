using System;
using UnityEngine;

[Serializable]
public class Move
{
    public enum Type { FF, S };
    public Type type;
    public enum Dir { W, C };
    public Dir dir;
    public Vector2 start;
    public Vector2 end;

    public Move(Vector2 start)
    {
        this.start = start;
        type = Type.FF;
        dir = Dir.W;
    }
}
