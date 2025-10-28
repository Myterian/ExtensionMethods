using FlaxEngine;

namespace ExtensionMethods;

/// <summary>A collection of handy methods for audio sources</summary>
public static class AudioSourceExtension
{
    // Copy from indiegamedev @ stackoverflow
    /// <summary>Returns true if pitch is negative</summary>
    public static bool IsReversePitch(this AudioSource source)
    {
        return source.Pitch < 0f;
    }

    /// <summary>Calculate the remainingTime of the given AudioSource</summary>
    public static float GetClipRemainingTime(this AudioSource source)
    {
        // Calculate the remainingTime of the given AudioSource,
        // if we keep playing with the same pitch.
        float remainingTime = (source.Clip.Length - source.Time) / source.Pitch;
        return source.IsReversePitch() ?
            (source.Clip.Length + remainingTime) :
            remainingTime;
    }
}
