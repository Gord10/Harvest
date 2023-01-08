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
    private GameManager gameManager;

    private void Awake()
    {
        backgroundManager = FindObjectOfType<BackgroundManager>();
        gameManager = FindObjectOfType<GameManager>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        desiredMovement = new Vector2();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.IsPlayerMovementAllowed())
        {
            desiredMovement.x = Input.GetAxis("Horizontal");
            desiredMovement.y = Input.GetAxis("Vertical");
        }
        else
        {
            desiredMovement = Vector2.zero;
        }

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
    }

    private void FixedUpdate()
    {
        Vector2 velocity = desiredMovement * speed;
        velocity.x = 0;
        rigidbody2D.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jack"))
        {
            gameManager.OnPlayerReachJack();
        }
    }
}
