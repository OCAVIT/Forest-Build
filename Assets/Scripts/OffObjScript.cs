using UnityEngine;

public class DisableObjectsOnStart : MonoBehaviour
{
    private string[] objectNames = {
        "Tree1", "Tree2", "Tree3", "Tree4", "Tree5", "Tree6", "Tree7",
        "Brush1", "Brush2", "Brush3", "Brush4", "Brush5", "Brush6",
        "Stone1", "Stone2", "Stone3", "Stone4",
        "Sheep1", "Sheep2", "Sheep3", "Sheep4", "Sheep5",
        "Cloud1", "Cloud2", "Cloud3", "Cloud4", "Cloud5", "Cloud6"
    };
    void Start()
    {
        foreach (string name in objectNames)
        {
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                obj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Object with name " + name + " not found.");
            }
        }
    }
}