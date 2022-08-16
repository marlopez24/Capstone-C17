using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
   public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void HomeButton() {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("MainMenu");
    }
}
