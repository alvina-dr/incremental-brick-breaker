using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public void OnAttack()
    {
        GameManager.Instance.ShootBall();
    }

    public void OnCrouch()
    {
        GameManager.Instance.BallDataList[0].Health++;
    }
}
