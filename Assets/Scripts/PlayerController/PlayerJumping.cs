using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerJumping : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float jumpPressBufferTime = .05f;
    [SerializeField] float jumpGroundGraceTime = .2f;

    Player player;

    bool tryingToJump;
    float lastJumpPressTime;
    float lastGroundedTime;

    void Awake() {
        player = GetComponent<Player>();
    }

    void OnEnable() {
        player.OnBeforeMove += OnBeforeMove;
        player.OnGroundStateChange += OnGroundStateChange;
    }

    void OnDisable() {
        player.OnBeforeMove -= OnBeforeMove;
        player.OnGroundStateChange -= OnGroundStateChange;
    }

    void OnJump() {
        tryingToJump = true;
        lastJumpPressTime = Time.time;
    }

    void OnBeforeMove() {
        bool wasTryingToJump = Time.time - lastJumpPressTime < jumpPressBufferTime;
        bool wasGrounded = Time.time - lastGroundedTime < jumpGroundGraceTime;

        bool isOrWasTryingToJump = tryingToJump || (wasTryingToJump && player.IsGrounded);
        bool isOrWasGrounded = player.IsGrounded || wasGrounded;

        if(isOrWasTryingToJump && isOrWasGrounded) {
            player.velocity.y += jumpSpeed;
        }
        tryingToJump = false;
    }

    void OnGroundStateChange(bool isGrounded) {
        if(!isGrounded) lastGroundedTime = Time.time;
    }
}
