using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralData", menuName = "Scriptable Objects/GeneralData")]
public class GeneralData : ScriptableObject
{
    [SerializeField] private float _initialSpawnFrequency;
    [ReadOnly] public float SpawnFrequency;

    [SerializeField] private float _initialMovingSpeedMultiplier;
    [ReadOnly] public float MovingSpeedMultiplier;

    [SerializeField] private bool _initialAutomaticShoot;
    [ReadOnly] public bool AutomaticShoot;

    public void Reset()
    {
        SpawnFrequency = _initialSpawnFrequency;
        MovingSpeedMultiplier = _initialMovingSpeedMultiplier;
        AutomaticShoot = _initialAutomaticShoot;
    }
}
