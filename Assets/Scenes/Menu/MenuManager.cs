using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    // старт игры в ковычках пишем название сцены
    public void PlayGame()
    {
        Application.LoadLevel("Game");
    }


    // выход из игры
    public void Exit()
    {
        Application.Quit();
    }


}
