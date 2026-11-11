using UnityEngine;

public class Collecter : MonoBehaviour
{
    public int score = 0;

    [Header("UI Yöneticisi")]
    [SerializeField] private UIManager uiManager; // UIManager scriptine referans

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            score += 10;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Red"))
        {
            score -= 5;
            Destroy(other.gameObject);
        }

        if (uiManager != null)
        {
            uiManager.UpdateScoreDisplay(score);
        }
    }
}