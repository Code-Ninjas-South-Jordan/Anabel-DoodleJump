using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Rigidbody Object")]
    public Rigidbody2D rb;
    [Header("Down Speed of Object")]
    public float downSpeed = 20f;
    [Header("Speed of Movement for Object")]
    public float movementSpeed = 10f;
    [Header("Directional Movement Speed")]
    public float movement = 0f;
    [Header("Text That Shows Current Score")]
    public Text scoreText;
    [Header("Score")]
    private float topScore = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if(movement < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore);
        
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        //why why why why is this a thing why why why is this a thing thing why why why
        velocity.x = movement;
        rb.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }
}
