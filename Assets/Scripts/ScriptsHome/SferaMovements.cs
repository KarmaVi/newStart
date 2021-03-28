using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SferaMovements : MonoBehaviour
{
    private NavMeshAgent _navMesh;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 100))
            {
                _navMesh.destination = hit.point;
            }
        }
    }
}
