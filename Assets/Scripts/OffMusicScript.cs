using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicToggle : MonoBehaviour
{
    public Button offMusicButton;
    public AudioSource audioSource;
    public TMP_Text buttonText;

    private bool isMusicOn = true;

    void Start()
    {
        buttonText.text = "Off Music";

        offMusicButton.onClick.AddListener(ToggleMusic);
    }

    void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        audioSource.enabled = isMusicOn;

        buttonText.text = isMusicOn ? "Off Music" : "On Music";
    }
}