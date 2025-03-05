using UnityEngine;

public class Upgrade_Automation : MonoBehaviour
{
    public void Upgrade()
    {
        GameManager.Instance.GeneralData.AutomaticShoot = true;
    }
}
