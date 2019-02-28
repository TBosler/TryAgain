using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    public GameObject playerCharacter;
    public Sprite token1;
    public Sprite token2;
    public Sprite token3;
    int prevHealth = -1;
    public Image image;

    // Start is called before the first frame update
    void Update()
    {
        PlayerController player = playerCharacter.GetComponent<PlayerController>();

        if (player.health != prevHealth)
        {
            switch (player.health)
            {
                case (1):
                    {
                        image.sprite = token3;
                        break;
                    }
                case (2):
                    {
                        image.sprite = token2;
                        break;
                    }
                case (3):
                    {
                        image.sprite = token1;
                        break;
                    }
            }
            prevHealth = player.health;
        }
    }
    
}
