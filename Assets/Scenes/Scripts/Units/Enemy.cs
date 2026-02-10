using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Unit unit;

    void Awake()
    {
        unit = GetComponent<Unit>();
    }

    void Update()
    {
        if (unit == null) return;
        if (unit.IsDead) return;

        // Enemy behavior will go here later
    }

    // This can be called by Player when attacking
    public void TakeDamage(int damage)
    {
        unit.TakeDamage(damage);
    }
}
