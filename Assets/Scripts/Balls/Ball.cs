using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallData BallData;

    private int _currentHealth;
    [SerializeField]
    private Rigidbody2D _rigibody;
    [SerializeField]
    private Collider2D _collider;

    public void SetupBall()
    {
        _currentHealth = BallData.Health;
        _collider.enabled = false;
    }

    public void LaunchBall(Vector2 _direction)
    {
        //BallData.Speed *= GPCtrl.Instance.GeneralData.ballSpeedUpgrade;
        _collider.enabled = true;
        _rigibody.bodyType = RigidbodyType2D.Dynamic;
        _rigibody.AddForce(_direction.normalized * BallData.Speed);
        //paradeCollider.enabled = true;
    }

    public void DeactivateMovement()
    {
        _rigibody.linearVelocity = Vector2.zero;
        _rigibody.bodyType = RigidbodyType2D.Kinematic;
        _collider.enabled = false;
        //paradeCollider.enabled = false;
    }

    private void Update()
    {
        _rigibody.linearVelocity = _rigibody.linearVelocity.normalized * BallData.Speed;
    }

    public int GetBallDamage()
    {
        return BallData.Damage;
    }

    public virtual void Damage(int _damage)
    {
        _currentHealth -= _damage;
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        _collider.enabled = false;
        transform.DOScale(1.3f, .05f).OnComplete(() =>
        {
            transform.DOScale(0, .15f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        });
    }

    public void OnCollisionEnter2D(Collision2D _collision)
    {
        Damage(1);
    }
}
