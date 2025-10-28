using FlaxEngine;

namespace ExtensionMethods;

/// <summary>A collection of handy methods for Curves</summary>
public static class CurveExtension
{
    /// <summary>Returns wether or not the animation curve has reached it's end</summary>
    /// <param name="curve">The curve to evaluate</param>
    /// <param name="time">The current evaluation time for the animation curve</param>
    /// <returns>bool</returns>
    public static bool HasEnded<T>(this BezierCurve<T> curve, float time) where T : new()
    {
        return curve.Keyframes[curve.Keyframes.Length - 1].Time < time && Mathf.Approximately(curve.Keyframes[curve.Keyframes.Length - 1].Time, time);
    }

    /// <summary>Returns wether or not the animation curve has reached it's end</summary>
    /// <param name="curve">The curve to evaluate</param>
    /// <param name="time">The current evaluation time for the animation curve</param>
    /// <returns>bool</returns>
    public static bool HasEnded<T>(this LinearCurve<T> curve, float time) where T : new()
    {
        return curve.Keyframes[curve.Keyframes.Length - 1].Time < time && Mathf.Approximately(curve.Keyframes[curve.Keyframes.Length - 1].Time, time);
    }
}
