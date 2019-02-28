using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject healthText;
    private GameObject EnemyName;
    private GameObject healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("EnemyHealth");
        EnemyName = GameObject.Find("EnemyName");
        healthSlider = GameObject.Find("HealthSlider");
        healthText.SetActive(false);
        healthSlider.SetActive(false);
        EnemyName.SetActive(false);

    }
    
    public void setEnemyHealth(int curr, int max)
    {
        if (curr == 0)
        {
            healthText.SetActive(false);
            healthSlider.SetActive(false);
            EnemyName.SetActive(false);
            return;
        }

        //healthText.SetActive(true);
        //healthText.GetComponent<TMPro.TMP_Text>().text = curr.ToString();
        healthSlider.SetActive(true);
        healthSlider.GetComponent<Slider>().value = (float)curr/max;
    }

    public void setEnemmyName(string name)
    {
        EnemyName.SetActive(true);
        EnemyName.GetComponent<TMPro.TMP_Text>().text = name;
    }
}
