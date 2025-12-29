using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private Text _counterText;

    private void Awake()
    {
        _counterText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.OnCountChanged += UpdateCounterDisplay;
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.OnCountChanged -= UpdateCounterDisplay;
        }
    }

    private void UpdateCounterDisplay(int count)
    {
        if (_counterText != null)
        {
            _counterText.text = count.ToString();
        }

        Debug.Log($"—четчик: {count}");
    }
}