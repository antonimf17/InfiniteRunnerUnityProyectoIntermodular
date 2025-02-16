using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 Nextspawnpoint;



    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, Nextspawnpoint, Quaternion.identity);
        Nextspawnpoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems) {
            temp.GetComponent<Groundtile>().SpawnObstacle();
            temp.GetComponent<Groundtile>().SpawnCoins();
          }
    }


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}
