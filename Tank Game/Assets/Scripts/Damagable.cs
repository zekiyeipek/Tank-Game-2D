using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public int MaxHealth = 5;
    [SerializeField]
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit;

    private void Start()
    {
        Health = MaxHealth;
    }
    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if(Health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }
}
