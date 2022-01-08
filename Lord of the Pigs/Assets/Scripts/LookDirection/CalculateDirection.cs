using UnityEngine;

public static class CalculateDirection
{
    public static LookDirectionType GetDir(Vector3 dir)
    {
        var isLookDirectionHorizontal = Mathf.Abs(dir.x) > Mathf.Abs(dir.y);
        if (isLookDirectionHorizontal)
            return dir.x > 0 ? LookDirectionType.Right : LookDirectionType.Left;

        return dir.y > 0 ? LookDirectionType.Up : LookDirectionType.Down;
    }
}