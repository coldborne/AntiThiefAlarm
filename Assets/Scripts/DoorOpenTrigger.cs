using System;
using TMPro;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshPro _doorStateText;

    private bool _hasOpened;
    private bool _hasOpener;

    public event Action DoorOpened;
    public event Action DoorClosed;

    private void Awake()
    {
        _hasOpened = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            _hasOpener = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
        {
            _hasOpener = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_hasOpener)
            {
                _hasOpened = !_hasOpened;

                _doorStateText.text = _hasOpened ? "Открыто" : "Закрыто";

                if (_hasOpened)
                {
                    DoorOpened?.Invoke();
                }
                else
                {
                    DoorClosed?.Invoke();
                }
            }
        }
    }
}