using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
    private Text counterText;
    private int count = 0;
    private bool isRunning = false;
    private Coroutine countingCoroutine;

    void Start()
    {
        counterText = GetComponent<Text>();
        if (counterText == null)
        {
            counterText = GetComponentInChildren<Text>();
        }
        if (counterText == null)
        {
            counterText = FindObjectOfType<Text>();
        }

        if (counterText != null)
        {
            Debug.Log("Text найден: " + counterText.name);
            counterText.text = count.ToString();
        }
        else
        {
            Debug.LogError("Text не найден!");
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ToggleCounter();
        }
    }

    void ToggleCounter()
    {
        isRunning = !isRunning;

        if (isRunning)
        {
            StartCounting();
        }
        else
        {
            StopCounting();
        }
    }

    void StartCounting()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }
        countingCoroutine = StartCoroutine(CountingRoutine());
    }

    void StopCounting()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = null;
        }
    }

    System.Collections.IEnumerator CountingRoutine()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(0.5f);

            if (isRunning)
            {
                count++;
                UpdateDisplay();
            }
        }
    }

    void UpdateDisplay()
    {
        if (counterText != null)
        {
            counterText.text = count.ToString();
        }
        Debug.Log("—четчик: " + count);
    }
}