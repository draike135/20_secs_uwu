using UnityEngine;
using System.Collections;

public class DragWire : MonoBehaviour
{
    private bool _mouseState;
    private GameObject target;
    private Vector3 screenSpace;
    private Vector3 offset;
    private Vector3 starterPosition;
    [SerializeField] GameObject objective;
    public float radius;
    public bool done = false;
    public bool justDone = false;
    [SerializeField] GameObject cylinder;
    [SerializeField] GameObject wires;
    [SerializeField] GameObject gameManager;



    // Use this for initialization
    void Start()
    {
        starterPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {


            // Debug.Log(_mouseState);
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit hitInfo;
                target = GetClickedObject(out hitInfo);
                if (target != null)
                {
                    _mouseState = true;
                    screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                    offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                _mouseState = false;
            }
            if (_mouseState)
            {
                //keep track of the mouse position
                var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

                //convert the screen mouse position to world point and adjust with offset
                var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

                //update the position of the object in the world
                target.transform.position = curPosition;
            }
            else
            {
                if (PointInsideSphere(this.transform.position, objective.transform.position, radius)){
                    done = true;
                    justDone = true;
                    this.transform.position = objective.transform.position;
                }
                else {
                    this.transform.position = starterPosition;
                } 
            }
        }
        else if (justDone)
        {
            cylinder.SetActive(false);
            wires.SetActive(false);
            gameManager.GetComponent<GameOver>().done.Add(true);
            justDone = false;
        }
    }


    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        if (target == this.gameObject)
        {
            return target;
        }
        return null;
    }
    //Check if it's near the objective
    bool PointInsideSphere(Vector3 point, Vector3 center, float radius)
    {
        return Vector3.Distance(point, center) < radius;
    }

}
