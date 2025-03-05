using UnityEngine;

public class Upgrade_SpawnBallDelay : MonoBehaviour
{
    [SerializeField] private float UpgradeFactor;

    public void Upgrade()
    {
        GameManager.Instance.GeneralData.SpawnFrequency *= UpgradeFactor;
    }
}
