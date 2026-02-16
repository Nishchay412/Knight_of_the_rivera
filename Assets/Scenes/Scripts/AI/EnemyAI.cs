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

void Attack(){
    //walk towards the player until the distance is less than 1f and the distance
    // from the spawn location isnt , then attack the player 
    // how to walk towards the player --> do we need A* pathfinding or can we just move in the direction of the player?
    // can just move to the direction of the player for now and then add changes later .
    // logic : keep track of the player's x and y position and keep the y position same 
    // and move until x position is less than 1f . 
    //

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
