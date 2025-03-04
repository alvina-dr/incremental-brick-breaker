using DG.Tweening;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public BrickData BrickData;
    private int _currentHealth;

    [SerializeField]
    private Collider2D _collider;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public virtual void Setup()
    {
        _currentHealth = BrickData.Health;
    }

    public virtual void Damage(int _damage)
    {
        _currentHealth -= _damage;
        DamageFeedback();

        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    public void DamageFeedback()
    {
        _spriteRenderer.color = Color.red;
        DOVirtual.DelayedCall(.1f, () => 
        {
            _spriteRenderer.color = Color.white;
        });

        GameManager.Instance.AddScore(BrickData.DestroyPoints);
        UI_TextPopper textPopper = Instantiate(GameManager.Instance.UIManager.TextPopperPrefab, GameManager.Instance.UIManager.transform);
        textPopper.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        textPopper.PopText(BrickData.DestroyPoints.ToString());
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
        Ball _ball = _collision.gameObject.GetComponent<Ball>();

        if (_ball != null)
        {
            Damage(_ball.GetBallDamage());
        }
    }
}
