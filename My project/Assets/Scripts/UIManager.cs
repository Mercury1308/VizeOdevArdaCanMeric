using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    // Skoru dışarıdan alıp ekrana yazdıran public bir fonksiyon
    public void UpdateScoreDisplay(int currentScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Skor: " + currentScore;
        }
    }
}