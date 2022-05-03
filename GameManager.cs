using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnIntreval = 1.5f;
    public int[] spawnArray = new int[] { -16, -6, 6, 16 };
    public TextMeshProUGUI scoreCal;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI titleScreen;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button startButton;
    public Button restartButton;
    private float timeLeft = 30.0f;
    // public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnFunction", 2, spawnIntreval);
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);

    }

    // Update is called once per frame
    void Update()
    {
        // if (isGameActive)
        // {
        //     startButton.gameObject.SetActive(false);
        //     int randomIndex = Random.Range(0, spawnArray.Length);
        //     int animalIndex = Random.Range(0, prefabs.Length);
        //     Vector3 spawnPos = new Vector3(spawnArray[randomIndex], 24, -18);
        //     Instantiate(prefabs[animalIndex], spawnPos, transform.rotation);
        // }
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "time" + Mathf.Round(timeLeft);
            if (timeLeft < 0)
            {
                GameOver();
            }
        }

    }
    IEnumerator spawnManage()
    {
        while (isGameActive)
        {

            startButton.gameObject.SetActive(false);
            titleScreen.gameObject.SetActive(false);
            yield return new WaitForSeconds(spawnIntreval);
            int randomIndex = Random.Range(0, spawnArray.Length);
            int animalIndex = Random.Range(0, prefabs.Length);
            Vector3 spawnPos = new Vector3(spawnArray[randomIndex], 24, -18);
            Instantiate(prefabs[animalIndex], spawnPos, transform.rotation);

        }
    }
    // public void spawnManage()
    // {

    // }
    public void UpdateScore(int updateScore)
    {
        score += updateScore;
        scoreCal.text = "Score : " + score;
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void StartGame()
    {
        isGameActive = true;
        // spawnManage();
        StartCoroutine(spawnManage());
        score = 0;
        UpdateScore(0);
        // Debug.Log("start");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
