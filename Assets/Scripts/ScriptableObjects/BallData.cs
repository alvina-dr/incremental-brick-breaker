using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "Scriptable Objects/BallData")]
public class BallData : ScriptableObject
{
    [SerializeField]
    private float _initialSpeed;
    [ReadOnly]
    public float Speed;

    [SerializeField]
    private int _initialDamage;
    [ReadOnly]
    public int Damage;

    [SerializeField]
    private int _initialHealth;
    [ReadOnly]
    public int Health;

    public Ball BallGameObject;

    public void Reset()
    {
        Speed = _initialSpeed;
        Damage = _initialDamage;
        Health = _initialHealth;
    }
}
