using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {

    public GameObject estados;

    public void NewGame()
    {
        Debug.Log("NewGame");
        estados.GetComponent<staticValuesScr>().setNewLevel(true);
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
