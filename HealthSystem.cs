using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] GameObject HealthBar1;
    [SerializeField] GameObject HealthBar1_off;
    [SerializeField] GameObject HealthBar2;
    [SerializeField] GameObject HealthBar2_off;
    [SerializeField] GameObject HealthBar3;
    [SerializeField] GameObject HealthBar3_off;
    [SerializeField] GameObject HealthBar4;
    [SerializeField] GameObject HealthBar4_off;

    [SerializeField] Health healthBar=new Health();

    void Start()
    {
        HealthBar1.SetActive(true);
        HealthBar2.SetActive(true);
        HealthBar3.SetActive(true);
        HealthBar4.SetActive(true);
        HealthBar1_off.SetActive(false);
        HealthBar2_off.SetActive(false);
        HealthBar3_off.SetActive(false);
        HealthBar4_off.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(healthBar.GetCurrentHealth());
        if (healthBar.GetCurrentHealth() < healthBar.GetMaxHealth() * .75)
        {
            HealthBar4.SetActive(false);
            HealthBar4_off.SetActive(true);
            Debug.Log("Health Bar 4");
        }

        if (healthBar.GetCurrentHealth() < healthBar.GetMaxHealth() * .50)
        {
            HealthBar3.SetActive(false);
            HealthBar3_off.SetActive(true);
        }

        if (healthBar.GetCurrentHealth() < healthBar.GetMaxHealth() * .25)
        {
            HealthBar2.SetActive(false);
            HealthBar2_off.SetActive(true);
        }

        if (healthBar.GetCurrentHealth() <= 0)
        {
            HealthBar3.SetActive(false);
            HealthBar3_off.SetActive(true);
        }
    }
}
