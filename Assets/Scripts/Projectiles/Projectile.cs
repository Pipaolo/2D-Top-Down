using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private float _travelDistance;
    private float _damageAmount;
    private Vector2 _startingPosition;
    private bool _fromPlayer;
    
    [SerializeField]
    private float damageRadius;

    private Rigidbody2D _rb;
    private bool _hasHitWall;

    [SerializeField]
    private LayerMask whatIsWall;
    
    [SerializeField]
    private LayerMask whatIsDamageable;

    [SerializeField] private LayerMask whatIsEnemy;
    
    [SerializeField]
    private Transform damagePosition;

    private Action<Projectile> _hitAction;
    private Action<GameObject> _damageAction;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
   

    }

    private void FixedUpdate()
    {
        if (_hasHitWall) return;
        
        var currentDamagePosition = damagePosition.position;
        Collider2D damageHit = Physics2D.OverlapCircle(currentDamagePosition, damageRadius, whatIsDamageable);
        Collider2D wallHit = Physics2D.OverlapCircle(currentDamagePosition, damageRadius, whatIsWall);

        if (damageHit)
        {
            _hitAction(this);
            var damageableScript = damageHit.GetComponentInChildren<IDamageable>();
            damageableScript?.Damage(_damageAmount);
        }

        if (!wallHit) return;
        
        _hitAction(this);
    }
    
    public void FireProjectile(
        Action<Projectile> hitAction,
        Vector2 startingPosition,
        float speed, 
        float damage,
        Action<GameObject> damageAction = null
    )
    {
        _startingPosition = startingPosition;
        _speed = speed;
        _damageAmount = damage;
        _hitAction = hitAction;
        _damageAction = damageAction;
            
        _hasHitWall = false;

        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(_startingPosition * _speed, ForceMode2D.Impulse);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
