using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundToggle : MonoBehaviour
{
    public Button offSoundButton;
    public AudioSource audioSource;
    public TMP_Text buttonText;

    private bool isSoundOn = true;

    void Start()
    {
        buttonText.text = "Off Sound";

        offSoundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        audioSource.enabled = isSoundOn;

        buttonText.text = isSoundOn ? "Off Sound" : "On Sound";
    }
}