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

}
