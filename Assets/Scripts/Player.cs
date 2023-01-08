using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Player : MonoBehaviour
{
    public float speed = 5;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    private Vector2 desiredMovement;

    private BackgroundManager backgroundManager;
    private GameManager gameManager;
    private Room roomData;

    private void Awake()
    {
        backgroundManager = FindObjectOfType<BackgroundManager>();
        gameManager = FindObjectOfType<GameManager>();
        roomData = FindObjectOfType<Room>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        desiredMovement = new Vector2();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.IsPlayerMovementAllowed() && roomData.playerMovementMode != Room.PlayerMovementMode.NO_MOVEMENT)
        {
            desiredMovement.x = Input.GetAxis("Horizontal");
            desiredMovement.y = Input.GetAxis("Vertical");

            bool areMovementKeysPressed = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
            animator.SetBool("isWalking", areMovementKeysPressed);
        }
        else
        {
            desiredMovement = Vector2.zero;
            animator.SetBool("isWalking", false);
        }

        desiredMovement = Vector2.ClampMagnitude(desiredMovement, 1);

        if(roomData.playerMovementMode == Room.PlayerMovementMode.Y_AND_SCROLLING_X || roomData.playerMovementMode == Room.PlayerMovementMode.ONLY_X)
        {
            if (desiredMovement.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (desiredMovement.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        if(backgroundManager && roomData.playerMovementMode == Room.PlayerMovementMode.Y_AND_SCROLLING_X)
        {
            backgroundManager.Move(-desiredMovement.x * speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if(rigidbody2D)
        {
            Vector2 velocity = desiredMovement * speed;

            if(roomData.playerMovementMode == Room.PlayerMovementMode.ONLY_X)
            {
                velocity.y = 0;
            }
            else if(roomData.playerMovementMode == Room.PlayerMovementMode.Y_AND_SCROLLING_X)
            {
                velocity.x = 0;
            }
            
            rigidbody2D.velocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jack"))
        {
            Harvester harvester = collision.GetComponent<Harvester>();
            gameManager.OnPlayerReachHarvester(harvester);
        }
        else if(collision.CompareTag("ParkEntranceTrigger"))
        {
            gameManager.StartCoroutine(gameManager.OnPlayerEnterPark());
        }
    }

    [YarnCommand("GetExcited")]
    public void GetExcited()
    {
        float animationSpeed = 2.5f;
        animator.speed = animationSpeed;
    }
}
