using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Projectile : MonoBehaviour
    {
        public ProjectileRenderer Renderer
        {
            get => _renderer;
            set
            {
                value.Init(this);
                
                _renderer = value;
            }
        }

        public float Lifetime;
        public float Speed;
        
        [SerializeField] private ProjectileRenderer _renderer;

        public event UnityAction<Vector2> OnLaunch;
        public event UnityAction OnLifetimeEnd, OnCollideByObstacle;

        private Rigidbody2D _rb;

        private Vector2 _currentDir;

        internal void Launch(Vector2 direction)
        {
            StartCoroutine(LifeTimer());
            OnLaunch?.Invoke(direction);

            _currentDir = direction;
            
            _renderer.gameObject.SetActive(true);
        }

        internal void OnRendererCollided() => OnCollideByObstacle?.Invoke();

        private IEnumerator LifeTimer()
        {
            Lifetime -= Time.deltaTime;
            
            _rb.MovePosition((Vector2)transform.position + Time.deltaTime * Speed * _currentDir);

            if (Lifetime <= 0)
            {
                OnLifetimeEnd?.Invoke();
            }
            
            yield return null;
        }
    }
}