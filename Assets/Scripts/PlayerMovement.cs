using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float speedMultiplier = 5f;
    private float timeMoving;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private Animator animator;
    private int isWalkingHash; // For optimization
    private bool isWalking;
    public Vector2 lookDirection { get; private set; } = Vector2.right; // Defaults to right

    private void Start()
    {
        isWalkingHash = Animator.StringToHash("IsWalking");
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(h, v);
        lookDirection = moveInput;
        if (moveInput != Vector2.zero)
        {
            if (!Physics2D.Raycast(transform.position, moveInput, 1f, obstacleLayer))
            {
                timeMoving += Time.deltaTime;
                // TODO: Let player "slide" by wall if pressing two keys but only one way is blocked
                // e.g.: there's a wall to the right, player is nearby, presses W+D --> goes up instead of not moving
                float speed = speedCurve.Evaluate(timeMoving);
                Vector2 moveVector = speed * speedMultiplier * Time.deltaTime * moveInput.normalized;
                if (moveVector.x < 0) transform.eulerAngles = new Vector2(0, 180);
                else transform.eulerAngles = new Vector2(0, 0);

                transform.Translate(moveVector, Space.World);
                isWalking = true;
            }
        }
        else
        {
            isWalking = false;
            timeMoving = 0f;
        }
        animator.SetBool(isWalkingHash, isWalking);
    }

}
