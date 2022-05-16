using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ReactableEntity : MonoBehaviour
{
    private Transform _target;

    private bool _isRadiusSearching = true;

    private int _radius;

    public Action RadiusEntered;

    public void AddRadiusReaction(Transform target, int radius)
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

        RadiusEntered.Invoke();
        return false;
    }

    private void OnDisable()
    {
        UpdateService.OnFixedUpdate -= DetectRadiusEnter;
    }
}
