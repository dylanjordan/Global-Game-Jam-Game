using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEditor.Tilemaps;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Controller : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    PlayerControl playerControl;
    private InputAction move;
    private InputAction jump;
    private InputAction dash;

    [Header ("Movement")]
    private Vector2 moveDir;
    public float speed = 10f;
    public float acceleration = 1.0f;
    public float jumpPower = 5f;


    [Header("Dashing")]
    [SerializeField]
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24.0f;
    private float dashingTime = 0.2f;
    private float dashingCoolDown = 1.0f;

    private bool facingRight = true;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;


    private void Awake()
    {
        playerControl = new PlayerControl();        
    }

    private void Update()
    {
        moveDir = move.ReadValue<Vector2>() ;

        Turn();

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        

    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
  
        rb.velocity = new Vector2(moveDir.x * speed, rb.velocity.y);

        

        if(moveDir == Vector2.zero)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(moveDir.x* speed, rb.velocity.y)), acceleration * Time.deltaTime);
        }
      

        
    }

    public void Jump(InputAction.CallbackContext context)
    {
      

        if(coyoteTimeCounter > 0f && context.started)
        {
            StartCoroutine(HoldJump());
        }

        if (context.started && rb.velocity.y > 0.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;

        }




    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && canDash)
        {
            StartCoroutine(Dashing());
        }
    }

    void Turn()
    {
        if (facingRight && moveDir.x < 0f || !facingRight && moveDir.x > 0f)
        {
            Vector3 localScale = transform.localScale;
            facingRight = !facingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnEnable()
    {
        move = playerControl.Player.Move;
        move.Enable();

            

        jump = playerControl.Player.Jump;
        jump.Enable();
        jump.performed += Jump;

        dash = playerControl.Player.Dash;
        dash.Enable();
        dash.performed += Dash;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        dash.Disable();
    }

    IEnumerator HoldJump()
    {
        bool bump = true;
        float maxHoldTime = 0.25f;
        while ((bump || jump.IsPressed()) && maxHoldTime >= 0f)
        {
            rb.velocity = Vector2.up * jumpPower * 0.75f;
            yield return new WaitForFixedUpdate();
            maxHoldTime -= Time.fixedDeltaTime;
            bump = false;
        }
            rb.velocity = Vector2.up * jumpPower;
    }

   
    IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;
        float ogGravity = rb.gravityScale;
        rb.gravityScale = 0.0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0.0f);

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = ogGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashingCoolDown);

        canDash = true; 
    }
}

