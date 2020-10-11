using UnityEngine;

namespace DefaultNamespace
{
    public class ProjectileRenderer : MonoBehaviour
    {
        public Projectile Owner { get; private set; }
        
        public void Init(Projectile projectile)
        {
            transform.parent = projectile.transform;

            Owner = projectile;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Owner.OnRendererCollided();
        }
    }
}