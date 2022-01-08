using TMPro;
using UnityEngine;

public class PlayerHealthUi : MonoBehaviour
{
    private TextMeshProUGUI _tmpUiHealth;

    private void Awake()
    {
        _tmpUiHealth = GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateHealth(int health)
    {
        _tmpUiHealth.text = health.ToString();
    }
}


