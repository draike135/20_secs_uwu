using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConstruction : MonoBehaviour
{
    [SerializeField] GameObject secondCircle;
    private LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, this.transform.position);

    }

    private void Update()
    {
        lineRenderer.SetPosition(1, secondCircle.transform.position);
    }
}
