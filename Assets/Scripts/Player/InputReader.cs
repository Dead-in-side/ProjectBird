using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int NumberOfMouseButtonForJump = 0; 
    private const int NumberOfMouseButtonForShot = 1; 

    public event Action JumpButtonPressed;
    public event Action ShotButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(NumberOfMouseButtonForJump))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(NumberOfMouseButtonForShot))
        {
            ShotButtonPressed?.Invoke();
        }
    }
}

