using FlaxEngine;

namespace ExtensionMethods;

/// <summary>A collection of handy methods for Vector3</summary>
public static class Vector3Extension
{
    // NOTE: Flax provides own implementation with Vector3.Absolute
    // public static Vector3 Abs( this Vector3 v )
    // {
    //     return new Vector3( Mathf.Abs( v.X ), Mathf.Abs( v.Y ), Mathf.Abs( v.Z ));
    // }

    /// <summary>Calculates a normal based on at least three points in space. Points need to be assigned in clockwise order, world z axis being 12 and world x axis being 3 oclock.</summary>
    /// <param name="normal">The vector that gets written to</param>
    /// <param name="vertices">Points in space, in clockwise order</param>
    /// <returns>Vector3</returns>
    public static Vector3 GetPolygonNormal(this Vector3 normal, Vector3[] vertices)
    {
        // https://www.opengl.org/wiki/Calculating_a_Surface_Normal
        // Newell's Method for calculating the normal from an arbitrary number of points

        Vector3 currVert, nextVert;

        for (int i = 0; i < vertices.Length; i++)
        {
            currVert = vertices[i];
            nextVert = vertices[(i + 1) % vertices.Length];

            normal.X += (currVert.Y - nextVert.Y) * (currVert.Z + nextVert.Z);
            normal.Y += (currVert.Z - nextVert.Z) * (currVert.X + nextVert.X);
            normal.Z += (currVert.X - nextVert.X) * (currVert.Y + nextVert.Y);
        }

        return normal.Normalized;
    }

    /// <summary>Returns a direction vector on the xz plane (y is flattened).</summary>
    /// <param name="direction">The 3d direction to convert to a 2d xz plane direction</param>
    /// <returns>Vector3</returns>
    public static Vector3 DirectionXZ(this Vector3 direction)
    {
        Vector3 newDirection = direction;
        newDirection.Y = 0f;
        return newDirection;
    }

    /// <summary>Returns a normalized direction vector on the xz plane (y is flattened).</summary>
    /// <param name="direction">The 3d direction to convert to a 2d xz plane direction</param>
    /// <returns>Vector3</returns>
    public static Vector3 DirectionXZNormalized(this Vector3 direction)
    {
        Vector3 newDirection = direction;
        newDirection.Y = 0f;
        newDirection.Normalize();
        return newDirection;
    }
}
