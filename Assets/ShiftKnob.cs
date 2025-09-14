using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShiftKnob : MonoBehaviour
{
    [HideInInspector]
    public int currentGear = 0;
    
    private Camera mainCam;
    private bool isDragging = false;
    private PlayerInputActions inputActions;

    [Header("Gear Settings")]
    public Transform[] gearSlots;   // 6 gear slot transforms

    [Header("References")]
    public Transform neutralPosition;
    public Transform snapPoint;     // assign the SnapPoint child in Inspector
    public float snapThreshold = 0.25f;

    private Vector2 dragOffset;

    private void Awake()
    {
        mainCam = Camera.main;
        inputActions = new PlayerInputActions();
        inputActions.Enable();

        inputActions.Player.Grab.performed += ctx => OnClick();
        inputActions.Player.Grab.canceled += ctx => OnRelease();
    }

    private void OnClick()
    {
        Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(
            inputActions.Player.PointerPosition.ReadValue<Vector2>()
        );

        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);
        if (hit != null && hit.gameObject == gameObject) // grab only from main knob collider
        {
            isDragging = true;
            dragOffset = (Vector2)transform.position - mouseWorldPos;
        }
    }

    private void OnRelease()
    {
        if (isDragging)
        {
            isDragging = false;

            // Use the snapPoint position for snapping
            Vector2 snapPos = snapPoint.position;

            Transform closest = null;
            float minDist = Mathf.Infinity;
            foreach (Transform slot in gearSlots)
            {
                float dist = Vector2.Distance(snapPos, slot.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = slot;
                }
            }

            if (closest != null && minDist <= snapThreshold)
            {
                // Move knob so snapPoint sits exactly on slot
                Vector2 offset = (Vector2)transform.position - (Vector2)snapPoint.position;
                transform.position = (Vector2)closest.position + offset;

                currentGear = System.Array.IndexOf(gearSlots, closest) + 1;
                Debug.Log("Shifted into Gear: " + currentGear);
            }
            else
            {
                // Snap back to neutral
                Vector2 offset = (Vector2)transform.position - (Vector2)snapPoint.position;
                transform.position = (Vector2)neutralPosition.position + offset;
                currentGear = 0;
                Debug.Log("Neutral");            }
        }
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }
    private void Update()
    {
        if (isDragging)
        {
            Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(
                inputActions.Player.PointerPosition.ReadValue<Vector2>()
            );

            // Move knob according to drag
            Vector2 newPos = mouseWorldPos + dragOffset;

            transform.position = newPos;
        }
    }}
