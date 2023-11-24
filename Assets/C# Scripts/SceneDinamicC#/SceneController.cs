using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Canvas canvas; // ������ �� ������
    public float fadeOutTime = 1.0f; // ����� ��������� � ��������

    private Animator canvasAnimator; // ������ �� ��������� Animator
    private bool isFadingOut = false; // ����, �����������, ���������� �� ���������
    private bool isGameOver = false;
    private void Start()
    {
        // �������� ������ �� ��������� Animator
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
