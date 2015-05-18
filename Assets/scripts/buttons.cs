using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {

    public void NewGame()
    {
        Debug.Log("NewGame");
        Application.LoadLevel("Level 01");
    }

    public void HallOfFame()
    {
        Debug.Log("HallOfFame");
        Application.LoadLevel(0);
    }

    public void Continue()
    {
        Debug.Log("Continue");
        Application.LoadLevel(2);

    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
