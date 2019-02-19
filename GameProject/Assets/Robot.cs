using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    Animator animator;
    private GameObject Br2, Br1, Br3, F1, F2, F3, Fl1, Fl2, Fl3;
    public float animTime;
    public int health = 20;
    public TMPro.TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
        Br1 = GameObject.Find("BR Orb Glow 1");
        Br2 = GameObject.Find("BR Orb Glow 2");
        Br3 = GameObject.Find("BR Orb Glow 3");
        F1 = GameObject.Find("F Orb Glow 1");
        F2 = GameObject.Find("F Orb Glow 2");
        F3 = GameObject.Find("F Orb Glow 3");
        Fl1 = GameObject.Find("FL Orb Glow 1");
        Fl2 = GameObject.Find("FL Orb Glow 2");
        Fl3 = GameObject.Find("FL Orb Glow 3");

        Br1.SetActive(true);
        Br2.SetActive(false);
        Br3.SetActive(false);
        F1.SetActive(true);
        F2.SetActive(false);
        F3.SetActive(false);
        Fl1.SetActive(true);
        Fl2.SetActive(false);
        Fl3.SetActive(false);
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(Animate());

        //healthText.text = health.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Animate()
    {
        int part = 2;
        while (true)
        {
            yield return new WaitForSecondsRealtime(animTime);
            switch (part)
            {
                case 1:
                    {
                        Br1.SetActive(true);
                        Br2.SetActive(false);
                        Br3.SetActive(false);
                        F1.SetActive(true);
                        F2.SetActive(false);
                        F3.SetActive(false);
                        Fl1.SetActive(true);
                        Fl2.SetActive(false);
                        Fl3.SetActive(false);
                        part = 2;
                        break;
                    }
                case 2:
                    {
                        Br1.SetActive(false);
                        Br2.SetActive(true);
                        Br3.SetActive(false);
                        F1.SetActive(false);
                        F2.SetActive(true);
                        F3.SetActive(false);
                        Fl1.SetActive(false);
                        Fl2.SetActive(true);
                        Fl3.SetActive(false);
                        part = 3;
                        break;
                    }
                case 3:
                    {
                        Br1.SetActive(false);
                        Br2.SetActive(false);
                        Br3.SetActive(true);
                        F1.SetActive(false);
                        F2.SetActive(false);
                        F3.SetActive(true);
                        Fl1.SetActive(false);
                        Fl2.SetActive(false);
                        Fl3.SetActive(true);
                        part = 1;
                        break;
                    }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collision");
        Debug.Log(other.gameObject.name + " HIT " + gameObject.name);
        if(other.gameObject.tag == "weapon")
        {
            Debug.Log("You hit the enemy");
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            health -= weapon.damage;
            healthText.text = health.ToString();
        }

    }
}
