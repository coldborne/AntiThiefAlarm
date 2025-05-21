using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class DoorView : MonoBehaviour
{
    [SerializeField] private Door _door;
    private TextMeshPro _doorStateText;

    private void Awake()
    {
        _doorStateText = GetComponent<TextMeshPro>();
        Close();
    }

    private void OnEnable()
    {
        _door.Opened += Open;
        _door.Closed += Close;
    }

    private void OnDisable()
    {
        _door.Opened -= Open;
        _door.Closed -= Close;
    }

    private void Open()
    {
        _doorStateText.text = "Открыто";
    }

    private void Close()
    {
        _doorStateText.text = "Закрыто";
    }
}