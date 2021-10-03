using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zspawn = 0;
    public float tileLength = 40;
    public int noOfTiles = 5;
    public Transform playerTransform;
    public List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i=0;i<=noOfTiles;i++)
        {
            if(i==0)
            {
                TileSpawner(0);
            }
            else
            {
                TileSpawner(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-45 > zspawn - (noOfTiles * tileLength))
        {
            TileSpawner(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void TileSpawner(int tileIndex)
    {
        Quaternion spawnRotation = Quaternion.Euler(0,-90,0);
        GameObject spawn = Instantiate(tilePrefabs[tileIndex], transform.forward * zspawn, spawnRotation);
        activeTiles.Add(spawn);
        zspawn += tileLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
