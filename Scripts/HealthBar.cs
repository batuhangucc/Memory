using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
            if (slider == null)
            {
                Debug.LogError("Slider component not found.");
            }
        }
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetVisible(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}





