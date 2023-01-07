using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private Vector2 desiredMovement;
    private BackgroundManager backgroundManager;

    private Vector3 previousPosition;
    private bool isTouchingAnything = false;

    private void Awake()
    {
        backgroundManager = FindObjectOfType<BackgroundManager>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        desiredMovement = new Vector2();

        previousPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        desiredMovement.x = Input.GetAxis("Horizontal");
        desiredMovement.y = Input.GetAxis("Vertical");

        desiredMovement = Vector2.ClampMagnitude(desiredMovement, 1);

        if(desiredMovement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(desiredMovement.x > 0)
        {
            spriteRenderer.flipX = false;
        }


        backgroundManager.Move(-desiredMovement.x * speed * Time.deltaTime);

        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = desiredMovement * speed;
        velocity.x = 0;
        rigidbody2D.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchingAnything = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingAnything = false;
    }
}
