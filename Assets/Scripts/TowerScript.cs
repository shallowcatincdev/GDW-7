using System;
using System.Linq;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    protected string towerName = "Default Name";
    protected string towerDescription = "Default Description";

    bool placeMode = false;
    int colisons;

    public Material goodPlace;
    public Material badPlace;

    public Renderer[] rendRef;

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

    public void SetPlacementMode(bool opt)
    {
        if (opt)
        {
            placeMode = true;
            PlacementModeConfig();
        }
        else 
        { 
            placeMode = false; 
        }
    }

    public virtual void PlacementModeConfig()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        foreach (Renderer r in rendRef)
        {

            r.material = goodPlace;
        }
    }

    public bool CanPlace()
    {
        Debug.Log("canPlace");

        if (colisons <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

    public virtual void Attack()
    {
        Debug.Log("No Attack Code Implemented");
 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.gameObject.CompareTag("Point"))
        {

        }
        else
        {
            colisons++;
            if (colisons > 0 && placeMode)
            {
                foreach (Renderer r in rendRef)
                {

                    r.material = badPlace;
                }
            }
        }
            
        
    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("exit");
        if (other.gameObject.CompareTag("Point"))
        {

        }
        else
        {
            colisons--;
            if (colisons <= 0 && placeMode)
            {
                foreach (Renderer r in rendRef)
                {

                    r.material = goodPlace;
                }
            }
        }
    }


}
