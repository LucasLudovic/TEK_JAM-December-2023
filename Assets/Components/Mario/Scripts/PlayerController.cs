using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5F;
    public float jumpForce = 10F;
    public int healthPoints = 3;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isGrounded = true;
    private float _timer;
    private float _invincibleTimer;
    private bool _isInvincible = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();
        Jumping();
        Invincibility();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !_isInvincible)
        {
            print("Here");
            healthPoints -= 1;
            _isInvincible = true;
            _timer = 0;
        }
    }

    private void Moving()
    {
        var velocity = _rb.velocity;
        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal == 0)
        {
            _animator.SetBool("IsMoving", false);
            return;   
        }
        _animator.SetBool("IsMoving", true);
        _rb.velocity = new Vector2(speed, velocity.y);
        _spriteRenderer.flipX = horizontal < 0 ? true : false;
        _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);
    }

    private void Jumping()
    {
        var velocity = _rb.velocity;
        var space = Input.GetKey(KeyCode.Space);

        if (!space || !_isGrounded)
        {
            _animator.SetBool("IsJumping", false);
            return;   
        }
        _animator.SetBool("IsJumping", true);
        _isGrounded = false;
        _rb.velocity = new Vector2(velocity.x, jumpForce);
    }

    private void Invincibility()
    {
        _timer += Time.deltaTime;
        _invincibleTimer += Time.deltaTime;
        if (!_isInvincible)
            return;
        if (_timer > 1F)
        {
            _isInvincible = false;
            _spriteRenderer.color = new Color(255, 255, 255, 255);
            return;
        }

        if (_invincibleTimer < 0.1F)
            return;
        print("HERE2");
        _spriteRenderer.color = new Color(255, 255, 255, _spriteRenderer.color.a == 1 ? 0.5F : 1);
        _invincibleTimer = 0;
    }
}
