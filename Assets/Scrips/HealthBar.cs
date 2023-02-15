using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // private RectTransform healthBarRectTransform;

    [SerializeField] private Image healthBarSprite;


    void Start()
    {
        // healthBarRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // currentHealth +=  20 * Time.deltaTime;
        float ratio = Health.currentHealth / Health.maxHealth;

        healthBarSprite.fillAmount = ratio;

        // healthBarRectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}