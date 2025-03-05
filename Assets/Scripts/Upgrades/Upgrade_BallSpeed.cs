using UnityEngine;

public class Upgrade_BallSpeed : MonoBehaviour
{
    [SerializeField] private BallData BallData;
    [SerializeField] private float UpgradeFactor;

    public void Upgrade()
    {
        BallData.Speed *= UpgradeFactor;
    }
}
