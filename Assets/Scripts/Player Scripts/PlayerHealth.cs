using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHearts = 5; // Maximum number of hearts
    private int currentHearts; // Current number of hearts
    [SerializeField] private Image[] hearts; // Array of TextMeshProUGUI objects for hearts
    [SerializeField] private Sprite fullHeart; // Sprite for a full heart
    [SerializeField] private Sprite emptyHeart; // Sprite for an empty heart

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHearts = maxHearts;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;

        if (currentHearts >= 0)
        {
            hearts[currentHearts].sprite = emptyHeart;
            anim.SetTrigger("Hurt");
        }

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    private void Die(){
        Debug.Log("You Died");
        anim.SetTrigger("Death");
        this.enabled = false;
        GetComponent<PlayerAnimations>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;

        Invoke("RestartScene", 3.0f);
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i < maxHearts)
            {
                hearts[i].sprite = emptyHeart;
            } else {
                hearts[i].GetComponent<Image>().enabled = false;
            }
        }
    }


    private void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
