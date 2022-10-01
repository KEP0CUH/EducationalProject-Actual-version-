using UnityEngine;

[RequireComponent(typeof(PlayerCamera))]
[RequireComponent (typeof(PlayerMovement))]
public class Player : MonoBehaviour, IMobHandler, IItemHandler
{
    private Ship ship;
    private PlayerCamera camera;
    private PlayerMovement movement;
    [SerializeField] private CanvasWindow canvas;
    private Inventory inventory;

    private void Start()
    {
        this.Init();
    }

    public void Init()
    {
        this.ship = new Ship(ShipKind.GreenIndus);
        this.GetComponent<SpriteRenderer>().sprite = ship.State.Data.Icon;

        this.inventory = new Inventory(canvas.ConstantUI,canvas, ship);
        this.camera = GetComponent<PlayerCamera>().Init(transform);
        this.movement = GetComponent<PlayerMovement>().Init(ship);
    }

    public void HandleMob(Mob mob)
    {
        Debug.Log($"��������� ����:");
        mob.SetDamage(Random.Range(35, 55));
    }

    public void HandleItem(ItemView sender,ItemData data)
    {
        Debug.Log("���������� � ���������");
        inventory.AddItem(data.Kind,1);
        Object.Destroy(sender.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.ReswitchWindow();
        }
    }


}
