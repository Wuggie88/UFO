using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void doquit()
    {
        Debug.Log("You just quit the game");
        Application.Quit();
    }
}
    