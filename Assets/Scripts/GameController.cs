using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    //public float spawnTime;
    private float m_spawnTime;
    private bool isGameover;
    private int m_score;
    UIManager m_ui;
    [SerializeField] private Button _pause;
    [SerializeField] private Button _play;
    void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        m_spawnTime = 0;
        m_ui.SetScoreText("SCORE : " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover)
        {
            m_ui.ShowGameOverPanel(true);
        }    
        SpawnObstacle();
    }
    public int GetScore()
    {
        return  m_score;
    }    
    public void SetScore(int value)
    {
        m_score = value;
    }    

    public void IncrementScore()//de public con de truy suat o noi khac
    {
        if (isGameover) return;
        m_score++;
        m_ui.SetScoreText("SCORE : " + m_score);
    }   
    
    public bool IsGameOver()
    {
        return isGameover;
    }    
    public void SetGameOverState(bool state)
    {
        isGameover = state;
    }    

    public void SpawnObstacle()
    {
        if (IsGameOver()) return; 
        m_spawnTime-=Time.deltaTime;
        if (m_spawnTime > 0) return;
        
        m_spawnTime = Random.Range(1.5f, 3f);
        float randYPos = Random.Range(-4f, -2f);
        
        Vector3 pos = new Vector3(13, randYPos,0);
        Instantiate(obstacle, pos, Quaternion.identity);
    }    
    public void Replay()
    {
        /*
         //cach 1 
        m_score = 0;
        m_ui.SetScoreText("SCORE : " + 0);
        m_ui.ShowGameOverPanel(false);
        isGameover = false;
        */
        SceneManager.LoadScene("GamePlay");
    }    
    public void QuitGame()
    {
        Application.Quit();
    }    
    public void PauseGame()
    {
        Time.timeScale = 0;
        _pause.gameObject.SetActive(false);
        _play.gameObject.SetActive(true);
    }    
    public void PlayGame()
    {
        Time.timeScale = 1;
        _play.gameObject.SetActive(false);
        _pause.gameObject.SetActive(true);
    }    
}
