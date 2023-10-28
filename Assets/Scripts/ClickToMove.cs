using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent player;
    [SerializeField]
    private Transform targetMarker;

    private void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Cast a ray to check where the agent will move to
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo)) 
            {
                UpdateTarget(hitInfo.point);
            }
        }
    }

    private void UpdateTarget(Vector3 position)
    {
        //Move the agent to the target
        player.SetDestination(position);
        targetMarker.position = position;
    }
}
