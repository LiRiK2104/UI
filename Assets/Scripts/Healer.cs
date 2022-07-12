using System;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PointsLabel _pointsLabel;
    
    private int _healPoints = 10;

    public int HealPoints => _healPoints;

    private void Start()
    {
        _pointsLabel.Init(HealPoints);
    }

    public void Heal()
    {
        _player.Heal(_healPoints);
    }
}
