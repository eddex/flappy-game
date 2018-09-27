using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int ColumnPoolSize = 5;
    public GameObject ColumnPrefab;
    public float SpawnRate = 4f;
    public float ColumnMin = -1f;
    public float ColumnMax = 1f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private int currentColumn = 0;

	void Start ()
    {
        this.columns = new GameObject[this.ColumnPoolSize];
        for (int i = 0; i < this.ColumnPoolSize; i++)
        {
            this.columns[i] = GameObject.Instantiate(this.ColumnPrefab, this.objectPoolPosition, Quaternion.identity);
        }
		
	}
	
	void Update ()
    {
        this.timeSinceLastSpawned += Time.deltaTime;
        if (!GameControl.Instance.GameOver && this.timeSinceLastSpawned > this.SpawnRate)
        {
            this.timeSinceLastSpawned = 0;
            var spawnPositonY = Random.Range(this.ColumnMin, this.ColumnMax);
            this.columns[this.currentColumn].transform.position = new Vector2(10f, spawnPositonY);
            this.currentColumn++;
            if (this.currentColumn >= this.ColumnPoolSize)
            {
                this.currentColumn = 0;
            }
        }
	}
}
