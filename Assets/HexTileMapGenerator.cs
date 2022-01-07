using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTilePrefab;
    public float tileXoffset = 1.8f;
    public float tileZoffset = 1.565f;
    private int mapWidth = 25;

    private int mapHeight = 25;
    // Start is called before the first frame update
    void Start()
    {
        CreateHexTileMap();
    }

    void CreateHexTileMap()
    {
        for (int x = 0; x <= mapWidth; x++)
        {
            for (int z = 0; z <= mapHeight; z++)
            {
                GameObject TempGO = Instantiate(hexTilePrefab);
                if (z % 2 == 0)
                {
                    TempGO.transform.position = new Vector3(x * tileXoffset, 0,z * tileZoffset);
                }
                else
                {
                    TempGO.transform.position = new Vector3(x * tileXoffset + tileXoffset / 2, 0,z * tileZoffset);
                }

                SetTileInfo(TempGO, x, z);
            }
        }
        
    }

    void SetTileInfo(GameObject GO, int x, int z)
    {
        GO.transform.parent = transform;
        GO.name = x.ToString() + ", " + z.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
