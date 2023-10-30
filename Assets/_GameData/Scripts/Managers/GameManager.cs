using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Theme");
    } 
}
