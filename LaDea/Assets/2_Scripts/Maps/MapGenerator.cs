using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject doorPrefab;
    public GameObject floorPrefab;

    void Start()
    {
        scenarioCount = GetScenarioCount(level);
        GenerateFloor();
        GenerateWallsAndDoors();
    }


    public int level = 1;
    private int scenarioCount;

    private float wallLength = 10f; // Ajustar según el tamaño del prefab de la pared
    private float wallHeight = 5f; // Ajustar según el tamaño del prefab de la pared

    void GenerateFloor()
    {
        GameObject floor = Instantiate(floorPrefab, Vector3.zero, Quaternion.identity);
        floor.transform.localScale = new Vector3(wallLength, 1, wallLength); // Ajustar tamaño del piso
    }

    void GenerateWallsAndDoors()
    {
        Vector3[] wallPositions = {
        new Vector3(0, wallHeight/2, wallLength/2), // Norte
        new Vector3(wallLength/2, wallHeight/2, 0), // Este
        new Vector3(0, wallHeight/2, -wallLength/2), // Sur
        new Vector3(-wallLength/2, wallHeight/2, 0) // Oeste
    };

        for (int i = 0; i < wallPositions.Length; i++)
        {
            Quaternion rotation = (i % 2 == 0) ? Quaternion.identity : Quaternion.Euler(0, 90, 0);
            GameObject wallOrDoor = ShouldPlaceDoor(i) ? doorPrefab : wallPrefab;
            GameObject obj = Instantiate(wallOrDoor, wallPositions[i], rotation);
            obj.transform.localScale = new Vector3(wallLength, wallHeight, 1); // Ajustar tamaño según el prefab
        }
    }

    bool ShouldPlaceDoor(int wallIndex)
    {
        // Lógica para determinar si una pared debe tener una puerta o estar cerrada
        return scenarioCount > wallIndex;
    }

    int GetScenarioCount(int level)
    {
        return Mathf.Clamp(4 + (level - 1) / 2, 4, 7);
    }


}


