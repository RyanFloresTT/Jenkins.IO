using UnityEngine;

namespace Player {
    public class Player : MonoBehaviour {
        public int Health { get; set; } = 100;

        public void TakeDamage(int damage) {
            Health -= damage;
            if (Health <= 0) Destroy(gameObject);
        }
    }
}