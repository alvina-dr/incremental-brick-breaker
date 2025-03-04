using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public List<BallData> BallDataList = new();
    public Ball CurrentBall;

    private void Start()
    {
        LaunchLevel();
    }

    public void LaunchLevel()
    {
        InstantiateNewBall();
    }

    public void ShootBall()
    {
        if (CurrentBall == null) return; //Maybe add feedback that there is no ball for now

        CurrentBall.LaunchBall(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
        CurrentBall = null;
        DOVirtual.DelayedCall(1f, () =>
        {
            InstantiateNewBall();
        });
    }

    public void InstantiateNewBall()
    {
        CurrentBall = Instantiate(BallDataList[0].BallGameObject);

    }
}
