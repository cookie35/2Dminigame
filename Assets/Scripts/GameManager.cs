using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject gameoverPanel;

    float time = 0f;
    public Text nowScore;
    public Text recentScore;
    public Text bestScore;

    string key = "bestScore";

    bool isGamestart;

    void Start()
    {
        Time.timeScale = 0f;  // ������ ��ȯ�� �ϴ� �����. �ʱⰪ.
   
    }

    public void GameStart()
    {
        Time.timeScale = 1f; 
        startPanel.SetActive(false);
        isGamestart = true;
        InvokeRepeating("MakeEnemy", 0.0f, 1.0f);
    }

    void MakeEnemy()
    {
        float enemyPlace = player.position.x + 14f;
        float y = Random.Range(-3.4f, 3.4f);  
        Vector3 enemyPosition = new Vector3(enemyPlace, y, 0);
        Instantiate(enemy,enemyPosition,Quaternion.identity);  // (��ȯ�� ������Ʈ, ��ȯ�� ��ġ, ��ȯ�� �� rotation ��ġ)
    }

    private void Update()
    {
        if (isGamestart)
        {
            time += Time.deltaTime;
            nowScore.text = time.ToString("N1");
        }

    }

    public void GameClear()
    {
        recentScore.text = time.ToString("N1");
        Time.timeScale = 0f;
        
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat("bestScore");
            if (best > time)
            {
                PlayerPrefs.SetFloat("bestScore", time);
                bestScore.text = time.ToString("N1");
            }
            else
            {
                bestScore.text = best.ToString("N1");
            }
        }
        else
        {
            PlayerPrefs.SetFloat("bestScore", time);
            bestScore.text = time.ToString("N1");
        }
        
        endPanel.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameoverPanel.SetActive(true);
    }

}


