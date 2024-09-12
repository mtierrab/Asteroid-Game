using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     public Asteroid asteroidPrefab;
    
     private int count = 0;
     private int level = 0;
     
     
    void Update()
    {
        if(count == 0)
        {
            level++;
            int num = 2 + (2 * level);
            
            for(int i = 0; i < num; i++)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0,2),Random.Range(0,1f),Camera.main.nearClipPlane));
        Debug.Log(spawnPos);
        Asteroid asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
        asteroid.gameManager = this;
    }

     public void GameOver()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        Debug.Log("Game Over");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void plusCount(){count++;}
    public void minusCount(){count--;}
}
