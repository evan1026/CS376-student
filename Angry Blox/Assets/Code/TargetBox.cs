using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    private bool isScored = false;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        if (!isScored) {
            ScoreKeeper.AddToScore(GetComponent<Rigidbody2D>().mass);
            isScored = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Ground")) {
            Scored();
        }
    }
}
