using UnityEngine;

public class Upgrade_BallHealth : MonoBehaviour
{
    [SerializeField] private BallData _ballData;

    public void Upgrade()
    {
        _ballData.Health++;
    }
}
