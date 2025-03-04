using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallData BallData;
    [SerializeField]
    private Rigidbody2D _rigibody;
    [SerializeField]
    private Collider2D _collider;

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
}
