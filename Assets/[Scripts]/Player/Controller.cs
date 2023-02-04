using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    float horinzontal;
    public float speed = 10.0f; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horinzontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * horinzontal, rb.velocity.y);
    }
}
