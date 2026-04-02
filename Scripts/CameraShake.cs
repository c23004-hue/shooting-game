using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("í”÷U“®")]
    public float idleShakeAmount = 0.03f; 
    public float idleShakeSpeed = 1.5f;  

    [Header("ÕŒ‚—h‚ê")]
    public float impactShakeDuration = 0.2f; 
    public float impactShakeMagnitude = 0.2f; 

    private Vector3 initialPos;
    private float impactShakeTime = 0f;

    void Start()
    {
        initialPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 shakeOffset = Vector3.zero;

        // ÕŒ‚—h‚êi—Dæj
        if (impactShakeTime > 0)
        {
            shakeOffset = Random.insideUnitSphere * impactShakeMagnitude;
            impactShakeTime -= Time.deltaTime;
        }

        // í”÷U“®
        float idleX = Mathf.Sin(Time.time * idleShakeSpeed) * idleShakeAmount;
        float idleY = Mathf.Sin(Time.time * idleShakeSpeed * 1.2f) * idleShakeAmount;
        shakeOffset += new Vector3(idleX, idleY, 0f);

        transform.localPosition = initialPos + shakeOffset;
    }

    // ÕŒ‚—h‚ê‚ğŠO•”‚©‚çŒÄ‚Ô
    public void ShakeImpact()
    {
        impactShakeTime = impactShakeDuration;
    }
}
