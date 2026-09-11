using UnityEngine;

public class TowerScript : MonoBehaviour
{
    protected string towerName = "Default Name";
    protected string towerDescription = "Default Description";

    public string GetTowerType(string request) /// Get tower data of type string. 'request' = name of variable requested.
    {

        switch(request)
        {
            case "towerName": return towerName;

            case "towerDescription": return towerDescription;

            default:
                Debug.LogWarning("Invalid Request - GetTowerType(request)");
                return null;
        }
        
    }

    public virtual void Attack()
    {
        Debug.Log("No Attack Code Implemented");
    }
}
