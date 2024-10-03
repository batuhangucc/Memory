using UnityEngine;
using UnityEngine.Tilemaps;using System.Collections;

public class TilemapManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int[] tilesToHide;
    public TileBase newTile;
    public Vector3Int[] changeTilePositions;
    public GameObject Lava;
    public GameObject Ice;
    public float delay;

    void Start()
    {

        StartCoroutine(HideTilesAfterDelay());

    }
    IEnumerator HideTilesAfterDelay()
    {
        // Belirtilen süreyi bekle
        yield return new WaitForSeconds(delay);


        HideTiles();
    }

    void HideTiles()
    {
        foreach (Vector3Int pos in tilesToHide)
        {

            TileBase tile = tilemap.GetTile(pos);

            if (tile != null)
            {

                tilemap.SetTile(pos, null);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(Lava);
            ChangeTiles();
            Ice.layer = LayerMask.NameToLayer("Platforms");

        }
    }
    private void ChangeTiles()
    {
        if (tilemap != null && newTile != null)
        {
            foreach (Vector3Int pos in changeTilePositions)
            {
                // Belirtilen pozisyondaki fayansý yeni fayans ile deðiþtir
                tilemap.SetTile(pos, newTile);
                Debug.Log($"Tile at position {pos} changed to {newTile}");
            }
        }

    }

}   

