using UnityEngine;
using System.Collections;

public class staticValuesScr : MonoBehaviour {
    //Guarda las variables estaticas a pasar entre las escenas.

    private bool _newLevel = true;
    private int _points = 0;
    private int _lifes = 3;

    public int defaultLifes = 3;

    public int getLives()
    {
        return _lifes;
    }

    public void setLives(int lifes)
    {
        _lifes = lifes;
    }

    
    /*
     * Recupera si el nivel es nuevo (nueva escena) o estamos en la misma escena
     * 
     */
    public bool getNewLevel()
    {
        return _newLevel;
    }

    public void setNewLevel(bool newLevel)
    {
        _newLevel = newLevel;
        setLives(defaultLifes);
    }
}
