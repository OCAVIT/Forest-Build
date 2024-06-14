using UnityEngine;
using TMPro;

public class TutorialHandler : MonoBehaviour
{
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject tutorialButton;
    public TMP_Text forestText;
    public GameObject tutorialWindow;

    void OnMouseDown()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        tutorialButton.SetActive(false);
        forestText.gameObject.SetActive(false);

        tutorialWindow.SetActive(true);
    }
}