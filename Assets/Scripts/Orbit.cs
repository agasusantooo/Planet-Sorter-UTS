using UnityEngine;

public class Orbit : MonoBehaviour
{
    public string acceptedTag; // contoh: "Earth", "Mars", dll
    private bool hasScored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(acceptedTag) && !hasScored)
        {
            ScoreManager.Instance.AddScore(10);
            hasScored = true;

            Debug.Log("Planet benar dan tetap di orbit: " + acceptedTag);
        }
    }
}
