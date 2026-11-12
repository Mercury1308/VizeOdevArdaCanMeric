using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; //Skor yazımız

    public void UpdateScoreDisplay(int currentScore)//Skorumuzu diğer koddan alıyoruz
    {
        if (scoreText != null)
        {
            scoreText.text = "Skor: " + currentScore;//Skor + sayı yapıyoruz
        }
    }
}