using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image fillImage;
    public float maxHealth = 100;
    public float currentHealth;
    public bool isDie = false;
    public bool isStun;
    public float TimeStun = 1.5f;
    private Animator animator;
    private float fullWidth;


    void Start()
    {
        fullWidth = fillImage.rectTransform.sizeDelta.x;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }


    public void Heal(float amount)
    {
        if (isDie || isStun) return;
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        animator.SetTrigger("Trigger_Buff");
    }


    public void TakeDamage(float dmg)
    {
        if (isDie) return;
        currentHealth -= dmg;
        SetHP(currentHealth);
        animator.SetTrigger("Trigger_GetHit");
        if (currentHealth <= 0) Die();
    }

    public void SetHP(float value)
    {
        currentHealth = Mathf.Clamp(value, 0, maxHealth);
        float ratio = currentHealth / maxHealth;

        var size = fillImage.rectTransform.sizeDelta;
        size.x = fullWidth * ratio;
        fillImage.rectTransform.sizeDelta = size;
    }


    void Die()
    {
        isDie = true;
        animator.SetTrigger("Trigger_Death");
        StartCoroutine(Restart());
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Game");
    }
}
