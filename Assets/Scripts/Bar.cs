using System;
using System.Collections;
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
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        HardSetSliderValue();
    }

    private void HardSetSliderValue()
    {
        _slider.value = _targetValue;
    }
    
    private void OnHealthChanged(Player player)
    {
        _targetValue = player.Health / player.MaxHealth;
        StopCoroutine(UpdateBar());
        StartCoroutine(UpdateBar());
    }

    private IEnumerator UpdateBar()
    {
        while (Mathf.Abs(_slider.value - _targetValue) > 0)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime);
            yield return null;
        }
    }
}
