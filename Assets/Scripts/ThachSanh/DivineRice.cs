using System;
using UnityEngine;
using UnityEngine.Events;

public class DivineRice : MonoBehaviour
{
    public float healAmount = 30f;


    public void Use(GameObject target)
    {
        if (target.TryGetComponent(out PlayerHealth hp))
        {
            hp.Heal(healAmount);
        }
    }
}
