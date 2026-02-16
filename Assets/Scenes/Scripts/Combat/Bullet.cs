using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// just logic for the bullet, like how it moves and how it interacts with the player and the enemy (damage, destroy on impact, etc.)

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 
    public int damage = 20; 
    public float lifetime = 4f;
    
    public float direction; 

    public void setDirection(float dir)
    {
        direction = dir;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);  
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            Destroy(gameObject);
        }
    }
}
