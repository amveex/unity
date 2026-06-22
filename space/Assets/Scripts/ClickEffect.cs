using UnityEngine;
using UnityEngine.InputSystem;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private GameObject clickEffectPrefab;

    private Vector2 screenPos;
    private Vector2 clickPos;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            screenPos = Mouse.current.position.ReadValue();
            clickPos = Camera.main.ScreenToWorldPoint(screenPos);
            Instantiate(clickEffectPrefab, clickPos, Quaternion.identity);
        }
    }
}
