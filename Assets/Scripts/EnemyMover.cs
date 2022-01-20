using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Mover();
    }

    private void Mover()
    {
        Vector2 direction = new Vector2(Random.Range(-80.0f, 80.0f), Random.Range(-80.0f, -50f));
        _rigidbody.AddForce(direction, ForceMode2D.Force);
    }
}
