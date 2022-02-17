using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private FreezeDebuff _debuff;
    [SerializeField] private float _freezingTime;
    [SerializeField] private SpriteRenderer _sprite;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _debuff.EnemyFreezed += OnEnemyFreezed;
    }

    private void OnDisable()
    {
        _debuff.EnemyFreezed -= OnEnemyFreezed;
    }
    private void Start()
    {
        transform.position = _startPosition;
        _rigidbody = GetComponent<Rigidbody2D>();
        Mover();
    }

    public void Mover()
    {
        Vector2 direction = new Vector2(Random.Range(-8.0f, 8.0f) * _speed, Random.Range(-8.0f, -5f) * _speed);
        _rigidbody.AddForce(direction, ForceMode2D.Force);
    }

    public void ResetEnemy()
    {
        transform.position = _startPosition;
        _speed = 2;
        Mover();
    }

    private void OnEnemyFreezed()
    {
        StartCoroutine(FreezePosition());
    }

    private IEnumerator FreezePosition()
    {
        _rigidbody.Sleep();
        _sprite.color = new Color(255, 255, 255, 1f); 

        yield return new WaitForSeconds(_freezingTime);

        _speed = 10;
        _sprite.color = new Color(0, 0, 0, 0f);
        Mover();
    }
}
