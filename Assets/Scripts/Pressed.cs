using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour
{
    public event Action ButtonPressed;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPressed?.Invoke();
        }
    }
}
