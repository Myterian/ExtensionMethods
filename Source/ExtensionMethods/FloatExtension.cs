using System;
using FlaxEngine;

namespace ExtensionMethods;

/// <summary>A collection of handy methods for float</summary>
public static class FloatExtension
{
    /// <summary>Checks if a float is within the min and max value (inclusive)</summary>
    /// <param name="value">Value that has to be checked</param>
    /// <param name="min">Min value of range</param>
    /// <param name="max">Max value of range</param>
    /// <returns>bool</returns>
    [Obsolete("Use built-in Mathf.IsInRange")]
    public static bool IsInRange(this float value, float min, float max)
    {
        return (value - min) * (max - value) >= Mathf.Epsilon;
    }

    /// <summary>Remapping a value from it's original to a new range</summary>
    /// <param name="value">Value that has to be remapped into the new range</param>
    /// <param name="oldMin">Min value of old range</param>
    /// <param name="oldMax">Max value of old range</param>
    /// <param name="newMin">Min value of new range</param>
    /// <param name="newMax">Max value of new range</param>
    /// <returns>float</returns>
    public static float Remap(this float value, float oldMin, float oldMax, float newMin, float newMax)
    {
        // Prevents dividing by 0
        if (Mathf.Approximately(oldMax, oldMin))
            return value;

        // NOTE: A way to do the stuff below, but more readable would be:
        // x = value / (oldMax - oldMin)  <- Find out how much we are in old range in percent
        // Mathf.Lerp( newMin, newMax, x) <- This returns the new range

        // Find out how far the value is into the first range
        // Scale the distance by the ration of sizes
        // That is how far the value is into the new range
        return newMin + (value - oldMin) * (newMax - newMin) / (oldMax - oldMin);
    }

    /// <summary>Remapping a value from it's original range to 0 - 1 range</summary>
    /// <param name="value">Value that has to be remapped</param>
    /// <param name="oldMin">Min value of old range</param>
    /// <param name="oldMax">Max value of old range</param>
    /// <returns>float</returns>
    public static float Remap01(this float value, float oldMin, float oldMax)
    {
        // return Remap(value, oldMin, oldMax, 0f, 1f);
        return Mathf.Remap(value, oldMin, oldMax, 0f, 1f);
    }

    /// <summary>Remapping a value from it's original to a new range with custom mid point</summary>
    /// <param name="value">Value that has to be remapped into the new range</param>
    /// <param name="oldMin">Min value of old range</param>
    /// <param name="oldMax">Max value of old range</param>
    /// <param name="newMin">Min value of new range</param>
    /// <param name="newMax">Max value of new range</param>
    /// <param name="newCenter">Neutral point of new range</param>
    /// <returns>float</returns>
    [Obsolete("Use built-in Mathf.Remap instead")] 
    public static float Remap(this float value, float oldMin, float oldMax, float newMin, float newMax, float newCenter)
    {
        // Prevents dividing by 0
        if (Mathf.Approximately(oldMax, oldMin))
            return value;

        // Calculate how much we are in the old range in percent ( 0-1 range )
        float percentageOfOldRange = value;
        if (Mathf.Sign(oldMin) != Mathf.Sign(oldMax))
            percentageOfOldRange += 1f;

        percentageOfOldRange /= oldMax - oldMin;

        // Setup percentage value for how far we are in lower and upper range
        float percentageInLowerRange = percentageOfOldRange * 2f;
        float percentageInUpperRange = percentageOfOldRange * 2f - 1f;
        float output;

        // Uses lower or upper range, depending if we were below or above mid point of old range
        if (percentageOfOldRange.IsInRange(0f, 0.5f))
            output = Mathf.Lerp(newMin, newCenter, percentageInLowerRange);
        else
            output = Mathf.Lerp(newCenter, newMax, percentageInUpperRange);

        // Clamp it, because sometimes funky results happen
        return Mathf.Clamp(output, newMin, newMax);
    }

    /// <summary>Divides a value by a denominator, but with zero-division safety. Returns value if zero-division is detected.</summary>
    /// <param name="value">The numerator value, that will be divided</param>
    /// <param name="denominator">the denominator value, that will be divided by</param>
    /// <returns>float</returns>
    public static float SafeDivision(this float value, float denominator)
    {
        return Mathf.Approximately(0f, denominator) ? value : value / denominator;
    }
}
