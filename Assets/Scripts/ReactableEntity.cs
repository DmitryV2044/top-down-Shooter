using System;
using UnityEngine;

public abstract class ReactableEntity : MonoBehaviour
{
    internal Transform _target;
    
    private bool _isRadiusSearching = true;

    private float _radius;

    public Action RadiusEntered;

    public void EnableRadiusReaction(Transform target, float radius)
    {
        _target = target;
        _radius = radius;
        UpdateService.OnFixedUpdate += DetectRadiusEnter;
    }

    private void DetectRadiusEnter()
    {
        if (CheckRadius() && _isRadiusSearching)
        {
            RadiusEntered?.Invoke();
            _isRadiusSearching = false;
        }

        if (CheckRadius() == false && _isRadiusSearching == false)
            _isRadiusSearching = true;
    }

    private bool CheckRadius()
    {
        if (Vector2.Distance(transform.position, _target.position) <= _radius)
            return true;

        return false;
    }

    private void OnDisable() => UpdateService.OnFixedUpdate -= DetectRadiusEnter;
}
