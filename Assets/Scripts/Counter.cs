using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> OnCountChanged;

    [SerializeField] private float _countInterval = 0.5f;

    private int _count;
    private bool _isRunning;
    private Coroutine _countingCoroutine;
    private WaitForSeconds _waitInterval;

    private void Awake()
    {
        _waitInterval = new WaitForSeconds(_countInterval);
    }

    public void ToggleCounting()
    {
        _isRunning = !_isRunning;

        if (_isRunning)
        {
            StartCounting();
        }
        else
        {
            StopCounting();
        }
    }

    private void StartCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }

        _countingCoroutine = StartCoroutine(CountingRoutine());
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private System.Collections.IEnumerator CountingRoutine()
    {
        while (_isRunning)
        {
            yield return _waitInterval;

            if (_isRunning)
            {
                _count++;
                OnCountChanged?.Invoke(_count);
            }
        }
    }
}