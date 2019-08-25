using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int WalkingAnimation = Animator.StringToHash("IsWalking");

    private static bool IsWalking => HasHorizontalInput || HasVerticalInput;

    private static float VerticalAxis => Input.GetAxis("Vertical");
    private static bool HasVerticalInput => !Mathf.Approximately(VerticalAxis, 0f);

    private static float HorizontalAxis => Input.GetAxis("Horizontal");
    private static bool HasHorizontalInput => !Mathf.Approximately(HorizontalAxis, 0f);

    private const float TurnSpeed = 15;

    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private AudioSource audioSource;

    private Vector3 _movement = Vector3.zero;
    private Quaternion _rotation = Quaternion.identity;

    private void FixedUpdate()
    {
        _movement.Set(HorizontalAxis, 0f, VerticalAxis);
        _movement.Normalize();

        var desiredForward = Vector3.RotateTowards(
            transform.forward,
            _movement,
            TurnSpeed * Time.deltaTime,
            0f
        );
        _rotation = Quaternion.LookRotation(desiredForward);

        animator.SetBool(WalkingAnimation, IsWalking);
        
        if (IsWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + _movement * animator.deltaPosition.magnitude);
        rigidbody.MoveRotation(_rotation);
    }
}