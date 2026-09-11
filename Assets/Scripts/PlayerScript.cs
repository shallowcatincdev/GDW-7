using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public Camera cam;
    public GameObject point;

    private void OnMousePos(InputValue value) // Gets mouse position in 3d space. moves point object to that position
    {
        
        
        Ray ray = cam.ScreenPointToRay(value.Get<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(transform.position, hit.point);
        }
        point.transform.position = hit.point;
        if (hit.transform == null)
        {

        }    
    }
}
