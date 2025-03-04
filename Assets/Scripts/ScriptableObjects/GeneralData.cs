using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralData", menuName = "Scriptable Objects/GeneralData")]
public class GeneralData : ScriptableObject
{
    [SerializeField]
    private float _initialSpawnFrequency;
    [ReadOnly]
    public float SpawnFrequency;

    public void Reset()
    {
        SpawnFrequency = _initialSpawnFrequency;
    }
}
