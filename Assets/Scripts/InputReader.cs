using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action InteractionButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionButtonPressed?.Invoke();
        }
    }
}