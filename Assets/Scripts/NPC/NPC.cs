using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : ReactableEntity
{
    [SerializeField] internal float WalkSpeed;

    [SerializeField] internal NavMeshAgent Agent;

    [SerializeField] internal NavMeshPath Path;

    [SerializeField] internal NavMeshPath nextPath;

    private void Start()
    {
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
        Path = new NavMeshPath();
        nextPath = new NavMeshPath();
    }

    public virtual void LookAtTarget(Transform target)
    {
        transform.LookAt(target, transform.up);
    }

    public virtual void Idle() { }

    public virtual void AssignToTarget(Transform target) { }

    private Vector3 theVector;

    public virtual void Follow(Transform target)
    {

        GeneratePath(target);
        //IsCoordinatesAvailible(new Vector2(-30, 1), Path);
    }

    public virtual void MoveToCoordinates(Vector2 target) => Agent.SetDestination(target);


    public virtual void AssignPath(NavMeshPath path)
    {
        Agent.SetPath(path);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(theVector, 1);
    }

    int calcIteration = 0;

    public virtual void MaintainDistance(Transform target, int minDistance, int maxDistance)
    {
        Debug.Log(gameObject.name + " | Path finding iteration: " + calcIteration);
        calcIteration++;
        Vector2 newPosition = new Vector2(transform.position.x + Random.Range(-minDistance, maxDistance), transform.position.y + Random.Range(-minDistance, maxDistance));
        theVector = newPosition;
        if (IsCoordinatesAvailible(newPosition, nextPath) == false) MaintainDistance(target, minDistance, maxDistance);
        else { calcIteration = 0; return; }
    }

    private void GeneratePath(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) < 2)
        {
            MaintainDistance(transform, 5,6);
            UpdatePath();
            AssignPath(Path);
            return;
        }
        Vector2 newPosition = (Vector2)target.position + new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        if (IsCoordinatesAvailible(newPosition, nextPath) == false) Debug.Log(gameObject.name + " | New path not founded");
        theVector = newPosition;
        UpdatePath();
        AssignPath(Path);
    }

    private void UpdatePath()
    {
        if(CheckPathAvailibilityStatus(nextPath) == true) { Path = nextPath; }
    }

    private bool IsCoordinatesAvailible(Vector2 coordinates, NavMeshPath path)
    {
        Agent.CalculatePath(coordinates, path);
        return CheckPathAvailibilityStatus(path);
    }

    private bool CheckPathAvailibilityStatus(NavMeshPath path)
    {
        if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
        {
            return false;
        }
        else return true;
    }
}
