using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpButtonPressed;
    public event Action FireButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            FireButtonPressed?.Invoke();
        }
    }
}

