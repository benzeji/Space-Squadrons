using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xRange;
    [SerializeField] private float yRange;
    [SerializeField] private GameObject[] lasers;
    
    [Header("Screen position based tuning")]
    [SerializeField] private float positionPitchFactor;
    [SerializeField] private float positionYawFactor;
    [SerializeField] private float controlPitchFactor;
    [SerializeField] private float controlRollFactor;
    

    private float _xThrow, _yThrow;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    
    private void ProcessRotation()
    {
        var transform1 = transform;
        var localPosition = transform1.localPosition;
        var pitchDueToPosition = localPosition.y * positionPitchFactor;
        var pitchDueToControlThrow = _yThrow * controlPitchFactor;
        var pitch = pitchDueToPosition + pitchDueToControlThrow;

        var yaw = localPosition.x * positionYawFactor;
        var roll = _xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    private void ProcessTranslation()
    {
        _xThrow = Input.GetAxis("Horizontal");
        _yThrow = Input.GetAxis("Vertical");

        var xOffset = _xThrow * Time.deltaTime * moveSpeed;
        var localPosition = transform.localPosition;
        var rawXPos = localPosition.x + xOffset;
        var clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        var yOffset = _yThrow * Time.deltaTime * moveSpeed;
        var rawYPos = localPosition.y + yOffset;
        var clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        localPosition = new Vector3(clampedXPos, clampedYPos, localPosition.z);
        transform.localPosition = localPosition;
    }
    
    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ActiveLasers();
        }
        else
        {
            DeActiveLasers();
        }
    }
    
    private void ActiveLasers()
    {
        foreach (var laser in lasers)
        {
           laser.SetActive(true);
        }
    }
    
    private void DeActiveLasers()
    {
        foreach (var laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}