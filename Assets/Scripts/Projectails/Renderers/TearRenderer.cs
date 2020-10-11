using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(ProjectileRenderer))]
public class TearRenderer : MonoBehaviour
{
    public SpriteRenderer Tear;
    public SpriteRenderer TearShadow;

    private ProjectileRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<ProjectileRenderer>();
    }

    private void Update()
    {
        Tear.transform.position = (Vector2)_renderer.transform.position + Vector2.up * _renderer.Owner.Lifetime;
        TearShadow.transform.position = (Vector2) _renderer.transform.position - Vector2.down;
    }
}
