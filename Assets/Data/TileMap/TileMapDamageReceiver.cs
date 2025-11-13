using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapDamageReceiver : ShootableObjectDamageReceiver
{
    [Header("Tile Map")]
    [SerializeField] protected TilemapCollider2D tilemapCollider2D;

    protected override void LoadCollider()
    {
        if (this.tilemapCollider2D != null) return;
        this.tilemapCollider2D = GetComponent<TilemapCollider2D>();
        this.circleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
}
