using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : ReactableEntity
{
    public virtual void Idle() { }

    public virtual void AssignToTarget(Transform target) { }

    public virtual void MoveToCoordinates(Vector3 target) { }
}
