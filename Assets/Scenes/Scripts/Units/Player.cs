using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Unit unit;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private int inventoryIndex = 0; 

    void Awake()
    {
        unit = GetComponent<Unit>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
{
    if (unit == null) return;
    if (unit.IsDead) return;

    // -------- Movement Input --------
    moveInput.x = Input.GetAxisRaw("Horizontal");
    moveInput.y = Input.GetAxisRaw("Vertical");

    // -------- Attack --------
    if (Input.GetKeyDown(KeyCode.Space))
    {
        TryAttack();
    }

    // -------- Pickup --------
    if (Input.GetKeyDown(KeyCode.E))
    {
        TryPickUpItem();
    }


    // -------- Use Item --------
    if (Input.GetKeyDown(KeyCode.Q))
    {
        UseItem();
    }
    if (Input.GetKeyDown(KeyCode.J))
    {
        unit.GetList();
    }

    if (Input.GetKeyDown(KeyCode.W))
    {
        inventoryIndex++;
    }
    else if (Input.GetKeyDown(KeyCode.S))
    {
        inventoryIndex--;
    }

    else if (Input.GetKeyDown(KeyCode.K))
    {
        LogInventory();
    }
}


    void FixedUpdate()
    {
        if (unit == null) return;
        if (unit.IsDead) return;

        rb.velocity = moveInput.normalized * moveSpeed;
    }

    void TryAttack()
    {
        Unit target = FindTargetInFront();
        if (target == null)
            return;

        unit.PerformPrimaryAttack(target);
        Debug.Log(target.GetUnit());

    }

    

    Item FindItemInFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.right,
            2f
        );

        // Debug ray (remove later)
        Debug.DrawRay(transform.position, transform.right * 2f, Color.red, 0.1f);

        if (!hit)
            return null;
        Debug.Log(hit.collider.name);
        return hit.collider.GetComponent<Item>();
    }

    void TryPickUpItem()
    {
        Debug.Log("Pressed pickup key");
        Item item = FindItemInFront();
        if (item == null)
            return;

        unit.PickUpItem(item);
    }
    void UseItem(){
        if (unit.inventory.Count == 0) return;
        Item item = unit.inventory[0];
        item.Use(unit);
    }

    void UseItem2(){
        if (unit.inventory.Count == 0) return;
        Item item = unit.inventory[inventoryIndex];
        item.Use(unit);
    }   


    void LogInventory()
{
    Debug.Log("---- INVENTORY ----");
    Debug.Log($"Inventory Count: {unit.inventory.Count}");
    Debug.Log($"Selected Index: {inventoryIndex}");

    if (inventoryIndex >= 0 && inventoryIndex < unit.inventory.Count)
        Debug.Log($"Selected Item: {unit.inventory[inventoryIndex].name}");
    else
        Debug.Log("Selected Item: None (invalid index)");

    for (int i = 0; i < unit.inventory.Count; i++)
    {
        string marker = (i == inventoryIndex) ? " <==" : "";
        Debug.Log($"{i}: {unit.inventory[i].name}{marker}");
    }
}








    Unit FindTargetInFront()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.right,
            2f
        );

        // Debug ray (remove later)
        Debug.DrawRay(transform.position, transform.right * 2f, Color.red, 0.1f);

        if (!hit)
            return null;
        Debug.Log(hit.collider.name);
        return hit.collider.GetComponent<Unit>();
    }
}
