using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaDrainPerSecond = 10f;
    [SerializeField] private int maxHealth = 100;

    public List<Item> inventory = new List<Item>();

    private float currentStamina;
    private int currentHealth;

    private bool isRunning = false;
    public bool IsDead = false;

    private bool canAttack = true;
    private float attackCooldown = 1f;

    public int name_id;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {
        if (IsDead) return;

        HandleStamina();
        Cooldown();
    }

    // ---------- INVENTORY ----------

    public void PickUpItem(Item item)
    {
        if (item == null) return;

        inventory.Add(item);
        Debug.Log($"{gameObject.name} picked up {item.name}");
    }

    public void UseItem()
    {
        if (inventory.Count == 0)
        {
            Debug.Log("No items to use.");
            return;
        }

        inventory[0].Use(this);
    }

    public void UseEquippedItem(Item item)
    {
        if (item == null) return;

        item.Use(this);
    }

    public void GetList()
    {
        Debug.Log("---- INVENTORY ----");

        if (inventory.Count == 0)
        {
            Debug.Log("(empty)");
            return;
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log($"{i}: {inventory[i].name}");
        }
    }

    // ---------- HEALTH ----------

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public int GetUnit()
    {
        return currentHealth;
    }

    // ---------- COMBAT ----------

    public void PerformPrimaryAttack(Unit unit)
    {
        if (!canAttack) return;
        if (unit == null) return;

        unit.TakeDamage(20);
        canAttack = false;
    }

    public void Cooldown()
    {
        if (!canAttack)
        {
            attackCooldown -= Time.deltaTime;

            if (attackCooldown <= 0f)
            {
                canAttack = true;
                attackCooldown = 1f;
            }
        }
    }

    // ---------- STAMINA ----------

    private void HandleStamina()
    {
        if (!isRunning) return;
        if (currentStamina <= 0) return;

        currentStamina -= staminaDrainPerSecond * Time.deltaTime;
        currentStamina = Mathf.Max(currentStamina, 0);
    }

    // ---------- DEATH ----------

    private void Die()
    {
        Debug.Log($"{gameObject.name} died");
        IsDead = true;
    }
}
