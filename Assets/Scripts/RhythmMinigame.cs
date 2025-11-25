using System;
using System.Collections.Generic;
using UnityEngine;

public class RhythmMinigame : MonoBehaviour
{
    public SoulMeter soulMeter;
    public float hitWindow = 0.15f;
    public KeyCode[] keys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };


    private Queue<float> beatQueue = new Queue<float>();
    private float songTimer;


    public event Action OnSuccess;
    public event Action OnFail;


    void Update()
    {
        songTimer += Time.deltaTime;


        if (beatQueue.Count > 0 && Mathf.Abs(songTimer - beatQueue.Peek()) <= hitWindow)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in keys)
                {
                    if (Input.GetKeyDown(key))
                    {
                        beatQueue.Dequeue();
                        soulMeter.Increase(3);
                        OnSuccess?.Invoke();
                        return;
                    }
                }
            }
        }
        else if (beatQueue.Count > 0 && songTimer > beatQueue.Peek() + hitWindow)
        {
            beatQueue.Dequeue();
            soulMeter.Decrease(2);
            OnFail?.Invoke();
        }
    }


    public void LoadBeats(float[] beats)
    {
        beatQueue.Clear();
        foreach (float b in beats) beatQueue.Enqueue(b);
        songTimer = 0;
    }
}