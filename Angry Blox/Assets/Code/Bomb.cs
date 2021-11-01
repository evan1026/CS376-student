using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

    public void Destruct() {
        Destroy(gameObject);
    }

    public void Boom() {
        GetComponent<PointEffector2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<ProjectileThrower>() != null && collision.relativeVelocity.magnitude >= ThresholdForce) {
            Boom();
        }
    }
}
