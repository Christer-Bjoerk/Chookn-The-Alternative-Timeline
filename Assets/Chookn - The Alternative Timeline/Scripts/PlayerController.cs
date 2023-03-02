using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveVal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void OnMovement(InputValue value)
    {
        moveVal = value.Get<Vector3>();
    }

    private void Movement()
    {

        if (moveVal != Vector3.zero)
        {
            rb.velocity = (moveVal * speed);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Rotation()
    {
        if (moveVal.x < 0)
        {
            Quaternion desiredRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 1f);
        }
        else if (moveVal.x > 0)
        {
            Quaternion desiredRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 1f);
        }
    }

}
