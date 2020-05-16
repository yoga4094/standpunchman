using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public bool gameStart;
    public GameObject enemy_obj;
    public GameObject resultWindow;
    public PlayerController playerController;

    private void Start()
    {
        gameStart = true;
        SpawnEnemies();
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (playerController.health <= 0)
        {
            gameStart = false;
            resultWindow.SetActive(true);
        }
    }

    private void SpawnEnemies()
    {
        if (gameStart)
        {
            float randomTimer;
            randomTimer = Random.Range(1f, 2f);

            StartCoroutine(SpawnTimer(randomTimer));
        }
    }

    private IEnumerator SpawnTimer(float timer)
    {
        yield return new WaitForSeconds(timer);

        GameObject enemy = Instantiate(enemy_obj, Vector2.zero, Quaternion.identity);
        int direction; //1 = dari kanan | 2 = dari kiri
        direction = Random.Range(1,3);

        if (direction == 1)
        {
            enemy.name = "1";
            enemy.transform.localPosition = new Vector2(-10,-4.22f);
            enemy.GetComponent<EnemyController>().multiply = 1;
        }
        if (direction == 2)
        {
            enemy.name = "2";
            enemy.transform.localPosition = new Vector2(10, -4.22f);
            enemy.GetComponent<EnemyController>().multiply = 1;
            enemy.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            enemy.transform.localPosition = new Vector2(-10, -4.22f);
            enemy.GetComponent<EnemyController>().multiply = 1;
        }

        SpawnEnemies();
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(GameData.scene_mainMenu);
    }
}
