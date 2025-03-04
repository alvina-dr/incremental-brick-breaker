using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "Scriptable Objects/BallData")]
public class BallData : ScriptableObject
{
    public float Speed;
    public int Damage;
    public int Health;
    public Ball BallGameObject;
}
