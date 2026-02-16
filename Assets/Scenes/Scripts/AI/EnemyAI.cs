using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkingSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 spawnLocation;
    private bool movingLeft = true;
    public Transform player;
    public float detectionMetre; 


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
            detectionMetre = 100f; // Set detection metre to 100 when player is detected
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
    // what if the y changes ?

    // might need to add A* pathfinding later if we want to add obstacles and stuff but for now we can just move in the direction of the player and then add changes later .
    //
    // lets just presume for now that the y value of the player is the same 
    float distance = Vector2.Distance(transform.position, player.position);

    if distance > 1f && player.transform.position.y == transform.position.y 
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * walkingSpeed, rb.velocity.y);
    }
    else if (distance> 1f && player.transform.position.y != transform.position.y){
        while (detectionMetre>0){
            detectionMetre -= Time.deltaTime * 10f; // Decrease detection metre over time when player is close but not detected 
            ""
    }
    {
        else if (distance <= 1f)
        {
            Debug.Log("Attacking player!");
            // Here you would implement the actual attack logic, such as reducing player's health
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
