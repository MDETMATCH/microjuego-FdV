using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverMenu :  MonoBehaviour
{
    public  GameObject gameOverPanel;
    public InputAction gameOverAction;

    private void OnEnable()
    {
        gameOverAction.Enable();
    }

    private void OnDisable()
    {
        gameOverAction.Disable();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (Player.isDead)
        {
            PausarJuego();
        }
    }
    
    public void ReanudarJuego()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        Player.isDead = false;
        Player.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void PausarJuego()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
}
