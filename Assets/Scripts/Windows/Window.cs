using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action ButtonPressed;

    private void OnEnable()
    {
        _button.onClick.AddListener(InvokeTheEvent);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(InvokeTheEvent);
    }    

    private void InvokeTheEvent()=>ButtonPressed?.Invoke();
}
