using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector3 Wrap(Vector3 v, Vector3 min, Vector3 max)
    {
        Vector3 result = v;

        result.x = (result.x > max.x) ? min.x : result.x;
        result.x = (result.x < min.x) ? max.x : result.x;

        result.y = (result.y > max.y) ? min.y : result.y;
        result.y = (result.y < min.y) ? max.y : result.y;

        result.z = (result.z > max.z) ? min.z : result.z;
        result.z = (result.z < min.z) ? max.z : result.z;

        return result;
    }

    public static float Dot(Vector3 v1, Vector3 v2)
    {
        return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
    }
}
