using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value, int maxHealth)
    {
        var target = value / maxHealth;

        StartCoroutine(ValueChange(target));
    }

    private IEnumerator ValueChange(float target)
    {
        float waitTime = 0.5f;

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, waitTime * Time.deltaTime);

            yield return null;
        }

        yield return null;
    }
}
