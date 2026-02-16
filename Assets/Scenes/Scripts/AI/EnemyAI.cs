using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkingSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 spawnLocation;
    private bool movingLeft = true;
    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnLocation = transform.position;
    }

    void FixedUpdate()
    {
        Patrol();
    }
    // detect the distance between the player and the enemy
    // how to detect the enemy position --> 
    // transform.position.x - player.transform.position.x --> 
    // if the result is in the range of -5 to 5, then start the raycast to detect the player

    
    void DetectPlayer()
{
    float distance = Vector2.Distance(transform.position, player.position);

    if (distance < 5f)
    {
        Vector2 direction = (player.position - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 5f);

        if (hit.collider != null && hit.collider.gameObject == player.gameObject)
        {
            Debug.Log("Player detected! Switching to attack state.");
        }
    }
}



    void Patrol()
    {
        if (movingLeft)
        {
            rb.velocity = new Vector2(-walkingSpeed, rb.velocity.y);

            if (transform.position.x <= spawnLocation.x - 5f)
            {
                movingLeft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(walkingSpeed, rb.velocity.y);

            if (transform.position.x >= spawnLocation.x + 5f)
            {
                movingLeft = true;
            }
        }
    }
}
