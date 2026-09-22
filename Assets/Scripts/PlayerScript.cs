using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public Camera cam;
    public GameObject point;

    [SerializeField] GameObject[] towers;

    [SerializeField] Material goodMat;
    [SerializeField] Material badMat;
    [SerializeField] LayerMask groundLayer;
    GameObject towerTemp;

    int activeTower = 0;



    private void Start()
    {
        SpawnTowerTemp();
    }

    public void OnMousePos(InputValue value) // Gets mouse position in 3d space. moves point object to that position
    {
        
        
        Ray ray = cam.ScreenPointToRay(value.Get<Vector2>());
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, 100, groundLayer))
        {
            Debug.DrawLine(transform.position, hit.point);
        }
        
        if (hit.transform == null)
        {

        }
        else if (hit.transform.gameObject.CompareTag("Ground"))
        {
            point.transform.position = hit.point;
        }
        else
        {
            
        }
    }

    public void OnRightClick(InputValue value)
    {
        Debug.Log(value.Get<float>());
    }

    public void OnPlaceMode(InputValue value)
    {
        activeTower++;
        if (activeTower >= towers.Length)
        {
            activeTower = 0;
        }

        SpawnTowerTemp();
    }

    public void OnPlace(InputValue value)
    {
        if (towerTemp.GetComponent<TowerScript>().CanPlace())
        {
            Instantiate<GameObject>(towers[activeTower], towerTemp.transform.position, towerTemp.transform.rotation);
        }
        
    }

    public void OnRotate(InputValue value)
    {
        point.transform.Rotate(new Vector3(0, 90, 0));
    }

    void SpawnTowerTemp()
    {
        if (towerTemp != null)
        {
            Destroy(towerTemp);
            towerTemp = null;
        }

        towerTemp = Instantiate<GameObject>(towers[activeTower], point.transform);
        towerTemp.GetComponent<TowerScript>().SetPlacementMode(true);

    }

    
}
