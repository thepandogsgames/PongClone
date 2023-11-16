using UnityEngine;

namespace Code.Movement
{
    public interface IMovement
    {
        public void Move(Vector2 direction);
        public void Config(Rigidbody2D rb, float speed);
    }
}
