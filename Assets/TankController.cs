using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [Tooltip("Maximum slope the character can jump on")] [Range(5f, 60f)]
    public float slopeLimit = 0.5f;

    [Tooltip("Move speed in meters/second")]
    public float moveSpeed = 4f;

    [Tooltip("Turn speed in degrees/second, left (+) or right (-)")]
    public float turnSpeed = 100;

    [Tooltip("Whether the character can jump")]
    public bool allowJump = true;

    [Tooltip("Upward speed to apply when jumping in meters/second")]
    public float jumpSpeed = 4f;

    public bool IsGrounded { get; private set; }
    public float ForwardInput { get; set; }
    public float TurnInput { get; set; }
    public bool JumpInput { get; set; }

    new private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        ProcessActions();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log(collisionInfo.collider.name);
        IsGrounded = true;
    }

    /// <summary>
    /// Processes input actions and converts them into movement
    /// </summary>
    private void ProcessActions()
    {
        // Turning
        if (TurnInput != 0f)
        {
            float angle = Mathf.Clamp(TurnInput, -1f, 1f) * turnSpeed;
            transform.Rotate(Vector3.forward, Time.fixedDeltaTime * angle);
        }

        // Movement
        Vector3 move = transform.up * Mathf.Clamp(ForwardInput, -1f, 1f) *
                       moveSpeed * Time.fixedDeltaTime;
        rigidbody.MovePosition(transform.position + move);

        // Jump
        if (JumpInput && allowJump  && IsGrounded)
        {
            IsGrounded = false;
            rigidbody.AddForce(transform.forward * jumpSpeed, ForceMode.VelocityChange);
        }

    }
}
