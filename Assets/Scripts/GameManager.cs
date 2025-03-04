using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
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

    public GeneralData GeneralData;
    public List<BallData> BallDataList = new();
    public List<BrickData> BrickDataList = new();
    public Ball CurrentBall;
    public Vector2 GridSize;
    public Vector2 BrickSize;
    [ReadOnly]
    public int CurrentPoints;

    public UIManager UIManager;
    
    private void Start()
    {
        GeneralData.Reset();

        BallDataList = Resources.LoadAll<BallData>("Balls/").ToList();
        for (int i = 0; i < BallDataList.Count; i++)
        {
            BallDataList[i].Reset();
        }

        BrickDataList = Resources.LoadAll<BrickData>("Bricks/").ToList();
        for (int i = 0; i < BrickDataList.Count; i++)
        {
            BrickDataList[i].Reset();
        }

        UIManager.ScoreText.SetTextValue(CurrentPoints.ToString());

        LaunchLevel();
    }

    public void LaunchLevel()
    {
        InstantiateBricks();
        InstantiateNewBall();
    }

    public void ShootBall()
    {
        if (CurrentBall == null) return; //Maybe add feedback that there is no ball for now

        CurrentBall.LaunchBall(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
        CurrentBall = null;
        DOVirtual.DelayedCall(GeneralData.SpawnFrequency, () =>
        {
            InstantiateNewBall();
        });
    }

    public void InstantiateNewBall()
    {
        int randomIndex = Random.Range(0, BallDataList.Count);
        CurrentBall = Instantiate(BallDataList[randomIndex].BallGameObject);
        CurrentBall.SetupBall();
    }

    public void InstantiateBricks()
    {
        for (int i = 0; i < GridSize.x; i++)
        {
            for (int j = 0; j < GridSize.y; j++)
            {
                Brick brick = Instantiate(BrickDataList[0].BrickGameObject);
                brick.transform.position = new Vector3((i - GridSize.x / 2) * BrickSize.x + BrickSize.x / 2, (j - GridSize.y / 2) * BrickSize.y + BrickSize.y / 2, 0);
            }
        }
    }

    public void AddScore(int points)
    {
        CurrentPoints += points;
        UIManager.ScoreText.SetTextValue(CurrentPoints.ToString());
    }
}
