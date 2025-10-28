using System;
using FlaxEngine;

namespace ExtensionMethods;

/// <summary>Provides a countdown timer</summary>
public class FlaxTimer
{
    /// <summary>Indicates if the countdown has ended</summary>
    public bool HasEnded { get; private set; }

    /// <summary>The remaining time to completion</summary>
    public float RemainingTime => countdown;

    private float initalTime;
    private float countdown;

    /// <summary>Event for when the countdown has ended</summary>
    public event Action OnEnded;

    /// <summary>Starts the timer. Will stop automatically after countdown is over. Does nothing if the countdown already started.</summary>
    public void Start()
    {
        Scripting.Update -= Tick;
        Scripting.Update += Tick;
    }

    /// <summary>Stops the timer manually.</summary>
    /// <param name="invokeEnded">Indicates if the OnEnded event should be invoked</param>
    public void Stop(bool invokeEnded = true)
    {
        Scripting.Update -= Tick;
        if (invokeEnded) OnEnded?.Invoke();
    }

    /// <summary>Updates the timer</summary>
    private void Tick()
    {
        countdown -= Time.DeltaTime;
        if (0f < countdown) return;

        countdown = 0f;
        HasEnded = true;
        OnEnded?.Invoke();
        Stop();
    }

    /// <summary>Resets timer to creation state, so it can be started again</summary>
    public void Reset()
    {
        countdown = initalTime;
        HasEnded = false;
    }

    /// <summary>Resets timer to creation date,  so it can be started again</summary>
    /// <param name="durationSeconds">The new duration of the countdown in seconds</param>
    public void Reset(float durationSeconds)
    {
        initalTime = durationSeconds;
        countdown = durationSeconds;
        HasEnded = false;
    }

    /// <summary>Creates a new instance of FlaxTimer</summary>
    /// <param name="durationSeconds">The time the countdown takes to finish in seconds</param>
    public FlaxTimer(float durationSeconds)
    {
        initalTime = durationSeconds;
        countdown = durationSeconds;
        HasEnded = false;
    }

    /// <summary>Stops the timer and cleans any event subscribers. Make sure to call this when disabling / disposing the parent class.</summary>
    public void Dispose()
    {
        Stop();
        OnEnded = null;
    }
}
