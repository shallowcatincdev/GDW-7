using UnityEngine;

public class TowerTest2 : TowerScript
{
    
    void Awake()
    {
        towerName = "Test Tower 2";
        towerDescription = "Test Tower 2 Description...";
    }

    public override void Attack()
    {
        Debug.Log("Override Example 2");
    }

}
