using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public void OnAttack()
    {
        GameManager.Instance.ShootBall();
    }
}
