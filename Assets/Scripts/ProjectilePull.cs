using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ProjectilePull : MonoBehaviour
{
    public GameObject Prefab;

    public int Count = 120;

    public List<Projectile> Projectiles;

    private void Start()
    {
        Projectiles = new List<Projectile>(Count);
        
        for (var i = 0; i < Count; i++)
        {
            var projectile = Instantiate(Prefab, transform).GetComponent<Projectile>();
            
            Projectiles.Add(projectile);
            projectile.Renderer.gameObject.SetActive(false);
        }
        
    }

    public Projectile Take()
    {
        
    }
}
