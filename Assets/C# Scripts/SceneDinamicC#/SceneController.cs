using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Canvas canvas; // ссылка на канвас
    public float fadeOutTime = 1.0f; // время затухания в секундах

    private Animator canvasAnimator; // ссылка на компонент Animator
    private bool isFadingOut = false; // флаг, указывающий, происходит ли затухание
    private bool isGameOver = false;
    private void Start()
    {
        // Получаем ссылку на компонент Animator
        canvasAnimator = canvas.GetComponent<Animator>();
    }

    public void GameOver()
    {
        canvasAnimator.SetBool("isFadingOut", false);

        Invoke("timeoyt", 0.5f);

    }

    public void Update()
    {
        if(isGameOver == true)
        {
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        canvasAnimator.SetBool("win", true);
    }

    public void LoadSceneByNumber(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }


    private void timeoyt()
    {
        isGameOver = true;
    }
}
