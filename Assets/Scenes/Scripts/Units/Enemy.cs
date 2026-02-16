using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Unit unit;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        unit = GetComponent<Unit>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (unit == null) return;
        if (unit.IsDead) return;

        DetectPlayer();
    }

    void DetectPlayer()
    {
        // Raycast to the right
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2f);

        if (hit.collider != null)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white; // reset if not detected
        }
    }

    // This can be called by Player when attacking
    public void TakeDamage(int damage)
    {
        unit.TakeDamage(damage);
    }
}
