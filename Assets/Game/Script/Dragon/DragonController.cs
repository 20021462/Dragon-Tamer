using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private AnimationController _animCtrl;
    [SerializeField] private CharacterController _characterCtrl;
    [SerializeField] private float _speed;

    [SerializeField] private Vector3 _target;

    private void Update()
    {
        _characterCtrl.Move(Vector3.forward * 10 * Time.deltaTime * _speed);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
        Move();
    }

    private void Move()
    {
        _animCtrl.SetStand(false);
        transform.LookAt(_target);
        //_characterCtrl.Move(_target);
    }
}
