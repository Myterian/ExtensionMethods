using System;
using FlaxEngine;

namespace ExtensionMethods;

/// <summary>A collection of handy methods for int32</summary>
public static class IntExtension
{
    /// <summary>Loops the integer value, so it's never smaller than 0 and never larger than maxValue (exclusive)</summary>
    /// <param name="value">The value to repeat</param>
    /// <param name="maxValue">The max value (exclusive)</param>
    /// <returns>int</returns>
    public static int Repeat(this int value, int maxValue)
    {
        // return value % Math.Max( maxValue, 1 );
        return value - Mathf.FloorToInt((float)value / maxValue) * maxValue;
    }

    /// <summary>Returns a number between 0 and maxValue (inclusive), but is not the current number</summary>
    /// <param name="value">Current number</param>
    /// <param name="maxValue">Return value will not be larger than this</param>
    /// <returns>int</returns>
    public static int RepeatAndExcludeCurrent(this int value, int maxValue)
    {
        // return ( value + new RandomStream().RandRange( 1, maxValue + 1 )).Repeat( maxValue );
        return (value + (int)new Random().NextInt64(1, (long)maxValue + 1)).Repeat(maxValue + 1);
    }

    /// <summary>Returns a number between minValue (inclusive) and maxValue (inclusive), but is not the current number</summary>
    /// <param name="value">Current number</param>
    /// /// <param name="minValue">Return value will not be smaller than this</param>
    /// <param name="maxValue">Return value will not be larger than this</param>
    /// <returns>int</returns>
    public static int RepeatAndExcludeCurrent(this int value, int minValue, int maxValue)
    {
        // Creates 0 based postive range
        int range = maxValue - minValue;

        // Account for incorrect range when numbers are signed differently
        if ((minValue < 0) != (maxValue < 0))
            range++;

        return (value + new RandomStream().RandRange(0, range + 1)).Remap(0, range, minValue, maxValue);
    }

    /// <summary>Remapping a value from original to new range</summary>
    /// <param name="value">Value that has to be remapped into the new range</param>
    /// <param name="oldMin">Min value of old range</param>
    /// <param name="oldMax">Max value of old range</param>
    /// <param name="newMin">Min value of new range</param>
    /// <param name="newMax">Max value of new range</param>
    /// <returns>int</returns>
    public static int Remap(this int value, int oldMin, int oldMax, int newMin, int newMax)
    {
        // Prevent dividing by 0
        if (oldMax == oldMin)
            return value;

        // Find out how far the value is into the first range
        // Scale the distance by the ration of sizes
        // That is how far the value is into the new range
        return newMin + (value - oldMin) * (newMax - newMin) / (oldMax - oldMin);
    }

    /// <summary>Compares the sign of two integers. True when both integers are signed the same</summary>
    /// <param name="value">Integer</param>
    /// <param name="compareTo">Integer to compare to</param>
    /// <returns>bool</returns>
    public static bool IsSameSign(this int value, int compareTo)
    {
        return (value < 0) == (compareTo < 0);
    }

    /// <summary>Checks if an int value is in a specified range.</summary>
    /// <param name="value">Integer</param>
    /// <param name="bottom">Lower end of the range.</param>
    /// <param name="top">Upper end of the range.</param>
    /// <returns>true if in range, otherwise false.</returns>
    [Obsolete("Use built-in Mathf.IsInRange")]
    public static bool IsInRange(this int value, int bottom, int top)
    {
        return bottom <= value && value <= top;
    }

    /// <summary>Checks if an int value is in a specified range starting at 0.</summary>
    /// <param name="value">Integer</param>
    /// <param name="top">Upper end of the range.</param>
    /// <returns>true if in range, otherwise false.</returns>
    public static bool IsInRange(this int value, int top)
    {
        return 0 <= value && value <= top;
    }

    /// <summary>Divides a value by a denominator, but with zero-division safety. Returns value if zero-division is detected.</summary>
    /// <param name="value">The numerator value, that will be divided</param>
    /// <param name="denominator">the denominator value, that will be divided by</param>
    /// <returns>int</returns>
    public static int SafeDivision(this int value, int denominator)
    {
        return denominator == 0 ? value : value / denominator;
    }
}
