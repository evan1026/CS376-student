using UnityEngine;

/// <summary>
/// Control the player on screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Prefab for the orbs we will shoot
    /// </summary>
    public GameObject OrbPrefab;

    /// <summary>
    /// How fast our engines can accelerate us
    /// </summary>
    public float EnginePower = 1;
    
    /// <summary>
    /// How fast we turn in place
    /// </summary>
    public float RotateSpeed = 1;

    /// <summary>
    /// How fast we should shoot our orbs
    /// </summary>
    public float OrbVelocity = 10;

    private Rigidbody2D rigidBody;
    private Transform playerTransform;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }


    /// <summary>
    /// Fire if the player is pushing the button for the Fire axis
    /// Unlike the Enemies, the player has no cooldown, so they shoot a whole blob of orbs
    /// The orb should be placed one unit "in front" of the player.  transform.right will give us a vector
    /// in the direction the player is facing.
    /// It should move in the same direction (transform.right), but at speed OrbVelocity.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        if (Input.GetAxis("Fire") != 0) {
            var newOrb = Instantiate(OrbPrefab, playerTransform.position + playerTransform.right, Quaternion.identity);
            var orbRigidBody = newOrb.GetComponent<Rigidbody2D>();
            orbRigidBody.velocity = playerTransform.right * OrbVelocity;
        }

    }

    /// <summary>
    /// Accelerate and rotate as directed by the player
    /// Apply a force in the direction (Horizontal, Vertical) with magnitude EnginePower
    /// Note that this is in *world* coordinates, so the direction of our thrust doesn't change as we rotate
    /// Set our angularVelocity to the Rotate axis time RotateSpeed
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var joystickDir = new Vector2(horizontalInput, verticalInput).normalized;
        var movement = joystickDir * EnginePower;
        rigidBody.AddForce(movement);

        var rotateInput = Input.GetAxis("Rotate");
        rigidBody.angularVelocity = rotateInput * RotateSpeed;
    }

    /// <summary>
    /// If this is called, we got knocked off screen.  Deduct a point!
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        ScoreKeeper.ScorePoints(-1);
    }
}
