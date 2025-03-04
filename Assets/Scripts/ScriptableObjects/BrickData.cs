using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "BrickData", menuName = "Scriptable Objects/BrickData")]
public class BrickData : ScriptableObject
{
    [SerializeField] private int _initializeHealth;
    [ReadOnly] public int Health;

    [SerializeField] private int _initializeDestroyPoints;
    [ReadOnly] public int DestroyPoints;

    public Brick BrickGameObject;

    public void Reset()
    {
        Health = _initializeHealth;
        DestroyPoints = _initializeDestroyPoints;
    }
}
