using UnityEngine;

public class ExitOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        if (gameObject.name == "Exit")
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}