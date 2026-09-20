using System;
using UnityEngine;

public class TowerTest : TowerScript
{
    
    void Awake()
    {
        towerName = "Test Tower";
        towerDescription = "Test Tower Description...";
    }

    public override void Attack()
    {
        Debug.Log("Override Example");
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Update()
    {
        transform.LookAt(FindClosestEnemy().transform);
    }
}
