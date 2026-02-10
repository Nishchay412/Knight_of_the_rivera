using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int capacity = 3;
    [SerializeField] private int healAmount = 20;

    // Called when a unit uses this item
    public void Use(Unit user)
    {
        if (capacity <= 0)
        {
            Debug.Log("No more uses left for this item.");
            Destroy(gameObject);
            return;
        }

        user.Heal(healAmount);
        capacity--;

        if (capacity == 0)
        {
            Debug.Log("Item consumed.");
            Destroy(gameObject);
        }
    }
}
