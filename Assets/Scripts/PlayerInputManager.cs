using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeMenuGameObject;   

    public void OnAttack()
    {
        GameManager.Instance.ShootBall();
    }

    public void OnCrouch()
    {
        if (_upgradeMenuGameObject.activeSelf)
        {
            _upgradeMenuGameObject.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.UIManager.UpgradeMenu.OpenMenu();
            _upgradeMenuGameObject.gameObject.SetActive(true);
        }
    }
}
