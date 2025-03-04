using DG.Tweening;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private int currentHealth;

    [SerializeField]
    private Collider2D _collider;

    public virtual void Damage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
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
                //GPCtrl.Instance.AddScore(PointsForDestroying);
                Destroy(gameObject);
            });
        });
    }

    public void OnCollisionEnter2D(Collision2D _collision)
    {
        Ball _ball = _collision.gameObject.GetComponent<Ball>();

        if (_ball != null)
        {
            Damage(_ball.GetBallDamage());
        }
    }
}
