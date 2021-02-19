using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.sqrMagnitude > 0)
        {
            animator.SetFloat("speed",aiPath.destination.sqrMagnitude);
            Vector2 lookDir =new Vector2(aiPath.destination.x,aiPath.destination.y) - new Vector2(aiPath.position.x,aiPath.position.y);
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}
