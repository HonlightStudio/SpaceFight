using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float distance;
    [SerializeField] private GameObject Enemy;
    
    
    private List<List<GameObject>> enemies = new List<List<GameObject>>();



    public void Start()
    {
        
    }
    
}
