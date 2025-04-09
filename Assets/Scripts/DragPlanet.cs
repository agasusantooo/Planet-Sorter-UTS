using UnityEngine;

public class DragPlanet : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    private bool isLocked = false;

    private string correctOrbitTag;
    private Rigidbody2D rb;
    private Collider2D planetCollider;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        planetCollider = GetComponent<Collider2D>();

        // Tentukan orbit yang benar berdasarkan nama planet
        if (gameObject.name.Contains("Earth")) correctOrbitTag = "OrbitEarth";
        else if (gameObject.name.Contains("Mars")) correctOrbitTag = "OrbitMars";
        else if (gameObject.name.Contains("Jupiter")) correctOrbitTag = "OrbitJupiter";
        else if (gameObject.name.Contains("Saturn")) correctOrbitTag = "OrbitSaturn";
    }

    void OnMouseDown()
    {
        if (isLocked || Time.timeScale == 0f) return; // Tambahkan cek pause

        isDragging = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z);
    }

    void OnMouseDrag()
    {
        if (isDragging && !isLocked && Time.timeScale != 0f) // Tambahkan cek pause
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        if (isLocked || Time.timeScale == 0f) return; // Tambahkan cek pause

        isDragging = false;

        if (!isLocked)
        {
            transform.position = startPosition;

            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isLocked) return;

        if (other.CompareTag(correctOrbitTag))
        {
            isLocked = true;

            if (planetCollider != null)
                planetCollider.enabled = false;

            ScoreManager.Instance.AddScore(10);

            float radius = 0.5f;
            Vector2 randomOffset = Random.insideUnitCircle * radius;
            transform.position = other.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
                rb.bodyType = RigidbodyType2D.Kinematic;
            }

            Debug.Log($"{gameObject.name} locked in {correctOrbitTag}, score +10");
        }
    }

    public bool IsLocked()
    {
        return isLocked;
    }
}
