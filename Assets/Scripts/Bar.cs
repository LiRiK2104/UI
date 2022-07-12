using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Slider _slider;
    private float _targetValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        OnValueChanged(_player);
        HardSetSliderValue();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime);
    }

    private void HardSetSliderValue()
    {
        _slider.value = _targetValue;
    }
    
    private void OnValueChanged(Player player)
    {
        _targetValue = player.Health / player.MaxHealth;
    }
}
