using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool avoid;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (avoid)
            ChallengeTimer.OnLose();
        else
            ChallengeTimer.OnWin();
    }
}
