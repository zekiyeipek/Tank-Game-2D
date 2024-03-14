using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;
    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rdbody;

    public UnityEvent OnHit = new UnityEvent();
    private void Awake()
    {
        rdbody = GetComponent<Rigidbody2D>();
    }
    public void Initialize()
    {
        startPosition = transform.position;
        rdbody.velocity = transform.up * speed;
    }
    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rdbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider" + collision.name);
        OnHit?.Invoke();
        var damagable = collision.GetComponent<Damagable>();
        if(damagable != null)
        {
            damagable.Hit(damage);
        }
        DisableObject();
    }
}
