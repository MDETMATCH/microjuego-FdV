using UnityEngine;
using UnityEngine.InputSystem;
public class pauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public InputAction pauseAction;
    private bool isPaused = false;
    
    private void OnEnable()
    {
        pauseAction.Enable();
    }
    private void OnDisable()
    {
        pauseAction.Disable();
    }

    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            if (isPaused)
            {
                ReanudarJuego();
            }
            else if(!Player.isDead)
            {
                PausarJuego();
            }
        }
    }

    public void ReanudarJuego()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PausarJuego()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
