using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialWindow;
    public GameObject forestTXT;
    public GameObject PlayB;
    public GameObject TutorialB;
    public GameObject ExitB;
    public Button gotButton;

    void Start()
    {
        if (tutorialWindow == null)
        {
            Debug.LogError("TutorialWindow �� ����������� � ����������.");
            return;
        }

        if (gotButton == null)
        {
            Debug.LogError("GotButton �� ����������� � ����������.");
            return;
        }

        gotButton.onClick.AddListener(OnGotButtonClick);
    }

    void OnGotButtonClick()
    {
        tutorialWindow.SetActive(false);
        forestTXT.SetActive(true);
        PlayB.SetActive(true);
        ExitB.SetActive(true);
        TutorialB.SetActive(true);
    }
}