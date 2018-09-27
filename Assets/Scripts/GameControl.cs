using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    public float ScrollSpeed = -1.5f;
    public bool GameOver = false;
    public Text ScoreText;
    
    [SerializeField]
    private GameObject gameOverText;

    private int score = 0;


    void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
		else if (Instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	void Update ()
    {
		if (this.GameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored()
    {
        if (!this.GameOver)
        {
            this.score++;
            this.ScoreText.text = "Score: " + this.score.ToString();
        }        
    }

    public void BirdDied()
    {
        this.gameOverText.SetActive(true);
        this.GameOver = true;
    }
}
