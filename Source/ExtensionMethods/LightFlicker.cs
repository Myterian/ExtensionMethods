using System;
using FlaxEngine;
using FlaxEngine.Utilities;

namespace ExtensionMethods;

/// <summary>Creates a light flickering effect</summary>
public class LightFlicker : Script
{
    private Random Random;

    [ShowInEditor, Serialize, Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    private Light light;

    [ShowInEditor, Serialize, Tooltip("Minimum random light intensity")]
    private float minBrightness = 0f;

    [ShowInEditor, Serialize, Tooltip("Maximum random light intensity")]
    private float maxBrightness = 1f;

    [ShowInEditor, Serialize, Tooltip("How many times the light brightness should change per second."), Limit(min:1)]
    private int frequency = 20;

    [ShowInEditor, Serialize, Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern"), Range(0f, 1f)]
    private float smoothing = 0.5f;

    private float timer = 0;

    private float? averageBrightness;


    public override void OnUpdate()
    {
        light ??= Actor.As<Light>();
        Random ??= new();
        averageBrightness ??= (minBrightness + maxBrightness) * 0.5f;

        if (light == null)
            return;

        timer -= Time.DeltaTime;
        if (0f < timer)
            return;
        
        timer = 1f / frequency;
        
        float newBrightness = Random.NextFloat(minBrightness, maxBrightness);
        light.Brightness = Mathf.Lerp(newBrightness, averageBrightness.Value, smoothing);
    }
}
