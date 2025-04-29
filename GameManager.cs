using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject StartUi;
    [SerializeField] private GameObject EndUi;
    [SerializeField] private GameObject OnGameUi;
    [SerializeField] private GameObject particle1;
    [SerializeField] private GameObject particle2;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private EnemySystem EnemySystem;
    private void Start()
    {
        StartUi.SetActive(true);
        Time.timeScale = 0f;
        
        EndUi.SetActive(false);
    }

    public void StartGame()
    {
        OnGameUi.SetActive(true);
        StartUi.SetActive(false);
        EndUi.SetActive(false);
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.SetActive(true);
        player.GetComponent<Health>().CurrentHealth = player.GetComponent<Health>().MaxHealth;
        player.GetComponent<Health>().isAlive = true;
        player.transform.position = Vector3.zero;
        Time.timeScale = 1f;
        particle1.SetActive(true);
        particle2.SetActive(true);
    }


    public void EndGame()
    {
        OnGameUi.SetActive(false);
        EndUi.SetActive(true);
        StartUi.SetActive(false);
        player.GetComponent<SpriteRenderer>().enabled = false;
        particle1.SetActive(false);
        particle2.SetActive(false);
        Time.timeScale = 0f;
        scoreSystem.score = 0;
        EnemySystem.KillAllEnemies();
    }
    
    
    
}
