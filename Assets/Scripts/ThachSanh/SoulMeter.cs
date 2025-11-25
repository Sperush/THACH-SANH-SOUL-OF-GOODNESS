using System;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class SoulMeter : MonoBehaviour
{
    [Range(0, 100)] public float value = 100f;
    public event Action<float> OnValueChanged;


    public void Increase(float amount)
    {
        value = Mathf.Clamp(value + amount, 0, 100);
        OnValueChanged?.Invoke(value);
    }


    public void Decrease(float amount)
    {
        value = Mathf.Clamp(value - amount, 0, 100);
        OnValueChanged?.Invoke(value);
    }
}
