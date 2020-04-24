namespace Platform2DUtils.GameplaySystem
{
    using UnityEngine;

    public class GameplaySystem
    {
        ///<summary>
        /// Returns a Vector2 with Horizontal and Vertical axes.
        ///</summary>
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs.
        ///</summary>
        ///<param name="t">Transform component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        public static void TMovement(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed);
        }

        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs uisng force.
        ///</summary>
        ///<param name="rb2D">Rigidbody2D component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        ///<param name="maxVel">Maximum velocity of rigidbody on x component</param>
        public static void MovementAddForce(Rigidbody2D rb2D, float moveSpeed, float maxVel)
        {
            rb2D.AddForce(Vector2.right * moveSpeed * Axis.x, ForceMode2D.Impulse);
            float velXClamp = Mathf.Clamp(rb2D.velocity.x, -maxVel, maxVel);
            rb2D.velocity = new Vector2(velXClamp, rb2D.velocity.y);
            if(Axis.x == 0)
            {
                rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
            }
        }

        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs uisng force.
        ///</summary>
        ///<param name="rb2D">Rigidbody2D component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        ///<param name="maxVel">Maximum velocity of rigidbody on x component</param>
        ///<param name="grounding">Detects if im touching groundf layer</param>
        public static void MovementAddForce(Rigidbody2D rb2D, float moveSpeed, float maxVel, bool grounding)
        {
            rb2D.AddForce(Vector2.right * moveSpeed * Axis.x, ForceMode2D.Impulse);
            float velXClamp = Mathf.Clamp(rb2D.velocity.x, -maxVel, maxVel);
            rb2D.velocity = new Vector2(velXClamp, rb2D.velocity.y);

            if (Axis.x == 0 && grounding)
            {
                rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
            }
        }

        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs using velocity.
        ///</summary>
        ///<param name="rb2D">Rigidbody2D component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        ///<param name="maxVel">Maximum velocity of rigidbody on x component</param>
        public static void MovementVelocity(Rigidbody2D rb2D, float moveSpeed, float maxVel)
        {
            rb2D.velocity = new Vector2(Axis.x * moveSpeed, rb2D.velocity.y);
            Vector2 clampedVelocity = Vector2.ClampMagnitude(rb2D.velocity, maxVel);
            rb2D.velocity = new Vector2(clampedVelocity.x, rb2D.velocity.y);
        }

        ///<summary>
        /// Moves player in Horizontal axis with keyboard inputs and multiplied by delta time.
        ///</summary>
        ///<param name="t">Transform component of the player</param>
        ///<param name="moveSpeed">The coeficient of speed</param>
        public static void TMovementDelta(Transform t, float moveSpeed)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        }

        ///<summary>
        /// Returns if jump button was buttondown.
        ///</summary>
        public static bool JumpBtn
        {
            get => Input.GetButtonDown("Jump");
        }

        public static void Jump(Rigidbody2D rb2D, float jumpForce)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}