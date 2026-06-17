using UnityEngine;
using UnityEngine.InputSystem;

public class MoveToClick : MonoBehaviour
{
    private float speed = 2f; // change the value to increase/reduce speed
    private float maxTurnRate = 100f; // change the value to increase/reduce maneuvering
    private float bankSmooth = 3f; // change the value to increase/reduce rotation smoothness
    
    private const float arrivalDistance = 0.75f;
    private const float minTurnRadius = -5f;
    private const float maxBankAngle = 60f;

    private Vector2 moveToPos;
    private float noseAngle;
    private float bank;
    private bool isMoving;

    private void Start()
    {
        noseAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90f;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector2 clickPos = new Vector2(screenPos.x, screenPos.y);
            moveToPos = Camera.main.ScreenToWorldPoint(clickPos);
            isMoving = true;
        }

        if (isMoving)
        {
            Vector2 toTarget = moveToPos - (Vector2)transform.position;
            float distance = toTarget.magnitude;

            if (distance <= arrivalDistance)
            {
                isMoving = false;
                bank = Mathf.Lerp(bank, 0f, Time.deltaTime * bankSmooth);
                ApplyRotation();
                return;
            }

            float targetNose = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;
            float delta = Mathf.DeltaAngle(noseAngle, targetNose);

            float omegaRad = minTurnRadius > 0.001f ? speed / minTurnRadius : maxTurnRate * Mathf.Deg2Rad;
            float omegaDeg = Mathf.Min(omegaRad * Mathf.Rad2Deg, maxTurnRate);
            float maxStep = omegaDeg * Time.deltaTime;
            float turnStep = Mathf.Clamp(delta, -maxStep, maxStep);
            noseAngle += turnStep;

            Vector2 forward = new Vector2(-Mathf.Sin(noseAngle * Mathf.Deg2Rad), Mathf.Cos(noseAngle * Mathf.Deg2Rad));
            transform.position += (Vector3)(forward * speed * Time.deltaTime);

            float currentTurnRate = turnStep / Time.deltaTime;
            float bankFromTurn = Mathf.Clamp(currentTurnRate / maxTurnRate * 1.5f, -1f, 1f) * maxBankAngle;
            bank = Mathf.Lerp(bank, bankFromTurn, Time.deltaTime * bankSmooth);
            ApplyRotation();
        }
        else
        {
            bank = Mathf.Lerp(bank, 0f, Time.deltaTime * bankSmooth);
            ApplyRotation();
        }
    }

    private void ApplyRotation()
    {
        transform.rotation = Quaternion.AngleAxis(noseAngle, Vector3.forward) * Quaternion.AngleAxis(bank, Vector3.up);
    }
}
