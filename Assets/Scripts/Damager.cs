using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PointsLabel _pointsLabel;
    
    private int _damage = 10;

    public int Damage => _damage;
    
    private void Start()
    {
        _pointsLabel.Init(Damage);
    }

    public void Attack()
    {
        _player.TakeDamage(this);
    }
}
