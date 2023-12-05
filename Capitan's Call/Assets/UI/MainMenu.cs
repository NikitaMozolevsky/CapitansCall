using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject panel;

    public Button startNewGameButton;

    private void Start()
    {
        startNewGameButton.onClick.AddListener(StartNewGame);
        
        
    }

    private void StartNewGame()
    {
        if (mainMenu != null)
        {
            mainMenu.SetActive(false);
            panel.SetActive(true);
        }
    }
}
