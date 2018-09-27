using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    public bool gameOver = false;


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
		if (this.gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdDied()
    {
        this.gameOverText.SetActive(true);
        this.gameOver = true;
    }
}
