using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen;

    public event Action Opened;
    public event Action Closed;

    public void Toggle()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            Opened?.Invoke();
        }
        else
        {
            Closed?.Invoke();
        }
    }
}