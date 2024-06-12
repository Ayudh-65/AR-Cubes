using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearObjects : MonoBehaviour
{
    public void Click() {
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("spawnedCube");

        foreach(GameObject spawnedObject in spawnedObjects)
        {
            Destroy(spawnedObject);
        }
    }
}
