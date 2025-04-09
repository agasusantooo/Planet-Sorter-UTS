using UnityEngine;

public class ConveyerMove : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        DragPlanet draggable = GetComponent<DragPlanet>();
        if (draggable != null && draggable.IsLocked())
            return;

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blackhole") || other.CompareTag("Tembok"))
        {
            // Kurangi score dan life
            ScoreManager.Instance.ReduceScore(10);
            ScoreManager.Instance.LoseLife();

            Destroy(gameObject);
        }
    }
}
