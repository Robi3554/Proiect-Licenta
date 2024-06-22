using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    private FadeToBlack fade;

    void Start()
    {
        fade = GetComponentInChildren<FadeToBlack>();
    }

    public void StartDeathScreen()
    {
        fade.TransitionIn();
        Debug.Log("Entered");
    }
}
