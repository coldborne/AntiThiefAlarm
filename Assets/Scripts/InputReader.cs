using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public event Action InteractionButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionButtonPressed?.Invoke();
        }
    }

    public float GetHorizontalDirection()
    {
        return Input.GetAxis(Horizontal);
    }

    public float GetVerticalDirection()
    {
        return Input.GetAxis(Vertical);
    }
}