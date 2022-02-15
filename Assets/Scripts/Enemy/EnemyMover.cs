using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _startPosition;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        transform.position = _startPosition;
        _rigidbody = GetComponent<Rigidbody2D>();
        Mover();
    }

    public void Mover()
    {
        Vector2 direction = new Vector2(Random.Range(-80.0f, 80.0f) * _speed, Random.Range(-80.0f, -50f) * _speed);
        _rigidbody.AddForce(direction, ForceMode2D.Force);
    }

    public void ResetEnemy()
    {
        transform.position = _startPosition;
    }
}
