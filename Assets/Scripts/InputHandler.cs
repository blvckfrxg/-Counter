using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counter.ToggleCounting();
        }
    }
}