using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    [SerializeField] Pressed Press;

    private void OnEnable()
    {
        Press.ButtonPressed += DisplayPressText;
    }

    private void OnDisable()
    {
        Press.ButtonPressed -= DisplayPressText;
    }

    public void DisplayPressText()
    {
        Debug.Log("The button is pressed, loser!");
    }
}
