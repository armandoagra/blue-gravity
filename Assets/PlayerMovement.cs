using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float speed = 5f;
    public Vector2 lookDirection { get; private set; } = Vector2.right; // Defaults to right


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(h, v).normalized;
        lookDirection = moveInput;
        if (moveInput != Vector2.zero)
        {
            if (!Physics2D.Raycast(transform.position, moveInput, 1f, obstacleLayer))
            {
                // TODO: Let player "slide" by wall if pressing two keys but only one way is blocked
                Vector2 moveVector = speed * Time.deltaTime * moveInput;
                transform.Translate(moveVector);
            }
        }
    }
}
