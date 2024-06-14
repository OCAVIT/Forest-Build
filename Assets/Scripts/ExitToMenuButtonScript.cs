using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject World;
    public GameObject GameUI;
    public GameObject MenuUI;
    public Button ExitMenuButton;

    void Start()
    {
        if (ExitMenuButton != null)
        {
            ExitMenuButton.onClick.AddListener(OnExitMenuButtonClicked);
        }
    }

    void OnExitMenuButtonClicked()
    {
        if (World != null)
        {
            World.SetActive(false);
        }

        if (GameUI != null)
        {
            GameUI.SetActive(false);
        }

        if (MenuUI != null)
        {
            MenuUI.SetActive(true);
        }
    }
}