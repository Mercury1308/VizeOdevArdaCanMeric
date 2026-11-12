using UnityEngine;
using UnityEngine.SceneManagement;

public class Collecter : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 50;

    [SerializeField] private UIManager uiManager; //Scripti çağırıyoruz

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            //Eğer yeşil topsa 10 puan eklensin
            score += 10;
            Destroy(other.gameObject);//sahneden sil
        }
        else if (other.CompareTag("Red"))
        {
            //Eğer kırmızı topsa 5 puan eksilsin
            score -= 5;
            Destroy(other.gameObject);//sahneden sil
        }

        if (uiManager != null)
        {
            //eğer çapırdığımı script varsa içindeki fonksiyonu burda çağırıyoruz
            uiManager.UpdateScoreDisplay(score);
        }

        if (score >= targetScore)
        {
            //eğer hedeflediğimizpuana yani 50 ye ukaştıysak sahneyi yeniden başlat
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Şuan mevcut olarak bulunduğumuz sahne numarasını alıyoruz
        SceneManager.LoadScene(currentSceneIndex);//Bulunduğumuz sahneyi yeniden yüklüyor
    }
}