using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 Nextspawnpoint;



    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, Nextspawnpoint, Quaternion.identity);
        Nextspawnpoint = temp.transform.GetChild(1).transform.position;
    }


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }
}
