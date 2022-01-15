using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder : MonoBehaviour
{    
    [SerializeField]
    private float _initSpeed = 5;

    private Rigidbody2D _rb;
    private Collider2D _collider;

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        CheckVelocity();
    }
    
    private void CheckVelocity()
    {
        Vector2 velocity = _rb.velocity;
        float currentSpeed = velocity.magnitude;
        _rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BlockTile blockTileHit;
        if (!other.collider.TryGetComponent(out blockTileHit))
        {
            return;
        }

        ContactPoint2D contactPoint = other.contacts[0];
        blockTileHit.OnHitCollision(contactPoint);
    }

    public void Hide()
    {
        _collider.enabled = false;
        gameObject.SetActive(false);
    }
}
