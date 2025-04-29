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

    private void Start()
    {
        StartUi.SetActive(true);
    }

    public void StartGame()
    {
        OnGameUi.SetActive(true);
        StartUi.SetActive(false);
        EndUi.SetActive(false);
        player.GetComponent<SpriteRenderer>().enabled = true;
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
    }
    
    
    
}
