using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject World;
    public GameObject GameUI;
    public GameObject MenuUI;
    public GameObject TutorialWindow;

    private void Start()
    {
        World.SetActive(false);
        GameUI.SetActive(false);
        TutorialWindow.SetActive(false);

    }

    private void OnMouseDown()
    {
        MenuUI.SetActive(false);
        World.SetActive(true);
        GameUI.SetActive(true);
    }
}