using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    private Vector3 moveVal;

    // TODO
    // Walk left & right

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(moveVal * Time.deltaTime * speed);
    }

    private void OnMovement(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }


}
