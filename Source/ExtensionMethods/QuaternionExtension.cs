using FlaxEngine;

namespace byteslider.ExtensionMethods;

/// <summary>A collection of handy methods for Quaternions</summary>
public static class QuaternionExtension
{
    /// <summary>Clamps a quaternion to the defined bounding range.</summary>
    /// <param name="q">The quaternion to clamp</param>
    /// <param name="bounds">The range to clamp to. Note: If i.e. the x-axis is set to 20, then the quaterions x-axis gets clamped between -20 to 20.</param>
    /// <returns>Quaternion</returns>
    public static Quaternion ClampRotation(this Quaternion q, Vector3 bounds)
    {
        q.X /= q.W;
        q.Y /= q.W;
        q.Z /= q.W;
        q.W = 1.0f;

        float angleX = 2.0f * Mathf.RadiansToDegrees * Mathf.Atan(q.X);
        angleX = Mathf.Clamp(angleX, -bounds.X, bounds.X);
        q.X = Mathf.Tan(0.5f * Mathf.DegreesToRadians * angleX);

        float angleY = 2.0f * Mathf.RadiansToDegrees * Mathf.Atan(q.Y);
        angleY = Mathf.Clamp(angleY, -bounds.Y, bounds.Y);
        q.Y = Mathf.Tan(0.5f * Mathf.DegreesToRadians * angleY);

        float angleZ = 2.0f * Mathf.RadiansToDegrees * Mathf.Atan(q.Z);
        angleZ = Mathf.Clamp(angleZ, -bounds.Z, bounds.Z);
        q.Z = Mathf.Tan(0.5f * Mathf.DegreesToRadians * angleZ);

        Quaternion output = Quaternion.Normalize(q);
        return output;
    }
}

