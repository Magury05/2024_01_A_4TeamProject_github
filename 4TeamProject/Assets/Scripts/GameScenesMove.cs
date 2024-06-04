using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesMove : MonoBehaviour
{
  public void GameScnesCtrl()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Game Scenes go");
    }
        
}

