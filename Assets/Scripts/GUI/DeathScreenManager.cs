using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    private FadeToBlack fade;

    private Death death;

    void Start()
    {
        fade = GetComponentInChildren<FadeToBlack>();

        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        death = obj.GetComponentInChildren<Death>();

        death.deathScreen += StartDeathScreen;
    }

    public void StartDeathScreen()
    {
        fade.TransitionIn();
        Debug.Log("Entered");
    }
}
